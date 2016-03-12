using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GroupMove
{
	public class AppFunctions
	{
		

		public void UninstallIfPreviouslyInstalled(string[] guiList)
		{
			foreach (var gui in guiList)
			{
				UninstallIfPreviouslyInstalled(gui);
			}
		}


		public void UninstallIfPreviouslyInstalled(string productCodeGUI)
		{

			// HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Installer\UserData\S-1-5-21-2649338361-509334212-3241471374-1001\Products
			// search from there for example for http://www.guttih.com/groupmove
			// copy the value in the UninstallString MsiExec.exe /I{6A92025F-076D-4B87-88D8-CF6645C81238}
			try
			{
				Process p = new Process();
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.CreateNoWindow = true;
				p.StartInfo.FileName = "MsiExec.exe";
				//MsiExec.exe /I{307E97EB-E6AF-44CF-9026-8D3C730BD044}
				//p.StartInfo.Arguments = @"/x{53A13817-D52F-4F16-AE27-68D01DA0A656} /passive";
				p.StartInfo.Arguments = @"/x"+ productCodeGUI + " /passive";
				p.Start();
				p.WaitForExit();
			}
			catch
			{
				MessageBox.Show("Unable to uninstall Application.  Manually uninstall/reinstall to update.");
			}
		}

		/// <summary>
		/// Gets a list of all value names and values from a specified registry key
		/// To the the first value of a dictionaray:
		///		var firstValue = dic[dic.Keys.ToList()[0]];
		/// </summary>
		/// <param name="fullPathToKey">
		///		The path to and including the name of the subkey to be queried delimited by '\\'
		/// </param>
		/// <returns>null if nothing is found otherwize the function returns a dictionary where all values are converted to string</returns>
		public Dictionary<string, string> GetRegistryKeyValues(string fullPathToKey)
		{
			RegistryKey key = RegistryKeyOpenPath(fullPathToKey, false);

			return GetRegistryKeyValues(key);
		}

		/// <summary>
		/// Returns a value from  the registry
		/// </summary>
		/// <param name="fullPathToKey">The path to the key which contains the value. Path is delimited by '\\'</param>
		/// <param name="valueName">Name of the value to query from the registry</param>
		/// <returns>
		///		On success : The registr value as a string.
		///		On error   : null
		/// </returns>
		public string GetRegistryKeyValue(string fullPathToKey, string valueName)
		{
			string str = null;

			RegistryKey key = RegistryKeyOpenPath(fullPathToKey, false);
			if (key == null) return null;

			Object o = key.GetValue(valueName);
			if (o == null) return null;

			RegistryValueKind kind = key.GetValueKind(valueName);

			switch (kind)
			{
				case RegistryValueKind.String:
					str = (string)o;
					break;
			}

			return str;
		}

		/// <summary>
		/// Gets an DWORD or a QWORD value from the registry.
		/// </summary>
		/// <param name="fullPathToKey">The path to the key which contains the value. Path is delimited by '\\'</param>
		/// <param name="valueName">Name of the value to query from the registry</param>
		/// <returns>
		///		Success:
		///			 The value
		///		Error:
		///			-1 Unable to cast the value to an int.
		///			-2 The value was not fonund in the registry
		///			-3 The key was not found int the registry
		/// </returns>
		public long GetRegistryKeyValueLong(string fullPathToKey, string valueName)
		{
			long l = -1;

			RegistryKey key = RegistryKeyOpenPath(fullPathToKey, false);
			if (key == null) return -3;

			Object o = key.GetValue(valueName);
			if (o == null) return -2;

			RegistryValueKind kind = key.GetValueKind(valueName);

			switch (kind)
			{
				case RegistryValueKind.QWord:
						l = (long)o;

				break;
				case RegistryValueKind.DWord:
						l = (long)(int)o;

					break;
			}

			return l;
		}

		/// <summary>
		/// Gets an DWORD value from the registry.
		/// </summary>
		/// <param name="fullPathToKey">The path to the key which contains the value. Path is delimited by '\\'</param>
		/// <param name="valueName">Name of the value to query from the registry</param>
		/// <returns>
		///		Success:
		///			 The value
		///		Error:
		///			-1 Unable to cast the value to an int.
		///			-2 The value was not fonund in the registry
		///			-3 The key was not found int the registry
		/// </returns>
		public int GetRegistryKeyValueInt(string fullPathToKey, string valueName)
		{
			long l = GetRegistryKeyValueLong(fullPathToKey, valueName);
			return (int) (long) l;
		}

		/// <summary>
		/// Saves a string value to the registry
		/// </summary>
		/// <param name="fullPathToKey">The path to the key which contains the value. Path is delimited by '\\'</param>
		/// <param name="valueName">Name of the value</param>
		/// <param name="value">The new value to be saved</param>
		/// <returns>On success : true, otherwize false</returns>
		public bool SetRegistryKeyValue(string fullPathToKey, string valueName, string value)
		{
			bool b;
			RegistryKey key = RegistryKeyOpenPath(fullPathToKey, true);
			
			b = SetRegistryKeyValue(key, valueName, value);
			key.Close();
			return b;
		}

		public bool SetRegistryKeyValue(RegistryKey key, string valueName, string value)
		{
			if (key == null)
				return false;
			try
			{
				key.SetValue(valueName, value);
			}
			catch (Exception)
			{
				return false;
			}


			return true;
		}

		public bool SetRegistryKeyValue(string fullPathToKey, string valueName, int value)
		{
			bool b;
			RegistryKey key = RegistryKeyOpenPath(fullPathToKey, true);
			b = SetRegistryKeyValue(key, valueName, value);
			key.Close();
			return b;
		}

		public bool SetRegistryKeyValue(RegistryKey key, string valueName, int value)
		{
			try
			{
				key.SetValue(valueName, value);
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}


		////////////////////////
		// helper functions   //
		////////////////////////

		/// <summary>
		/// Opens a registry key for reading
		/// </summary>
		/// <param name="fullPathToKey">The path to and including the name of the subkey to be opened delimited by '\\'</param>
		/// <returns></returns>
		public RegistryKey RegistryKeyOpenPath(string fullPathToKey, bool openWithWriteAccess)
		{
			RegistryKey regRoot;

			if (string.IsNullOrEmpty(fullPathToKey))
			{
				return null;
			}


			List<string> regPath = new List<string>(fullPathToKey.Split(('\\')));
			//todo validate if regPath was created
			if (regPath == null || regPath.Count() < 3)
			{   //we need at least one subkey
				return null;
			}

			switch (regPath[0])
			{
				case "HKEY_CURRENT_USER":
					regRoot = Registry.CurrentUser; break;
				case "HKEY_CLASSES_ROOT":
					regRoot = Registry.ClassesRoot; break;
				case "HKEY_CURRENT_CONFIG":
					regRoot = Registry.CurrentConfig; break;
				case "HKEY_LOCAL_MACHINE":
					regRoot = Registry.LocalMachine; break;
				case "HKEY_USERS":
					regRoot = Registry.Users; break;

				default: return null; //invalid root
			}

			regPath.RemoveAt(0);

			string subkey = regPath[0];
			regPath.RemoveAt(0);
			return OpenSubKey(regRoot, subkey, openWithWriteAccess, regPath);
		}


		private RegistryKey OpenSubKey(RegistryKey parengtKey, string supKeyName, bool openForWriting, List<string> keyList)
		{	
			RegistryKey current;

			bool WriteAccess = false;

			if (keyList == null || keyList.Count < 1)
			{	//only open the last key with write access if that is what the caller wants
				WriteAccess = openForWriting;
			}
			//todo: find out if you need to close the key again
			current = parengtKey.OpenSubKey(supKeyName, WriteAccess);

			if (keyList == null || keyList.Count < 1 || current == null)
			{
				return current;
			}

			string NextSubkey = keyList[0];
			keyList.RemoveAt(0);
			return OpenSubKey(current, NextSubkey, openForWriting, keyList);
		}

		private Dictionary<string, string> GetRegistryKeyValues(RegistryKey key)
		{
			if (key == null)
				return null;

			Dictionary<string, string> valueDictionary = new Dictionary<string, string>();

			foreach (string valueName in key.GetValueNames())
			{
				valueDictionary.Add(valueName, key.GetValue(valueName).ToString());
				Console.WriteLine("{0,-8}: {1}", valueName,
					key.GetValue(valueName).ToString());
			}

			return valueDictionary;
		}
	}
}

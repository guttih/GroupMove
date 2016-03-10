using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
	}
}

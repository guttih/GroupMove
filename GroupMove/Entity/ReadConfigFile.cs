using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupMove.Entity
{
	public class ReadConfigFile
	{
		private string Filename { get; set; }
		private ReadConfigFile() { }
		public string ReadSection { get; set; }
		private List<string> sections = new List<string>();
		public IDictionary<string, string> ValuesDictionary = new Dictionary<string, string>();
		public ReadConfigFile(string filename)
		{
			Filename = filename;
			ReadSection = "GroupMove.Properties.Settings";
			sections.Add("userSettings");
			sections.Add("applicationSettings");
		}

		/// <summary>
		/// Parses the config file and loads its settings
		/// </summary>
		public bool Load()
		{	ValuesDictionary.Clear();
			return Load(Filename);
		}
		//Parses a config file and loads its settings

		private bool Load(string filename)
		{
			Boolean success = false;
			System.Xml.Linq.XElement xml = null;
			try
			{
				string text = System.IO.File.ReadAllText(filename);
				xml = System.Xml.Linq.XElement.Parse(text);
			}
			catch
			{
				//Pokemon catch statement (gotta catch 'em all)

				//If some exception occurs while loading the file,
				//assume either the file was unable to be read or
				//the config file is not in the right format.
				//The xml variable will be null and none of the
				//settings will be loaded.
				return success;
			}

			if (xml != null)
			{
				foreach (System.Xml.Linq.XElement currentElement in xml.Elements())
				{
					if (sections.Contains(currentElement.Name.LocalName))
					{
						foreach (System.Xml.Linq.XElement settingNamespace in currentElement.Elements())
						{
							if (settingNamespace.Name.LocalName == ReadSection)
							{
								foreach (System.Xml.Linq.XElement setting in settingNamespace.Elements())
								{
									// we consider one success a success
									if (success == false)
										success = LoadSetting(setting);
									else
										LoadSetting(setting);
								}
							}
						}
					}
				}
			}
			return success;
		}

		/// <summary>
		/// Loads a setting based on it's xml representation in the config file
		/// </summary>
		/// <param name="setting"></param>
		private bool LoadSetting(System.Xml.Linq.XElement setting)
		{
			bool success = false;
			string name = null, type = null, value = null;

			if (setting.Name.LocalName == "setting")
			{
				System.Xml.Linq.XAttribute xName = setting.Attribute("name");
				if (xName != null)
				{
					name = xName.Value;
				}

				System.Xml.Linq.XAttribute xSerialize = setting.Attribute("serializeAs");
				if (xSerialize != null)
				{
					type = xSerialize.Value;
				}

				System.Xml.Linq.XElement xValue = setting.Element("value");
				if (xValue != null)
				{
					value = xValue.Value;
				}
			}


			if (string.IsNullOrEmpty(name) == false &&
				string.IsNullOrEmpty(type) == false &&
				string.IsNullOrEmpty(value) == false)
			{
				try
				{
					ValuesDictionary.Add(name, value);
					success = true;
				}
				catch (Exception)
				{
					//eat this
				}
				

				
			}
			return success;
		}
	}

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bugmine.Core.Configuration
{
	/// <summary>
	/// Contains reference to the application data
	/// </summary>
	public class ApplicationData
	{
		private const string _settingsFileName = "settings.xml";

		private ApplicationData()
		{
			Initialize();
		}

		private static ApplicationData _appData;

		public static ApplicationData Current
		{
			get
			{
				if (_appData == null)
				{
					_appData = new ApplicationData();
				}

				return _appData;
			}
		}

		private void Initialize()
		{
			var settingFile = GetSettingsFilePath();
			if (!File.Exists(settingFile))
			{
				XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
																				new XElement("Settings", new XElement("ApiKey", string.Empty)));

				doc.Save(settingFile);
			}
		}

		public string GetApiKey()
		{
			return string.Empty;
		}

		public void SetApiKey(string key)
		{
			var doc = GetSettingsDocument();
			doc.Root.Element("ApiKey").SetValue(key);
			
			doc.Save(GetSettingsFilePath());
		}

		private XDocument GetSettingsDocument()
		{
			return XDocument.Load(GetSettingsFilePath());
		}

		private string GetSettingsFilePath()
		{
			var settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bugmine");
			if (!Directory.Exists(settingsDirectory))
				Directory.CreateDirectory(settingsDirectory);

			var settingFile = Path.Combine(settingsDirectory, _settingsFileName);

			return settingFile;
		}
	}
}

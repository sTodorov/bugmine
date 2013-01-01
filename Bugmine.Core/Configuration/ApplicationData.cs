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
	public static class ApplicationData
	{
		private const string _settingsFileName = "settings.xml";


		public static void Initialize()
		{
			var settingFile = GetSettingsFilePath();
			if (!File.Exists(settingFile))
			{
				XDocument doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
																				new XElement("Settings", new XElement("ApiKey", string.Empty),
																																new XElement("UserID", string.Empty)));

				doc.Save(settingFile);
			}
		}

		public static string GetApiKey()
		{
			var doc = GetSettingsDocument();

			var userElement = doc.Element("Settings").Element("ApiKey");
			if (userElement == null) throw new InvalidOperationException("Api key element is not defined");

			return userElement.Value;
		}

		public static void SetApiKey(string key)
		{
			var doc = GetSettingsDocument();
			doc.Root.Element("ApiKey").SetValue(key);

			doc.Save(GetSettingsFilePath());
		}

		private static XDocument GetSettingsDocument()
		{
			return XDocument.Load(GetSettingsFilePath());
		}

		private static string GetSettingsFilePath()
		{
			var settingsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Bugmine");
			if (!Directory.Exists(settingsDirectory))
				Directory.CreateDirectory(settingsDirectory);

			var settingFile = Path.Combine(settingsDirectory, _settingsFileName);

			return settingFile;
		}

		public static void SetUserID(int userID)
		{
			var doc = GetSettingsDocument();
			doc.Root.Element("UserID").SetValue(userID);

			doc.Save(GetSettingsFilePath());
		}

		public static int GetUserID()
		{
			var doc = GetSettingsDocument();

			var userElement = doc.Element("Settings").Element("UserID");
			if (userElement == null) throw new InvalidOperationException("UserID element is not defined");
			int userID = 0;

			if (!int.TryParse(userElement.Value, out userID))
			{
				throw new InvalidCastException("UserID can't be cast to a number");
			}

			return userID;
		}
	}
}

using Fiddler;

namespace FiddlerPlugin.Configuration
{
	public class FiddlerPreferences
	{
		private const string PreferenceKeyEnabled = "extensions.sitecatalyst2.enabled";
		private const string PreferenceKeyHideNonSiteCatalyst = "extensions.sitecatalyst2.hideNonSC";
		private const string PreferenceKeyEntryBackground = "extensions.sitecatalyst2.entryBg";
		private const string PreferenceKeyEntryText = "extensions.sitecatalyst2.entryText";

		public const string DefaultEntryBackgroundColor = "#F5BCF5";
		public const string DefaultEntryTextColor = "#000000";

		public bool Enabled
		{
			get { return GetPreference(PreferenceKeyEnabled, false); }
			set { SetPreference(PreferenceKeyEnabled, value); }
		}

		public bool HideNonSiteCatalyst
		{
			get { return GetPreference(PreferenceKeyHideNonSiteCatalyst, false); }
			set { SetPreference(PreferenceKeyHideNonSiteCatalyst, value); }
		}

		public string EntryBackgroundColor
		{
			get { return GetPreference(PreferenceKeyEntryBackground, DefaultEntryBackgroundColor); }
			set { SetPreference(PreferenceKeyEntryBackground, value); }
		}

		public string EntryTextColor
		{
			get { return GetPreference(PreferenceKeyEntryText, DefaultEntryTextColor); }
			set { SetPreference(PreferenceKeyEntryText, value); }
		}

		private bool GetPreference(string key, bool defaultValue)
		{
			return FiddlerApplication.Prefs.GetBoolPref(key, defaultValue);
		}

		private void SetPreference(string key, bool value)
		{
			FiddlerApplication.Prefs.SetBoolPref(key, value);
		}

		private string GetPreference(string key, string defaultValue)
		{
			return FiddlerApplication.Prefs.GetStringPref(key, defaultValue);
		}

		private void SetPreference(string key, string value)
		{
			FiddlerApplication.Prefs.SetStringPref(key, value);
		}
	}
}

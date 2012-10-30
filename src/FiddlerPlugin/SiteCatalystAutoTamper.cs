using System;
using Fiddler;
using FiddlerPlugin.Configuration;
using FiddlerPlugin.Helpers;
using FiddlerPlugin.Models;
using FiddlerPlugin.UI;

[assembly: Fiddler.RequiredVersion("2.3.1.0")]

namespace FiddlerPlugin
{
	public class SiteCatalystAutoTamper : IAutoTamper2
	{
		

		public void OnLoad()
		{
			Log("OnLoad");

			SiteCatalystMenu menu = new SiteCatalystMenu(FiddlerApplication.UI);

			FiddlerApplication.UI.mnuMain.MenuItems.Add(menu);
		}

		private void Log(string message)
		{
			FiddlerApplication.Log.LogString(string.Format("SiteCatalystAutoTamper: {0}", message));
		}

		private FiddlerPreferences GetPreferences()
		{
			return new FiddlerPreferences();
		}

		public void OnBeforeUnload(){}

		public void OnBeforeReturningError(Session session) { }

		public void OnPeekAtResponseHeaders(Session session)
		{
			Log("OnPeekAtResponseHeaders");

			if (!GetPreferences().Enabled)
			{
				return;
			}

			Log(session.fullUrl);

			// Decode requests, mainly to handle HTTPS
			try
			{
				//session.utilDecodeRequest();
				//session.utilDecodeResponse();
			}
			catch (Exception)
			{
			}

			SiteCatalystSessionParser sessionParser = new SiteCatalystSessionParser();

			// The parser will return null if it's not a valid
			// sitecatalyst request.
			SiteCatalystRequest request = sessionParser.ParseRequest(session);
			Log("ParseRequest");

			if (request != null)
			{
				Log("Valid SiteCatalystRequest");

				session["ui-backcolor"] = GetPreferences().EntryBackgroundColor;
				session["ui-color"] = GetPreferences().EntryTextColor;

				// Code will be added here to log to a data provider
			}
			else if (GetPreferences().HideNonSiteCatalyst)
			{
				Log("Hiding Session");
				session["ui-hide"] = "yes";
			}
		}

		public void AutoTamperRequestBefore(Session oSession) { }
		public void AutoTamperRequestAfter(Session oSession) { }
		public void AutoTamperResponseBefore(Session oSession) { }
		public void AutoTamperResponseAfter(Session oSession) { }
	}
}

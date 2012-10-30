using System;
using System.Windows.Forms;
using Fiddler;
using FiddlerPlugin.Configuration;

namespace FiddlerPlugin.UI
{
	public class SiteCatalystMenu : MenuItem
	{
		private MenuItem _menuItemEnable;
		private MenuItem _menuItemHideNonSiteCatalyst;
		private MenuItem _menuItemColorOptions;
		private IWin32Window _window;

		public SiteCatalystMenu(IWin32Window window)
		{
			try
			{
				_window = window;

				LoadMenuItems();
			}
			catch (Exception ex)
			{
				Log(ex.Message);
			}
		}

		private void Log(string message)
		{
			FiddlerApplication.Log.LogString(string.Format("SiteCatalystMenu: {0}", message));
		}

		private FiddlerPreferences GetPreferences()
		{
			return new FiddlerPreferences();
		}

		public void LoadMenuItems()
		{
			Log("LoadMenuItems");
			Text = "SiteCatalyst";
			Index = 0;

			LoadEnableMenuItem();
			LoadHideNonSiteCatalystMenuItem();
			LoadColorOptionsMenuItem();
		}

		private void LoadEnableMenuItem()
		{
			Log("LoadEnableMenuItem");
			
			_menuItemEnable = new MenuItem("&Enabled") { Index = 0 };
			_menuItemEnable.Click += MenuItemEnableOnClick;
			_menuItemEnable.Checked = GetPreferences().Enabled;

			MenuItems.Add(0, _menuItemEnable);
		}

		private void LoadHideNonSiteCatalystMenuItem()
		{
			Log("LoadHideNonSiteCatalystMenuItem");
			
			_menuItemHideNonSiteCatalyst = new MenuItem("&Hide non-SiteCatalyst Entries") { Index = 1 };
			_menuItemHideNonSiteCatalyst.Click += MenuItemHideNonSiteCatalystOnClick;
			_menuItemHideNonSiteCatalyst.Checked = GetPreferences().HideNonSiteCatalyst;

			MenuItems.Add(_menuItemHideNonSiteCatalyst);
		}

		private void LoadColorOptionsMenuItem()
		{
			Log("LoadColorOptionsMenuItem");

			_menuItemColorOptions = new MenuItem("&Color options") { Index = 2 };
			_menuItemColorOptions.Click += MenuItemColorOptionsOnClick;
			MenuItems.Add(_menuItemColorOptions);
		}

		private void MenuItemEnableOnClick(object sender, EventArgs eventArgs)
		{
			_menuItemEnable.Checked = !_menuItemEnable.Checked;
			GetPreferences().Enabled = _menuItemEnable.Checked;
		}

		private void MenuItemHideNonSiteCatalystOnClick(object sender, EventArgs eventArgs)
		{
			_menuItemHideNonSiteCatalyst.Checked = !_menuItemHideNonSiteCatalyst.Checked;
			GetPreferences().HideNonSiteCatalyst = _menuItemHideNonSiteCatalyst.Checked;
		}

		private void MenuItemColorOptionsOnClick(object sender, EventArgs eventArgs)
		{
			using (OptionsDialog dialog = new OptionsDialog())
			{
				dialog.ShowDialog(_window);
			}
		}
	}
}
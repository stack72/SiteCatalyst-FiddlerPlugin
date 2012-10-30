using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using FiddlerPlugin.Configuration;
using Microsoft.Win32;

namespace FiddlerPlugin.UI
{
	public partial class OptionsDialog : Form
	{
		private readonly FiddlerPreferences _preferences = new FiddlerPreferences();
		private readonly Regex _hexColorExpression = new Regex("^#(?:[0-9a-fA-F]{3}){1,2}$", RegexOptions.IgnoreCase);

		public OptionsDialog()
		{
			InitializeComponent();
		}

		private void OptionsDialog_Load(object sender, EventArgs e)
		{
			textRowColor.Text = _preferences.EntryBackgroundColor;
			textRowTextColor.Text = _preferences.EntryTextColor;
		}

		private void textColor_TextChanged(object sender, EventArgs e)
		{
			TextBox textbox = sender as TextBox;
			if (textbox == null) return;

			textbox.BackColor = !IsValidHexColor(textbox.Text) ? Color.Red : Color.Empty;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SavePreferences();
		}

		private void btnDefaults_Click(object sender, EventArgs e)
		{
			textRowColor.Text = FiddlerPreferences.DefaultEntryBackgroundColor;
			textRowTextColor.Text = FiddlerPreferences.DefaultEntryTextColor;

			SavePreferences();
		}

		private void SavePreferences()
		{
			if (!IsValidHexColor(textRowColor.Text) || !IsValidHexColor(textRowTextColor.Text))
			{
				ShowInvalidColorMessage();
				return;
			}

			_preferences.EntryBackgroundColor = textRowColor.Text;
			_preferences.EntryTextColor = textRowTextColor.Text;

			MessageBox.Show(this, "Colors saved successfully!", "Saved");

			Close();
		}

		private bool IsValidHexColor(string color)
		{
			return (!string.IsNullOrEmpty(color) && _hexColorExpression.IsMatch(color));
		}

		private void ShowInvalidColorMessage()
		{
			MessageBox.Show(this, "A valid hex color needs to be set for the Row Entry Color. Example: #000000", "Invalid Hex Color");
		}
	}
}
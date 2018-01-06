using System;
using System.Windows.Forms;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	public partial class OptionsForm : Form {
		public OptionsForm() {
			InitializeComponent();

			LoadSettings();
		}

		private static readonly string[] Calendars = new string[]
		{
			"ChineseLunisolarCalendar",
			"GregorianCalendar",
			"HebrewCalendar",
			"HijriCalendar",
			"JapaneseCalendar",
			"JapaneseLunisolarCalendar",
			"JulianCalendar",
			"KoreanCalendar",
			"KoreanLunisolarCalendar",
			"PersianCalendar",
			"TaiwanCalendar",
			"TaiwanLunisolarCalendar",
			"ThaiBuddhistCalendar",
			"UmAlQuraCalendar"
		};

		private void UpdateButtonsEnabledProperty() {
			formatDateTimePanel.Enabled = formatDateTimeCheckBox.Checked;
		}

		private void LoadSettings() {
			formatDateTimeCheckBox.Checked = Settings.Default.FormatDateTime;

			calendarComboBox.SelectedIndex = -1;
			for (int i = 0; i < Calendars.Length; i++) {
				if (Settings.Default.Calendar == Calendars[i]) {
					calendarComboBox.SelectedIndex = i;
					break;
				}
			}

			dateTimePatternTextBox.Text = Settings.Default.DateTimePattern;

			UpdateButtonsEnabledProperty();
		}

		private void SaveSettings() {
			Settings.Default.FormatDateTime = formatDateTimeCheckBox.Checked;

			if (calendarComboBox.SelectedIndex >= 0) {
				Settings.Default.Calendar = Calendars[calendarComboBox.SelectedIndex];
			}
			else {
				Settings.Default.Calendar = string.Empty;
			}

			Settings.Default.DateTimePattern = dateTimePatternTextBox.Text;

			Settings.Default.Save();
		}

		private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (DialogResult == DialogResult.OK) {
				SaveSettings();
			}
		}

		private void formatDateTimeCheckBox_CheckedChanged(object sender, EventArgs e) {
			UpdateButtonsEnabledProperty();
		}
	}
}

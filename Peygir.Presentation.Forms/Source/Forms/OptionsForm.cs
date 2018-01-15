using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class OptionsForm : Form {
		public OptionsForm() {
			InitializeComponent();

			LoadSettings();
		}

		private static readonly string[] Calendars = new[] {
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

		private Font GetFont(TextBox box) {
			string[] parts = box.Text.Split(' ');
			var lastPart = parts.Last();
			if (lastPart.EndsWith("pt")) {
				return new Font(
					string.Join(" ", parts.Take(parts.Length - 1)),
					float.Parse(lastPart.Remove(lastPart.Length - 2)),
					GraphicsUnit.Point);
			}
			// We end with a style
			parts = parts.Take(parts.Length - 1).ToArray();
			var size = parts.Last();
			return new Font(
				string.Join(" ", parts.Take(parts.Length - 1)),
				float.Parse(size.Remove(size.Length - 2)),
				(FontStyle)Enum.Parse(typeof(FontStyle), lastPart.Substring(1, lastPart.Length - 2)),
				GraphicsUnit.Point);
		}

		private string FormatFont(Font font) {
			if (font.Style != FontStyle.Regular) {
				return $"{font.Name} {font.SizeInPoints}pt ({font.Style})";
			}
			return $"{font.Name} {font.SizeInPoints}pt";
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

			var context = FormUtil.GetFontContext();
			sansSerifTextBox.Text = FormatFont(context.SansSerif);
			monospaceTextBox.Text = FormatFont(context.Monospace);
			wordWrapCheckBox.Checked = context.WordWrap;
			if (context.UseSansSerif) {
				sansSerifRadioButton.Checked = true;
			}
			else {
				monospaceRadioButton.Checked = true;
			}

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
			var monospace = GetFont(monospaceTextBox);
			Settings.Default.MonospaceFont = monospace.Name;
			Settings.Default.MonospaceFontSize = monospace.SizeInPoints;
			Settings.Default.MonospaceFontStyle = monospace.Style;
			var sansSerif = GetFont(sansSerifTextBox);
			Settings.Default.SansSerifFont = sansSerif.Name;
			Settings.Default.SansSerifFontSize = sansSerif.SizeInPoints;
			Settings.Default.SansSerifFontStyle = sansSerif.Style;
			
			Settings.Default.UseSansSerifDefault = sansSerifRadioButton.Checked;
			Settings.Default.WordWrapDefault = wordWrapCheckBox.Checked;

			Settings.Default.Save();
		}

		private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (DialogResult != DialogResult.OK) return;
			SaveSettings();
		}

		private void formatDateTimeCheckBox_CheckedChanged(object sender, EventArgs e) {
			UpdateButtonsEnabledProperty();
		}

		private void textBox2_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void dateTimePatternTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void sansSerifButton_Click(object sender, EventArgs e) {
			ResetFont(sansSerifTextBox);
		}

		private void monospaceButton_Click(object sender, EventArgs e) {
			ResetFont(monospaceTextBox);
		}

		private void ResetFont(TextBox box) {
			using (var form = new FontDialog()) {
				form.Font = GetFont(box);
				form.FontMustExist = true;
				form.ShowColor = false;
				form.ShowEffects = false;
				if (form.ShowDialog() != DialogResult.OK) return;

				box.Text = FormatFont(form.Font);
			}
		}
	}
}

using System;
using System.Windows.Forms;

namespace Peygir.Presentation.Forms {
	public partial class DateRangeForm : Form {
		public DateRange Range { get; private set; }
		private bool mInitialLoad = false;

		public DateRangeForm(DateRange range, string kind) {
			InitializeComponent();

			mInitialLoad = true;
			Text = "Date Range - " + kind;
			Range = range;
			if (range != null) {
				if (range.LowBound != null) {
					lowBoundCheckbox.Checked = true;
					lowDateTimePicker.Enabled = true;
					lowDateTimePicker.Value = range.LowBound.Value.ToLocalTime();
				}
				else {
					lowDateTimePicker.Value = DateTime.Now;
				}
				if (range.HighBound != null) {
					highBoundCheckbox.Checked = true;
					highDateTimePicker.Enabled = true;
					highDateTimePicker.Value = range.HighBound.Value.ToLocalTime();
				}
				else {
					highDateTimePicker.Value = DateTime.Now;
				}
			}
			else {
				lowDateTimePicker.Value = DateTime.Now;
				highDateTimePicker.Value = DateTime.Now;
			}
			mInitialLoad = false;
		}

		private void lowBoundCheckbox_CheckedChanged(object sender, EventArgs e) {
			if (mInitialLoad)
				return;
			lowDateTimePicker.Enabled = lowBoundCheckbox.Checked;

			Range = DateRange.Normalize(
				lowBoundCheckbox.Checked,
				lowDateTimePicker.Value,
				Range?.HighBound);
		}

		private void highBoundCheckbox_CheckedChanged(object sender, EventArgs e) {
			if (mInitialLoad)
				return;
			highDateTimePicker.Enabled = highBoundCheckbox.Checked;

			Range = DateRange.Normalize(
				Range?.LowBound,
				highBoundCheckbox.Checked,
				highDateTimePicker.Value);
		}

		private void lowDateTimePicker_ValueChanged(object sender, EventArgs e) {
			if (mInitialLoad)
				return;
			Range = DateRange.Normalize(lowDateTimePicker.Value, Range?.HighBound);
		}

		private void highDateTimePicker_ValueChanged(object sender, EventArgs e) {
			if (mInitialLoad)
				return;
			Range = DateRange.Normalize(Range?.LowBound, highDateTimePicker.Value);
		}
	}
}

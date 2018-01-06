using System;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class TicketHistoryDetailsUserControl : UserControl {
		private bool readOnly;

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public TicketHistoryDetailsUserControl() {
			InitializeComponent();

			ReadOnly = false;
		}

		public void Clear() {
			timestampTextBox.Text = string.Empty;
			changesTextBox.Text = string.Empty;
			commentTextBox.Text = string.Empty;
		}

		public void ShowTicketHistory(TicketHistory ticketHistory, DateTimeFormatter formatter) {
			if (ticketHistory == null) {
				throw new ArgumentNullException(nameof(ticketHistory));
			}
			if (formatter == null) {
				throw new ArgumentNullException(nameof(formatter));
			}

			timestampTextBox.Text = formatter.Format(ticketHistory.Timestamp);
			changesTextBox.Text = ticketHistory.Changes;
			commentTextBox.Text = ticketHistory.Comment;
		}

		public void RetrieveTicketHistory(TicketHistory ticketHistory) {
			if (ticketHistory == null) {
				throw new ArgumentNullException(nameof(ticketHistory));
			}

			// Nothing.
		}

		private void UpdateReadOnlyState() {
			// Nothing.
		}

		private void changesTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void timestampTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void commentTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}
	}
}

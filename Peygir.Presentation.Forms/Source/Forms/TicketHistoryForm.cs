using System;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class TicketHistoryForm : Form {
		private FormContext mContext = null;
		private Ticket mTicket = null;

		public TicketHistoryForm(FormContext context, Ticket ticket) {
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (ticket == null) throw new ArgumentNullException(nameof(ticket));

			mContext = context;
			mTicket = ticket;

			InitializeComponent();

			ShowTicketHistory();

			// Select last history.
			if (ticketHistoryListView.Items.Count > 0) {
				ticketHistoryListView.SelectedIndices.Clear();
				ticketHistoryListView.SelectedIndices.Add(0);
			}
		}

		private void ShowTicketHistory() {
			TicketHistory[] history = mTicket.GetHistory(mContext);
			var formatter = FormUtil.GetFormatter();

			ticketHistoryListView.BeginUpdate();
			ticketHistoryListView.Items.Clear();
			foreach (var th in history) {
				var lvi = new ListViewItem() {
					Text = formatter.Format(th.Timestamp),
					Tag = th,
				};

				ticketHistoryListView.Items.Add(lvi);
			}

			ticketHistoryListView.EndUpdate();
			ticketHistoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			ticketHistoryListView.Columns[0].Width -= 4;

			ShowTicketHistoryDetails();
		}

		private void ShowTicketHistoryDetails() {
			if (ticketHistoryListView.SelectedItems.Count == 1) {
				var tag = (TicketHistory)ticketHistoryListView.SelectedItems[0].Tag;

				var formatter = FormUtil.GetFormatter();
				timestampTextBox.Text = formatter.Format(tag.Timestamp);
				changesTextBox.Text = tag.Changes;
				commentTextBox.Text = tag.Comment;

				groupBox.Enabled = true;
			}
			else {
				timestampTextBox.Text = string.Empty;
				changesTextBox.Text = string.Empty;
				commentTextBox.Text = string.Empty;

				groupBox.Enabled = false;
			}
		}

		private void ticketHistoryListView_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTicketHistoryDetails();
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

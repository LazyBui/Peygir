﻿using System;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class TicketHistoryForm : Form {
		public Ticket Ticket { get; private set; }

		public TicketHistoryForm(Ticket ticket) {
			if (ticket == null) throw new ArgumentNullException(nameof(ticket));

			Ticket = ticket;

			InitializeComponent();

			ShowTicketHistory();

			// Select last history.
			if (ticketHistoryListView.Items.Count > 0) {
				ticketHistoryListView.SelectedIndices.Clear();
				ticketHistoryListView.SelectedIndices.Add(0);
			}
		}

		private void ShowTicketHistory() {
			TicketHistory[] history = Ticket.GetHistory();
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
				var history = (TicketHistory)ticketHistoryListView.SelectedItems[0].Tag;

				var formatter = FormUtil.GetFormatter();
				timestampTextBox.Text = formatter.Format(history.Timestamp);
				changesTextBox.Text = history.Changes;
				commentTextBox.Text = history.Comment;

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

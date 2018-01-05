﻿using System;
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

		public DateTimeFormatter DateTimeFormatter { get; set; }

		public TicketHistoryDetailsUserControl() {
			InitializeComponent();

			ReadOnly = false;
		}

		public void Clear() {
			timestampTextBox.Text = string.Empty;
			changesTextBox.Text = string.Empty;
			commentTextBox.Text = string.Empty;
		}

		public void ShowTicketHistory(TicketHistory ticketHistory) {
			if (ticketHistory == null) {
				throw new ArgumentNullException("ticketHistory");
			}

			if (DateTimeFormatter != null) {
				timestampTextBox.Text = DateTimeFormatter.Format(ticketHistory.Timestamp);
			}
			else {
				timestampTextBox.Text = string.Format("{0}", ticketHistory.Timestamp);
			}
			changesTextBox.Text = ticketHistory.Changes;
			commentTextBox.Text = ticketHistory.Comment;
		}

		public void RetrieveTicketHistory(TicketHistory ticketHistory) {
			if (ticketHistory == null) {
				throw new ArgumentNullException("ticketHistory");
			}

			// Nothing.
		}

		private void UpdateReadOnlyState() {
			// Nothing.
		}
	}
}

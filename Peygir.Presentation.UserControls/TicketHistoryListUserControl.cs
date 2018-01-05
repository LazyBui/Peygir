using System;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class TicketHistoryListUserControl : UserControl {
		public ListView TicketHistoryListView {
			get { return ticketHistoryListView; }
		}

		public TicketHistoryListUserControl() {
			InitializeComponent();
		}

		public void ShowTicketHistory(TicketHistory[] ticketHistory, DateTimeFormatter formatter) {
			if (ticketHistory == null) {
				throw new ArgumentNullException(nameof(ticketHistory));
			}
			if (formatter == null) {
				throw new ArgumentNullException(nameof(formatter));
			}

			ticketHistoryListView.BeginUpdate();

			ticketHistoryListView.Items.Clear();
			foreach (var th in ticketHistory) {
				ListViewItem lvi = new ListViewItem();

				lvi.Text = formatter.Format(th.Timestamp);
				lvi.Tag = th;

				ticketHistoryListView.Items.Add(lvi);
			}

			ticketHistoryListView.EndUpdate();

			ticketHistoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			ticketHistoryListView.Columns[0].Width -= 4;
		}
	}
}

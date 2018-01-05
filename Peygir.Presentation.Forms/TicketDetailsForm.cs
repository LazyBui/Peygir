using System.Windows.Forms;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class TicketDetailsForm : Form {
		public TicketDetailsUserControl TicketDetailsUserControl {
			get { return ticketDetailsUserControl; }
		}

		public TicketDetailsForm() {
			InitializeComponent();
		}
	}
}

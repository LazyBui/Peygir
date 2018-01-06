using System;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class TicketDetailsForm : Form {
		public Project Project { get; private set; }
		public Ticket Ticket { get; private set; }

		public TicketDetailsUserControl TicketDetailsUserControl {
			get { return ticketDetailsUserControl; }
		}

		public TicketDetailsForm(Project project, Ticket ticket) {
			if (project == null) throw new ArgumentNullException(nameof(project));

			Project = project;
			Ticket = ticket;
			InitializeComponent();

			if (object.ReferenceEquals(ticket, null)) {
				Text = project.Name + " - New Ticket";
			}
			else {
				Text = project.Name + " - " + ticket.Summary;
			}
		}
	}
}

using System;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class ProjectsListUserControl : UserControl {
		public ListView ProjectsListView {
			get { return projectsListView; }
		}

		public ProjectsListUserControl() {
			InitializeComponent();
		}

		public void ShowProjects(Project[] projects, DateTimeFormatter formatter) {
			if (projects == null) throw new ArgumentNullException(nameof(projects));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));

			projectsListView.BeginUpdate();

			projectsListView.Items.Clear();
			foreach (var project in projects) {
				var tickets = project.GetTickets();
				var lvi = new ListViewItem(new[] {
					project.Name,
					tickets.Any() ?
						formatter.Format(tickets.Min(t => t.CreateTimestamp)) :
						string.Empty,
					tickets.Any() ?
						formatter.Format(tickets.Max(t => t.ModifyTimestamp)) :
						string.Empty,
					tickets.Count(t => t.State.IsOpen()).ToString(),
					tickets.Count().ToString(),
				}) {
					Tag = project,
				};

				projectsListView.Items.Add(lvi);
			}

			const int ticketColumnSize = 65;
			const int updateColumnSize = 105;
			const int scrollbarSize = 20;
			projectsListView.Columns[0].Width =
				ProjectsListView.Width -
				(ticketColumnSize * 2) -
				(updateColumnSize * 2) -
				scrollbarSize;

			projectsListView.EndUpdate();
		}
	}
}

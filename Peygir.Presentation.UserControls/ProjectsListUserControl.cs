using System;
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

		public void ShowProjects(Project[] projects) {
			if (projects == null) {
				throw new ArgumentNullException("projects");
			}

			projectsListView.BeginUpdate();

			projectsListView.Items.Clear();
			foreach (var project in projects) {
				ListViewItem lvi = new ListViewItem();

				lvi.Text = project.Name;
				lvi.Tag = project;

				projectsListView.Items.Add(lvi);
			}

			projectsListView.EndUpdate();

			projectsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			projectsListView.Columns[0].Width -= 4;
		}
	}
}

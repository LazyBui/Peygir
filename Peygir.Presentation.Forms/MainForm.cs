using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	public partial class MainForm : Form {
		public MessageBoxOptions FormMessageBoxOptions {
			get {
				MessageBoxOptions options = (MessageBoxOptions)0;
				if (RightToLeft == System.Windows.Forms.RightToLeft.Yes) {
					options = (MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
				}
				return options;
			}
		}

		public MainForm() {
			InitializeComponent();

			projectsListUserControl.ProjectsListView.SelectedIndexChanged += ProjectsListView_SelectedIndexChanged;
			projectsListUserControl.ProjectsListView.DoubleClick += ProjectsListView_DoubleClick;
			projectsListUserControl.ProjectsListView.ContextMenuStrip = projectContextMenu;

			ShowCurrentLanguage();

			UpdateControlsEnabledProperty();
		}

		private void ShowCurrentLanguage() {
			englishToolStripMenuItem.Checked = false;
			persianToolStripMenuItem.Checked = false;

			switch (Settings.Default.Language) {
				case "en":
					englishToolStripMenuItem.Checked = true;
					break;

				case "fa":
					persianToolStripMenuItem.Checked = true;
					break;
			}
		}

		private void ChangeLanguage(string language) {
			if (language == null) {
				throw new ArgumentNullException(nameof(language));
			}

			Settings.Default.Language = language;
			Settings.Default.Save();

			ShowCurrentLanguage();

			// Don't translate this messages.
			string message = "The application should be restarted to change language."
				+ Environment.NewLine
				+ "Do you want to restart the application now?";

			DialogResult result =
			MessageBox.Show
			(
				message,
				"Peygir",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question
			);

			// Restart.
			if (result == System.Windows.Forms.DialogResult.Yes) {
				Application.Restart();
			}
		}

		private void UpdateControlsEnabledProperty() {
			if (string.IsNullOrEmpty(Database.CurrentDatabasePath)) {
				saveDatabaseAsToolStripMenuItem.Enabled = false;
				closeDatabaseToolStripMenuItem.Enabled = false;

				addProjectButton.Enabled = false;
				editProjectButton.Enabled = false;
				editTicketsButton.Enabled = false;
				deleteProjectButton.Enabled = false;

				projectsGroupBox.Enabled = false;
			}
			else {
				saveDatabaseAsToolStripMenuItem.Enabled = true;
				closeDatabaseToolStripMenuItem.Enabled = true;

				int selectedProjectsCount = projectsListUserControl.ProjectsListView.SelectedItems.Count;
				if (selectedProjectsCount == 0) {
					addProjectButton.Enabled = true;
					editProjectButton.Enabled = false;
					editTicketsButton.Enabled = false;
					deleteProjectButton.Enabled = false;
				}
				else if (selectedProjectsCount == 1) {
					addProjectButton.Enabled = true;
					editProjectButton.Enabled = true;
					editTicketsButton.Enabled = true;
					deleteProjectButton.Enabled = true;
				}
				else {
					addProjectButton.Enabled = true;
					editProjectButton.Enabled = false;
					editTicketsButton.Enabled = false;
					deleteProjectButton.Enabled = true;
				}

				projectsGroupBox.Enabled = true;
			}

			databaseToolStripStatusLabel.Text = string.Format
			(
				Resources.String_DatabaseX,
				string.IsNullOrEmpty(Database.CurrentDatabasePath) ? "-" : Database.CurrentDatabasePath
			);
		}

		private void NewDatabase() {
			saveFileDialog.FileName = string.Empty;
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				try {
					CloseDatabase();

					string databasePath = saveFileDialog.FileName;

					Environment.CurrentDirectory = Application.StartupPath;
					Database.CreateAndOpen(databasePath);

					ShowProjects();
				}
				catch (Exception exception) {
					MessageBox.Show
					(
						exception.Message,
						Resources.String_Error,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormMessageBoxOptions

					);

					CloseDatabase();
				}
			}
		}

		private void OpenDatabase() {
			openFileDialog.FileName = string.Empty;
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				try {
					CloseDatabase();

					string databasePath = openFileDialog.FileName;

					Environment.CurrentDirectory = Application.StartupPath;
					Database.Open(databasePath);

					ShowProjects();
				}
				catch (Exception exception) {
					MessageBox.Show
					(
						exception.Message,
						Resources.String_Error,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormMessageBoxOptions
					);

					CloseDatabase();
				}
			}
		}

		private void SaveDatabaseAs() {
			string currentDatabasePath = Database.CurrentDatabasePath;

			saveFileDialog.FileName = currentDatabasePath;
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				try {
					CloseDatabase();

					string newDatabasePath = saveFileDialog.FileName;

					// Copy.
					File.Copy(currentDatabasePath, newDatabasePath, true);

					Environment.CurrentDirectory = Application.StartupPath;
					Database.Open(newDatabasePath);

					ShowProjects();
				}
				catch (Exception exception) {
					MessageBox.Show
					(
						exception.Message,
						Resources.String_Error,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormMessageBoxOptions
					);

					CloseDatabase();
				}
			}
		}

		private void CloseDatabase() {
			Database.Close();

			projectsListUserControl.ProjectsListView.Items.Clear();

			UpdateControlsEnabledProperty();
		}

		private void ShowOptions() {
			OptionsForm form = new OptionsForm();
			form.ShowDialog();
		}

		private void ShowProjects() {
			// Save selected projects.
			List<int> selectedProjects = new List<int>();
			foreach (ListViewItem item in projectsListUserControl.ProjectsListView.SelectedItems) {
				Project project = (Project)item.Tag;
				selectedProjects.Add(project.ID);
			}

			Project[] projects = Project.GetProjects();

			projectsListUserControl.ShowProjects(projects);

			// Reselect projects.
			foreach (ListViewItem item in projectsListUserControl.ProjectsListView.Items) {
				Project project = (Project)item.Tag;
				if (selectedProjects.Contains(project.ID)) {
					item.Selected = true;
					item.EnsureVisible();
				}
			}

			UpdateControlsEnabledProperty();
		}

		private void AddProject() {
			Project project = new Project();
			ProjectDetailsForm form = new ProjectDetailsForm();
			form.ProjectDetailsUserControl.ShowProject(project);

			Again:
			if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				// Check name.
				if (string.IsNullOrWhiteSpace(form.ProjectDetailsUserControl.ProjectName)) {
					MessageBox.Show
					(
						Resources.String_TheProjectNameCannotBeBlank,
						Resources.String_Error,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormMessageBoxOptions
					);
					goto Again;
				}

				form.ProjectDetailsUserControl.RetrieveProject(project);

				// Add.
				project.Add();

				// Flush.
				Database.Flush();

				// Show projects.
				ShowProjects();

				// Select new project.
				projectsListUserControl.ProjectsListView.SelectedItems.Clear();
				foreach (ListViewItem item in projectsListUserControl.ProjectsListView.Items) {
					Project p = (Project)item.Tag;
					if (p.ID == project.ID) {
						item.Selected = true;
						break;
					}
				}

				UpdateControlsEnabledProperty();

				// Show edit project form.
				EditProject();

				projectsListUserControl.Focus();
			}
		}

		private void EditProject(bool ticketTab = false) {
			if (projectsListUserControl.ProjectsListView.SelectedItems.Count != 1) {
				return;
			}

			var project = (Project)projectsListUserControl.ProjectsListView.SelectedItems[0].Tag;

			var form = new ProjectForm(project);
			if (ticketTab) form.ActivateTicketTab();
			form.ShowDialog();

			ShowProjects();
		}

		private void DeleteProject() {
			if (projectsListUserControl.ProjectsListView.SelectedItems.Count > 0) {
				DialogResult result =
				MessageBox.Show
				(
					Resources.String_AreYouSureYouWantToDeleteSelectedProjects,
					Resources.String_DeleteProjects,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions
				);

				if (result != System.Windows.Forms.DialogResult.Yes) {
					return;
				}

				// Delete projects.
				for (int i = 0; i < projectsListUserControl.ProjectsListView.SelectedItems.Count; i++) {
					Project project = (Project)projectsListUserControl.ProjectsListView.SelectedItems[i].Tag;
					project.Delete();
				}

				// Flush.
				Database.Flush();

				// Show projects.
				ShowProjects();
			}
		}

		private void ShowHelp() {
			try {
				string helpPath = string.Format(Settings.Default.HelpPath, Application.StartupPath);
				Process.Start(helpPath);
			}
			catch (Exception exception) {
				MessageBox.Show
				(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions
				);
			}
		}

		private void ShowAbout() {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
			NewDatabase();
		}

		private void openDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
			OpenDatabase();
		}

		private void saveDatabaseAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveDatabaseAs();
		}

		private void closeDatabaseToolStripMenuItem_Click(object sender, EventArgs e) {
			CloseDatabase();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Close();
		}

		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowOptions();
		}

		private void ProjectsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateControlsEnabledProperty();
		}

		private void ProjectsListView_DoubleClick(object sender, EventArgs e) {
			EditProject(ticketTab: true);
		}

		#region Project modification UI
		#region Buttons
		private void addProjectButton_Click(object sender, EventArgs e) {
			AddProject();
		}

		private void editProjectButton_Click(object sender, EventArgs e) {
			EditProject();
		}

		private void editTicketsButton_Click(object sender, EventArgs e) {
			EditProject(ticketTab: true);
		}

		private void deleteProjectButton_Click(object sender, EventArgs e) {
			DeleteProject();
		}
		#endregion

		#region Context menu
		private void projectContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			int selectedProjectsCount = projectsListUserControl.ProjectsListView.SelectedItems.Count;
			if (selectedProjectsCount == 0) {
				addProjectToolStripMenuItem.Enabled = true;
				editProjectToolStripMenuItem.Enabled = false;
				editTicketsToolStripMenuItem.Enabled = false;
				deleteProjectToolStripMenuItem.Enabled = false;
			}
			else if (selectedProjectsCount == 1) {
				addProjectToolStripMenuItem.Enabled = true;
				editProjectToolStripMenuItem.Enabled = true;
				editTicketsToolStripMenuItem.Enabled = true;
				deleteProjectToolStripMenuItem.Enabled = true;
			}
			else {
				addProjectToolStripMenuItem.Enabled = true;
				editProjectToolStripMenuItem.Enabled = false;
				editTicketsToolStripMenuItem.Enabled = false;
				deleteProjectToolStripMenuItem.Enabled = true;
			}

		}
		private void addProjectToolStripMenuItem_Click(object sender, EventArgs e) {
			AddProject();
		}

		private void editProjectToolStripMenuItem_Click(object sender, EventArgs e) {
			EditProject();
		}

		private void editTicketsToolStripMenuItem_Click(object sender, EventArgs e) {
			EditProject(ticketTab: true);
		}

		private void deleteProjectToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteProject();
		}
		#endregion
		#endregion

		private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowHelp();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowAbout();
		}

		private void englishToolStripMenuItem_Click(object sender, EventArgs e) {
			ChangeLanguage("en");
		}

		private void persianToolStripMenuItem_Click(object sender, EventArgs e) {
			ChangeLanguage("fa");
		}
	}
}

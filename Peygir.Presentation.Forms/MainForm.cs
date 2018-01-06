using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class MainForm : Form {
		private Dictionary<Project, ProjectForm> mForms = new Dictionary<Project, ProjectForm>();
		private bool mResettingFilters = false;
		private DateRange mCreateFilter = null;
		private DateRange mModifyFilter = null;

		public MessageBoxOptions FormMessageBoxOptions {
			get {
				MessageBoxOptions options = 0;
				if (RightToLeft == RightToLeft.Yes) {
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

		private void ProjectsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateControlsEnabledProperty();
		}

		private void ProjectsListView_DoubleClick(object sender, EventArgs e) {
			EditProject(ticketTab: true);
		}

		private void MainForm_Resize(object sender, EventArgs e) {
			// Resize columns
			ShowProjects();
		}

		#region Form context menu
		#region File
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
		#endregion

		#region Tools
		private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowOptions();
		}
		#endregion

		#region Help
		private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowHelp();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowAbout();
		}
		#endregion

		#region Language
		private void englishToolStripMenuItem_Click(object sender, EventArgs e) {
			ChangeLanguage("en");
		}

		private void persianToolStripMenuItem_Click(object sender, EventArgs e) {
			ChangeLanguage("fa");
		}
		#endregion
		#endregion

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
			else {
				addProjectToolStripMenuItem.Enabled = true;
				editProjectToolStripMenuItem.Enabled = true;
				editTicketsToolStripMenuItem.Enabled = true;
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

		#region Filter UI
		private void projectTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void projectTextBox_TextChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void ticketStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void ticketPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void ticketSeverityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void ticketTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void reporterComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void assignedComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void createdTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void modifiedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void createdButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mCreateFilter, "Created")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel)
					return;

				mCreateFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(createdTextBox, mCreateFilter);
				ShowProjects();
			}
		}

		private void modifiedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mModifyFilter, "Modified")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel)
					return;

				mModifyFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(modifiedTextBox, mModifyFilter);
				ShowProjects();
			}
		}

		private void resetFilterButton_Click(object sender, EventArgs e) {
			ResetFilters();
			ShowProjects();
		}
		#endregion

		#region Utility functions
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

			DialogResult result = MessageBox.Show(
				message,
				"Peygir",
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question);

			// Restart.
			if (result == DialogResult.Yes) {
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
				else {
					addProjectButton.Enabled = true;
					editProjectButton.Enabled = true;
					editTicketsButton.Enabled = true;
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
			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

			try {
				CloseDatabase();

				string databasePath = saveFileDialog.FileName;

				Environment.CurrentDirectory = Application.StartupPath;
				Database.CreateAndOpen(databasePath);

				ShowProjects();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions);

				CloseDatabase();
			}
		}

		private void OpenDatabase() {
			openFileDialog.FileName = string.Empty;
			if (openFileDialog.ShowDialog() != DialogResult.OK) return;
			try {
				if (Database.IsOpen)
					CloseDatabase();

				string databasePath = openFileDialog.FileName;

				Environment.CurrentDirectory = Application.StartupPath;
				Database.Open(databasePath);

				ShowProjects();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions);

				CloseDatabase();
			}
		}

		private void SaveDatabaseAs() {
			string currentDatabasePath = Database.CurrentDatabasePath;
			saveFileDialog.FileName = currentDatabasePath;
			if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
			try {
				Database.Close();

				string newDatabasePath = saveFileDialog.FileName;

				// Copy.
				File.Copy(currentDatabasePath, newDatabasePath, true);

				Environment.CurrentDirectory = Application.StartupPath;
				Database.Open(newDatabasePath);

				ShowProjects();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions);

				CloseDatabase();
			}
		}

		private void CloseDatabase() {
			Database.Close();
			ResetFilters();

			// ToArray to copy the forms so we can mutate the dictionary
			foreach (var form in mForms.ToArray()) {
				form.Value.Close();
			}

			projectsListUserControl.ProjectsListView.Items.Clear();

			UpdateControlsEnabledProperty();
		}

		private void ShowOptions() {
			using (var form = new OptionsForm()) {
				if (form.ShowDialog() != DialogResult.OK) return;
				if (!Database.IsOpen) return;

				// Might change date formatting, update display
				ShowProjects();

				// Update filter boxes
				FormUtil.FormatDateFilter(createdTextBox, mCreateFilter);
				FormUtil.FormatDateFilter(modifiedTextBox, mModifyFilter);

				// If there are any open forms, go through them and let them know as well
				foreach (var child in mForms) {
					child.Value.UpdateSettings();
				}
			}
		}

		private void ShowProjects() {
			if (mResettingFilters) return;

			// Save selected projects.
			List<int> selectedProjects = new List<int>();
			foreach (ListViewItem item in projectsListUserControl.ProjectsListView.SelectedItems) {
				Project project = (Project)item.Tag;
				selectedProjects.Add(project.ID);
			}

			Project[] projects = Project.GetProjects();

			string nameFilter = projectTextBox.Text;
			string reporterFilter = reportersComboBox.SelectedText;
			string assignedFilter = assignedToComboBox.SelectedText;
			var stateFilter = FormUtil.CastBox<MetaTicketState>(ticketStateComboBox);
			var severityFilter = FormUtil.CastBox<TicketSeverity>(ticketSeverityComboBox);
			var priorityFilter = FormUtil.CastBox<TicketPriority>(ticketPriorityComboBox);
			var typeFilter = FormUtil.CastBox<TicketType>(ticketTypeComboBox);

			projects = projects.Where(p => {
				bool satisfiesNameFilter = FormUtil.FilterContains(p.Name, nameFilter);
				if (!satisfiesNameFilter)
					return false;

				var tickets = p.GetTickets();
				if (!tickets.Any()) {
					// If we have any filters specified, this project can't qualify with no tickets
					// Since we're returning true if it qualifies and false if not, we need to check for the negative condition
					return !new object[] {
						reporterFilter,
						assignedFilter,
						stateFilter,
						severityFilter,
						priorityFilter,
						typeFilter,
						mCreateFilter,
						mModifyFilter,
					}.Any(v => v != null);
				}

				bool satisfiesCreatedFilter = FormUtil.FilterContains(tickets.Min(t => t.CreateTimestamp), mCreateFilter);
				bool satisfiesModifiedFilter = FormUtil.FilterContains(tickets.Max(t => t.ModifyTimestamp), mModifyFilter);
				if (!(satisfiesCreatedFilter && satisfiesModifiedFilter))
					return false;

				return tickets.Any(t => {
					bool satisfiesReporterFilter = FormUtil.FilterMatch(t.ReportedBy, reporterFilter);
					bool satisfiesAssignedFilter = FormUtil.FilterMatch(t.AssignedTo, assignedFilter);
					bool satisfiesStateFilter = stateFilter == null || stateFilter.Value.AppliesTo(t.State);
					bool satisfiesSeverityFilter = FormUtil.FilterEnum(t.Severity, severityFilter);
					bool satisfiesPriorityFilter = FormUtil.FilterEnum(t.Priority, priorityFilter);
					bool satisfiesTypeFilter = FormUtil.FilterEnum(t.Type, typeFilter);

					return
						satisfiesReporterFilter &&
						satisfiesAssignedFilter &&
						satisfiesStateFilter &&
						satisfiesSeverityFilter &&
						satisfiesPriorityFilter &&
						satisfiesTypeFilter;
				});
			}).ToArray();

			projectsListUserControl.ShowProjects(projects, FormUtil.GetFormatter());

			// Reselect projects.
			foreach (ListViewItem item in projectsListUserControl.ProjectsListView.Items) {
				Project project = (Project)item.Tag;
				if (selectedProjects.Contains(project.ID)) {
					item.Selected = true;
					item.EnsureVisible();
				}
			}

			UpdateControlsEnabledProperty();

			openTicketsToolStripStatusLabel.Text = "Open Tickets: " + projects.Sum(p => p.GetTickets().Count(t => t.State.IsOpen()));
			totalTicketsToolStripStatusLabel.Text = "Total Tickets: " + projects.Sum(p => p.GetTickets().Length);
		}

		private void AddProject() {
			Project project = new Project();
			ProjectDetailsForm form = new ProjectDetailsForm();
			form.ProjectDetailsUserControl.ShowProject(project);

			Again:
			if (form.ShowDialog() == DialogResult.OK) {
				// Check name.
				if (string.IsNullOrWhiteSpace(form.ProjectDetailsUserControl.ProjectName)) {
					MessageBox.Show(
						Resources.String_TheProjectNameCannotBeBlank,
						Resources.String_Error,
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormMessageBoxOptions);
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
			for (int i = 0, end = projectsListUserControl.ProjectsListView.SelectedItems.Count; i < end; i++) {
				var item = (Project)projectsListUserControl.ProjectsListView.SelectedItems[i].Tag;
				ProjectForm form;
				if (!mForms.TryGetValue(item, out form)) {
					form = new ProjectForm(item, this);
					mForms[item] = form;
					form.ActivateTicketTab();
					form.Show();
				}
				else {
					form.ActivateTicketTab();
					form.Activate();
				}
			}
		}

		private void DeleteProject() {
			if (projectsListUserControl.ProjectsListView.SelectedItems.Count > 0) {
				DialogResult result = MessageBox.Show(
					Resources.String_AreYouSureYouWantToDeleteSelectedProjects,
					Resources.String_DeleteProjects,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions);

				if (result != DialogResult.Yes) {
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
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions);
			}
		}

		private void ShowAbout() {
			AboutForm form = new AboutForm();
			form.ShowDialog();
		}

		private void ResetFilters() {
			mResettingFilters = true;
			projectTextBox.Text = string.Empty;
			FormUtil.SetOrDefault(assignedToComboBox);
			FormUtil.SetOrDefault(reportersComboBox);
			FormUtil.SetOrDefault(ticketPriorityComboBox);
			FormUtil.SetOrDefault(ticketSeverityComboBox);
			FormUtil.SetOrDefault(ticketStateComboBox);
			FormUtil.SetOrDefault(ticketTypeComboBox);
			mModifyFilter = null;
			modifiedTextBox.Text = string.Empty;
			mCreateFilter = null;
			createdTextBox.Text = string.Empty;
			mResettingFilters = false;
		}

		internal void CloseProjectForm(ProjectForm form) {
			ProjectForm query;
			if (mForms.TryGetValue(form.Project, out query)) {
				mForms.Remove(form.Project);
			}
		}

		internal void UpdateTicketOrProject() {
			// Update our UI elements for assigned/reported, can't populate this in ShowProjects because that would cause nightmares
			bool hadSelectedReporter = reportersComboBox.SelectedIndex != -1;
			string selectedReporterText = string.Empty;
			if (hadSelectedReporter) {
				selectedReporterText = reportersComboBox.SelectedText;
			}
			reportersComboBox.Items.Clear();
			reportersComboBox.Items.AddRange(Ticket.GetReporters());
			if (hadSelectedReporter) {
				reportersComboBox.SelectedIndex =
					new List<string>(reportersComboBox.Items.Cast<string>()).IndexOf(selectedReporterText);
			}

			bool hadSelectedAssigned = assignedToComboBox.SelectedIndex != -1;
			string selectedAssignedText = string.Empty;
			if (hadSelectedAssigned) {
				selectedAssignedText = assignedToComboBox.SelectedText;
			}
			assignedToComboBox.Items.Clear();
			assignedToComboBox.Items.AddRange(Ticket.GetAssignees());
			if (hadSelectedAssigned) {
				assignedToComboBox.SelectedIndex =
					new List<string>(assignedToComboBox.Items.Cast<string>()).IndexOf(selectedAssignedText);
			}

			// Any child should require updated filters
			foreach (var form in mForms.ToArray()) {
				form.Value.UpdateTicket();
			}

			ShowProjects();
		}
		#endregion
	}
}

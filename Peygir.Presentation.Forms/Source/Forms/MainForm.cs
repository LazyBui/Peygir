using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class MainForm : Form {
		private Dictionary<int, ProjectForm> mForms = new Dictionary<int, ProjectForm>();
		private bool mResettingProjectFilters = false;
		private DateRange mProjectCreateFilter = null;
		private DateRange mProjectModifyFilter = null;
		private bool mResettingTicketFilters = false;
		private DateRange mTicketCreateFilter = null;
		private DateRange mTicketModifyFilter = null;
		private TicketCount mProjectTicketCount = TicketCount.Empty;
		private TicketCount mTicketTicketCount = TicketCount.Empty;
		private FormContext mContext = FormContext.Default;

		private class TicketCount {
			public static readonly TicketCount Empty = new TicketCount(0, 0);

			public int Open { get; private set; }
			public int Total { get; private set; }

			public TicketCount(int open, int total) {
				if (open < 0) throw new ArgumentException("Must be 0 or greater", nameof(open));
				if (total < 0) throw new ArgumentException("Must be 0 or greater", nameof(total));
				if (open > total) throw new ArgumentException($"Must be less than {nameof(total)}", nameof(open));
				Open = open;
				Total = total;
			}
		}
		
		public MainForm() {
			InitializeComponent();
			statusStrip1.Renderer = new ClippingToolStripRenderer();

			ShowCurrentLanguage();

			UpdateControlsEnabledProperty();
		}

		private void projectsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateControlsEnabledProperty();
		}

		private void projectsListView_DoubleClick(object sender, EventArgs e) {
			EditProject(ticketTab: true);
		}

		private void projectsListView_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter)
				return;
			EditProject(ticketTab: true);
		}

		private void ticketsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateControlsEnabledProperty();
		}

		private void ticketsListView_DoubleClick(object sender, EventArgs e) {
			EditTicket();
		}

		private void ticketsListView_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter)
				return;
			EditTicket();
		}

		private void MainForm_ResizeEnd(object sender, EventArgs e) {
			// Resize columns
			ShowProjects();
			ShowTickets();
		}

		private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateStatusbar();
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
			int selectedProjectsCount = projectsListView.SelectedItems.Count;
			addProjectToolStripMenuItem.Enabled = true;
			editProjectToolStripMenuItem.Enabled = selectedProjectsCount > 0;
			editTicketsToolStripMenuItem.Enabled = selectedProjectsCount > 0;
			deleteProjectToolStripMenuItem.Enabled = selectedProjectsCount > 0;
			stateInactiveToolStripMenuItem.Enabled = selectedProjectsCount > 0;
			stateActiveToolStripMenuItem.Enabled = selectedProjectsCount > 0;
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

		private void stateInactiveToolStripMenuItem_Click(object sender, EventArgs e) {
			SetProjectState(ProjectState.Inactive);
		}

		private void stateActiveToolStripMenuItem_Click(object sender, EventArgs e) {
			SetProjectState(ProjectState.Active);
		}
		#endregion
		#endregion

		#region Ticket modification UI
		#region Buttons
		private void addTicketButton_Click(object sender, EventArgs e) {
			AddTicket();
		}

		private void showTicketButton_Click(object sender, EventArgs e) {
			ShowTicket();
		}

		private void editTicketButton_Click(object sender, EventArgs e) {
			EditTicket();
		}

		private void showTicketHistoryButton_Click(object sender, EventArgs e) {
			ShowTicketHistory();
		}

		private void deleteTicketButton_Click(object sender, EventArgs e) {
			DeleteTicket();
		}

		private void showTicketAttachmentsButton_Click(object sender, EventArgs e) {
			ShowAttachments();
		}
		#endregion

		#region Context menu
		private void ticketContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			int selectedTicketsCount = ticketsListView.SelectedItems.Count;
			showTicketToolStripMenuItem.Enabled = selectedTicketsCount == 1;
			editTicketToolStripMenuItem.Enabled = selectedTicketsCount == 1;
			showTicketHistoryToolStripMenuItem.Enabled = selectedTicketsCount == 1;
			deleteTicketToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			showTicketAttachmentsToolStripMenuItem.Enabled = selectedTicketsCount == 1;

			stateNewToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			stateAcceptedToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			stateInProgressToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			stateBlockedToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			stateCompletedToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			stateClosedToolStripMenuItem.Enabled = selectedTicketsCount > 0;

			priorityToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			severityToolStripMenuItem.Enabled = selectedTicketsCount > 0;
			typeToolStripMenuItem.Enabled = selectedTicketsCount > 0;
		}

		private void addTicketToolStripMenuItem_Click(object sender, EventArgs e) {
			AddTicket();
		}

		private void showTicketToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowTicket();
		}

		private void editTicketToolStripMenuItem_Click(object sender, EventArgs e) {
			EditTicket();
		}

		private void showTicketHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowTicketHistory();
		}

		private void deleteTicketToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteTicket();
		}

		private void showTicketAttachmentsToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowAttachments();
		}

		#region Ticket state
		private void stateNewToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.New);
		}

		private void stateAcceptedToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.Accepted);
		}

		private void stateInProgressToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.InProgress);
		}

		private void stateBlockedToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.Blocked);
		}

		private void stateCompletedToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.Completed);
		}

		private void stateClosedToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketState(TicketState.Closed);
		}
		#endregion

		#region Ticket priority
		private void lowestPriorityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketPriority(TicketPriority.Lowest);
		}

		private void lowPriorityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketPriority(TicketPriority.Low);
		}

		private void normalPriorityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketPriority(TicketPriority.Normal);
		}

		private void highPriorityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketPriority(TicketPriority.High);
		}

		private void highestPriorityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketPriority(TicketPriority.Highest);
		}
		#endregion

		#region Ticket severity
		private void trivialSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Trivial);
		}

		private void minorSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Minor);
		}

		private void normalSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Normal);
		}

		private void majorSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Major);
		}

		private void criticalSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Critical);
		}

		private void blockerSeverityToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketSeverity(TicketSeverity.Blocker);
		}
		#endregion

		#region Ticket type
		private void defectToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketType(TicketType.Defect);
		}

		private void featureRequestToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketType(TicketType.FeatureRequest);
		}

		private void taskToolStripMenuItem_Click(object sender, EventArgs e) {
			SetTicketType(TicketType.Task);
		}
		#endregion
		#endregion
		#endregion

		#region Project filter UI
		private void projectNameTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void projectNameTextBox_TextChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketSeverityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketReportersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectTicketAssignedToComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectProjectStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowProjects();
		}

		private void projectCreatedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void projectModifiedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void projectCreatedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mProjectCreateFilter, "Created")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel)
					return;

				mProjectCreateFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(projectCreatedTextBox, mProjectCreateFilter);
				ShowProjects();
			}
		}

		private void projectModifiedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mProjectModifyFilter, "Modified")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel)
					return;

				mProjectModifyFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(projectModifiedTextBox, mProjectModifyFilter);
				ShowProjects();
			}
		}

		private void resetProjectFilterButton_Click(object sender, EventArgs e) {
			ResetProjectFilters();
			ShowProjects();
		}
		#endregion

		#region Ticket filter UI
		private void ticketSummaryTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketSummaryTextBox_TextChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketSeverityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketReportersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTicketAssignedToComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketProjectStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketCreatedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketModifiedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketCreatedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mTicketCreateFilter, "Created")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel) return;

				mTicketCreateFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(ticketCreatedTextBox, mTicketCreateFilter);

				ShowTickets();
			}
		}

		private void ticketModifiedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mTicketModifyFilter, "Modified")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel) return;

				mTicketModifyFilter = result == DialogResult.No ?
					null :
					form.Range;
				FormUtil.FormatDateFilter(ticketModifiedTextBox, mTicketModifyFilter);
				ShowTickets();
			}
		}

		private void resetTicketFilterButton_Click(object sender, EventArgs e) {
			ResetTicketFilters();
			ShowTickets();
		}
		#endregion

		#region Utility functions
		private void ShowCurrentLanguage() {
			englishToolStripMenuItem.Checked = false;
			persianToolStripMenuItem.Checked = false;

			switch (Settings.Default.Language) {
				case "en":
					englishToolStripMenuItem.Checked = true;
					databaseToolStripStatusLabel.TextAlign = ContentAlignment.MiddleLeft;
					break;

				case "fa":
					persianToolStripMenuItem.Checked = true;
					databaseToolStripStatusLabel.TextAlign = ContentAlignment.MiddleRight;
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
			bool hasDatabase = mContext.HasDatabase;
			saveDatabaseAsToolStripMenuItem.Enabled = hasDatabase;
			closeDatabaseToolStripMenuItem.Enabled = hasDatabase;
			if (!hasDatabase) {
				addProjectButton.Enabled = false;
				editProjectButton.Enabled = false;
				editTicketsButton.Enabled = false;
				deleteProjectButton.Enabled = false;
				projectsTabPage.Enabled = false;
				ticketsTabPage.Enabled = false;
			}
			else {
				int selectedProjectsCount = projectsListView.SelectedItems.Count;
				addProjectButton.Enabled = true;
				editProjectButton.Enabled = selectedProjectsCount > 0;
				editTicketsButton.Enabled = selectedProjectsCount > 0;
				deleteProjectButton.Enabled = selectedProjectsCount > 0;

				int selectedTicketsCount = ticketsListView.SelectedItems.Count;
				showTicketButton.Enabled = selectedTicketsCount == 1;
				editTicketButton.Enabled = selectedTicketsCount == 1;
				showTicketHistoryButton.Enabled = selectedTicketsCount == 1;
				deleteTicketButton.Enabled = selectedTicketsCount > 0;
				showTicketAttachmentsButton.Enabled = selectedTicketsCount == 1;

				projectsTabPage.Enabled = true;
				ticketsTabPage.Enabled = Project.GetProjects(mContext).Any();
			}

			dbVersionToolStripStatusLabel.Text = string.Format(
				Resources.String_DbVersionX,
				hasDatabase ?
					Logic.Version.Get(mContext).ID :
					0);

			databaseToolStripStatusLabel.Text = hasDatabase ?
				string.Format(Resources.String_DatabaseXY,
					Path.GetFileName(mContext.DB?.CurrentDatabasePath),
					mContext.DB?.CurrentDatabasePath) :
				Resources.String_NoDatabase;
		}

		private void NewDatabase() {
			saveFileDialog.FileName = string.Empty;
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			try {
				CloseDatabase();

				string databasePath = saveFileDialog.FileName;

				Environment.CurrentDirectory = Application.StartupPath;
				mContext = new FormContext(Database.CreateAndOpen(databasePath));

				// This is required to clear out the assigned to/reporter combos
				UpdateTicketOrProject();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));

				CloseDatabase();
			}
		}

		private void OpenDatabase() {
			openFileDialog.FileName = string.Empty;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
				return;
			try {
				if (mContext.DB?.IsOpen == true) {
					CloseDatabase();
				}

				string databasePath = openFileDialog.FileName;

				Environment.CurrentDirectory = Application.StartupPath;
				mContext = new FormContext(Database.Open(databasePath));

				// This is required to update the assigned to/reporter combos
				UpdateTicketOrProject();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));

				CloseDatabase();
			}
		}

		private void SaveDatabaseAs() {
			string currentDatabasePath = mContext.DB.CurrentDatabasePath;
			saveFileDialog.FileName = currentDatabasePath;
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
				return;
			try {
				mContext.Close();

				string newDatabasePath = saveFileDialog.FileName;

				// Copy.
				File.Copy(currentDatabasePath, newDatabasePath, true);

				Environment.CurrentDirectory = Application.StartupPath;
				mContext = new FormContext(Database.Open(newDatabasePath));

				foreach (var form in mForms.ToArray()) {
					form.Value.SaveDatabaseAs(mContext);
				}

				ShowProjects();
				ShowTickets();
				UpdateStatusbar();
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));

				CloseDatabase();
			}
		}

		private void CloseDatabase() {
			if (mContext.HasDatabase) {
				mContext.Close();
			}
			mContext = FormContext.Default;
			ResetProjectFilters();
			ResetTicketFilters();
			mProjectTicketCount = TicketCount.Empty;
			mTicketTicketCount = TicketCount.Empty;
			UpdateStatusbar(TicketCount.Empty);

			// ToArray to copy the forms so we can mutate the dictionary
			foreach (var form in mForms.ToArray()) {
				form.Value.Close();
			}

			projectsListView.Items.Clear();

			UpdateControlsEnabledProperty();
		}

		private void ShowOptions() {
			using (var form = new OptionsForm()) {
				if (form.ShowDialog() != DialogResult.OK) return;

				// If the DB isn't open, we can't have filters or things like that, so there's no point in going on
				if (mContext.DB?.IsOpen != true) return;

				// Might change date formatting, update display
				ShowProjects();
				ShowTickets();

				// Update filter boxes
				FormUtil.FormatDateFilter(projectCreatedTextBox, mProjectCreateFilter);
				FormUtil.FormatDateFilter(projectModifiedTextBox, mProjectModifyFilter);
				FormUtil.FormatDateFilter(ticketCreatedTextBox, mTicketCreateFilter);
				FormUtil.FormatDateFilter(ticketModifiedTextBox, mTicketModifyFilter);

				// If there are any open forms, go through them and let them know as well
				foreach (var child in mForms) {
					child.Value.UpdateSettings();
				}
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
					FormUtil.GetMessageBoxOptions(this));
			}
		}

		private void ShowAbout() {
			using (var form = new AboutForm()) {
				form.ShowDialog();
			}
		}

		internal void CloseProjectForm(ProjectForm form) {
			ProjectForm query;
			if (mForms.TryGetValue(form.Project.ID, out query)) {
				mForms.Remove(form.Project.ID);
			}
		}

		internal void UpdateTicketOrProject() {
			// Update our UI elements for assigned/reported, can't populate this in ShowProjects because that would cause nightmares

			var reporters = Ticket.GetReporters(mContext);
			var assignees = Ticket.GetAssignees(mContext);
			FormUtil.UpdateUserBoxWithSelectedItem(
				projectTicketReportersComboBox,
				reporters);

			FormUtil.UpdateUserBoxWithSelectedItem(
				projectTicketAssignedToComboBox,
				assignees);

			FormUtil.UpdateUserBoxWithSelectedItem(
				ticketTicketReportersComboBox,
				reporters);

			FormUtil.UpdateUserBoxWithSelectedItem(
				ticketTicketAssignedToComboBox,
				assignees);

			// Any child should require updated filters
			foreach (var form in mForms.ToArray()) {
				form.Value.UpdateTicket();
			}

			ShowProjects();
			ShowTickets();
		}

		private void UpdateStatusbar() {
			UpdateStatusbar(mainTabControl.SelectedTab == projectsTabPage ?
				mProjectTicketCount :
				mTicketTicketCount);
		}

		private void UpdateStatusbar(TicketCount count) {
			openTicketsToolStripStatusLabel.Text = string.Format(
				Resources.String_OpenTicketsX,
				count.Open);

			totalTicketsToolStripStatusLabel.Text = string.Format(
				Resources.String_TotalTicketsX,
				count.Total);
		}

		#region Projects
		private void ProjectBatch<TValue>(Action<Project, TValue, bool> projectFunc, TValue value) {
			for (int i = 0, end = projectsListView.SelectedItems.Count; i < end; i++) {
				var project = (Project)projectsListView.SelectedItems[i].Tag;
				projectFunc(project, value, true);
			}

			// Flush.
			mContext.Flush();

			ShowProjects();
		}

		private void ProjectSingle(Project project, bool batch, Func<Project, Project> changes) {
			project = changes(project);
			project.Update(mContext);
			if (batch) return;

			// Flush.
			mContext.Flush();

			ShowProjects();
		}

		private void SetProjectState(ProjectState state) {
			ProjectBatch(SetProjectState, state);
		}

		private void SetProjectState(Project project, ProjectState state, bool batch = false) {
			ProjectSingle(project, batch, t => {
				t.State = state;
				return t;
			});
		}

		private void ShowProjects() {
			if (mResettingProjectFilters)
				return;

			// Save selected projects.
			var selectedProjects = new List<int>();
			foreach (ListViewItem item in projectsListView.SelectedItems) {
				var project = (Project)item.Tag;
				selectedProjects.Add(project.ID);
			}

			Project[] projects = Project.GetProjects(mContext.DB);

			string nameFilter = projectNameTextBox.Text;
			var reporterFilter = (string)projectTicketReportersComboBox.SelectedItem;
			var assignedFilter = (string)projectTicketAssignedToComboBox.SelectedItem;
			var stateFilter = FormUtil.CastBox<MetaTicketState>(projectTicketStateComboBox);
			var severityFilter = FormUtil.CastBox<TicketSeverity>(projectTicketSeverityComboBox);
			var priorityFilter = FormUtil.CastBox<TicketPriority>(projectTicketPriorityComboBox);
			var typeFilter = FormUtil.CastBox<TicketType>(projectTicketTypeComboBox);
			var activeFilter = FormUtil.CastBox<ProjectState>(projectProjectStateComboBox);

			if (string.IsNullOrEmpty(reporterFilter)) reporterFilter = null;
			if (string.IsNullOrEmpty(assignedFilter)) assignedFilter = null;

			var allTickets = new List<Tuple<Project, Ticket[]>>(
				projects.Select(p => Tuple.Create(p, p.GetTickets(mContext))));

			projects = projects.Where(p => {
				bool satisfiesNameFilter = FormUtil.SatisfiesFilterContains(p.Name, nameFilter);
				if (!satisfiesNameFilter) return false;
				if (!FormUtil.SatisfiesFilterEnum(p.State, activeFilter)) return false;

				var tickets = allTickets.First(item => item.Item1 == p).Item2;
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
						mProjectCreateFilter,
						mProjectModifyFilter,
					}.Any(v => v != null);
				}

				bool satisfiesCreatedFilter = FormUtil.SatisfiesFilterContains(tickets.Min(t => t.CreateTimestamp), mProjectCreateFilter);
				bool satisfiesModifiedFilter = FormUtil.SatisfiesFilterContains(tickets.Max(t => t.ModifyTimestamp), mProjectModifyFilter);
				if (!(satisfiesCreatedFilter && satisfiesModifiedFilter))
					return false;

				return tickets.Any(t => {
					bool satisfiesReporterFilter = FormUtil.SatisfiesFilterMatch(t.ReportedBy, reporterFilter);
					bool satisfiesAssignedFilter = FormUtil.SatisfiesFilterMatch(t.AssignedTo, assignedFilter);
					bool satisfiesStateFilter = stateFilter == null || stateFilter.Value.AppliesTo(t.State);
					bool satisfiesSeverityFilter = FormUtil.SatisfiesFilterEnum(t.Severity, severityFilter);
					bool satisfiesPriorityFilter = FormUtil.SatisfiesFilterEnum(t.Priority, priorityFilter);
					bool satisfiesTypeFilter = FormUtil.SatisfiesFilterEnum(t.Type, typeFilter);

					return
						satisfiesReporterFilter &&
						satisfiesAssignedFilter &&
						satisfiesStateFilter &&
						satisfiesSeverityFilter &&
						satisfiesPriorityFilter &&
						satisfiesTypeFilter;
				});
			}).ToArray();

			var formatter = FormUtil.GetFormatter();

			projectsListView.BeginUpdate();
			projectsListView.Items.Clear();
			foreach (var project in projects) {
				var tickets = allTickets.First(item => item.Item1 == project).Item2;
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
				projectsListView.Width -
				(ticketColumnSize * 2) -
				(updateColumnSize * 2) -
				scrollbarSize;

			projectsListView.EndUpdate();

			// Reselect projects.
			foreach (ListViewItem item in projectsListView.Items) {
				var project = (Project)item.Tag;
				if (selectedProjects.Contains(project.ID)) {
					item.Selected = true;
					item.EnsureVisible();
				}
			}

			UpdateControlsEnabledProperty();

			var summaryTickets = allTickets.
				Where(t => projects.Contains(t.Item1)).
				SelectMany(item => item.Item2).
				ToArray();

			mProjectTicketCount = new TicketCount(
				summaryTickets.Count(t => t.State.IsOpen()),
				summaryTickets.Length);

			UpdateStatusbar();
		}

		private void AddProject() {
			using (var form = new ProjectDetailsForm(mContext, null)) {
				if (form.ShowDialog() != DialogResult.OK) return;
				var project = form.RetrieveProject();

				// Add.
				project.Add(mContext);

				// Flush.
				mContext.Flush();

				// Show projects.
				ShowProjects();

				// Select new project.
				projectsListView.SelectedItems.Clear();
				foreach (ListViewItem item in projectsListView.Items) {
					var p = (Project)item.Tag;
					if (p.ID == project.ID) {
						item.Selected = true;
						break;
					}
				}

				UpdateControlsEnabledProperty();

				// Show edit project form.
				EditProject();

				projectsListView.Focus();
			}
		}

		private void EditProject(bool ticketTab = false) {
			for (int i = 0, end = projectsListView.SelectedItems.Count; i < end; i++) {
				var item = (Project)projectsListView.SelectedItems[i].Tag;
				ProjectForm form;
				if (!mForms.TryGetValue(item.ID, out form)) {
					form = new ProjectForm(this, mContext, item);
					mForms[item.ID] = form;
					if (ticketTab) form.ActivateTicketTab();
					else form.ActivateProjectTab();
					form.Show();
				}
				else {
					if (ticketTab) form.ActivateTicketTab();
					else form.ActivateProjectTab();
					form.Activate();
				}
			}
		}

		private void DeleteProject() {
			if (projectsListView.SelectedItems.Count == 0) return;
			DialogResult result = MessageBox.Show(
				Resources.String_AreYouSureYouWantToDeleteSelectedProjects,
				Resources.String_DeleteProjects,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			if (result != DialogResult.Yes) {
				return;
			}

			// Delete projects.
			for (int i = 0; i < projectsListView.SelectedItems.Count; i++) {
				var project = (Project)projectsListView.SelectedItems[i].Tag;
				project.Delete(mContext);
			}

			// Flush.
			mContext.Flush();

			// Show projects.
			ShowProjects();
		}

		private void ResetProjectFilters() {
			mResettingProjectFilters = true;
			projectNameTextBox.Text = string.Empty;
			FormUtil.SetOrDefault(projectTicketAssignedToComboBox);
			FormUtil.SetOrDefault(projectTicketReportersComboBox);
			FormUtil.SetOrDefault(projectTicketPriorityComboBox);
			FormUtil.SetOrDefault(projectTicketSeverityComboBox);
			FormUtil.SetOrDefault(projectTicketStateComboBox);
			FormUtil.SetOrDefault(projectTicketTypeComboBox);
			FormUtil.SetOrDefault(projectProjectStateComboBox);
			mProjectModifyFilter = null;
			projectModifiedTextBox.Text = string.Empty;
			mProjectCreateFilter = null;
			projectCreatedTextBox.Text = string.Empty;
			mResettingProjectFilters = false;
		}
		#endregion

		#region Tickets
		private void TicketBatch<TValue>(Action<Ticket, TValue, bool> ticketFunc, TValue value) {
			for (int i = 0, end = ticketsListView.SelectedItems.Count; i < end; i++) {
				var ticket = (Ticket)ticketsListView.SelectedItems[i].Tag;
				ticketFunc(ticket, value, true);
			}

			// Flush.
			mContext.Flush();

			UpdateTicketOrProject();
		}

		private void TicketSingle(Ticket ticket, bool batch, Func<Ticket, Ticket> changes) {
			bool applied = ticket.UpdateAndGenerateHistoryRecord(mContext, TicketChangeFormatter.Default, changes);

			if (!applied || batch) return;

			// Flush.
			mContext.Flush();

			UpdateTicketOrProject();
		}

		private void SetTicketState(TicketState state) {
			TicketBatch(SetTicketState, state);
		}

		private void SetTicketState(Ticket ticket, TicketState state, bool batch = false) {
			TicketSingle(ticket, batch, t => {
				t.State = state;
				return t;
			});
		}

		private void SetTicketPriority(TicketPriority priority) {
			TicketBatch(SetTicketPriority, priority);
		}

		private void SetTicketPriority(Ticket ticket, TicketPriority priority, bool batch = false) {
			TicketSingle(ticket, batch, t => {
				t.Priority = priority;
				return t;
			});
		}

		private void SetTicketSeverity(TicketSeverity severity) {
			TicketBatch(SetTicketSeverity, severity);
		}

		private void SetTicketSeverity(Ticket ticket, TicketSeverity severity, bool batch = false) {
			TicketSingle(ticket, batch, t => {
				t.Severity = severity;
				return t;
			});
		}

		private void SetTicketType(TicketType type) {
			TicketBatch(SetTicketType, type);
		}

		private void SetTicketType(Ticket ticket, TicketType type, bool batch = false) {
			TicketSingle(ticket, batch, t => {
				t.Type = type;
				return t;
			});
		}

		private void ShowTickets() {
			if (mResettingTicketFilters) return;

			// Save selected tickets.
			var selectedTickets = new List<int>();
			foreach (ListViewItem item in ticketsListView.SelectedItems) {
				var ticket = (Ticket)item.Tag;
				selectedTickets.Add(ticket.ID);
			}

			string summaryFilter = ticketSummaryTextBox.Text;
			string reporterFilter = ticketTicketReportersComboBox.SelectedText;
			string assignedFilter = ticketTicketAssignedToComboBox.SelectedText;
			var stateFilter = FormUtil.CastBox<MetaTicketState>(ticketTicketStateComboBox);
			var severityFilter = FormUtil.CastBox<TicketSeverity>(ticketTicketSeverityComboBox);
			var priorityFilter = FormUtil.CastBox<TicketPriority>(ticketTicketPriorityComboBox);
			var typeFilter = FormUtil.CastBox<TicketType>(ticketTicketTypeComboBox);
			var activeFilter = FormUtil.CastBox<ProjectState>(ticketProjectStateComboBox);

			Ticket[] tickets = Project.GetProjects(mContext).
				Where(p => FormUtil.SatisfiesFilterEnum(p.State, activeFilter)).
				SelectMany(p => p.GetTickets(mContext)).
				ToArray();

			tickets = tickets.Where(t => {
				bool satisfiesSummaryFilter = FormUtil.SatisfiesFilterContains(t.Summary, summaryFilter);
				bool satisfiesReporterFilter = FormUtil.SatisfiesFilterMatch(t.ReportedBy, reporterFilter);
				bool satisfiesAssignedFilter = FormUtil.SatisfiesFilterMatch(t.AssignedTo, assignedFilter);
				bool satisfiesStateFilter = stateFilter == null || stateFilter.Value.AppliesTo(t.State);
				bool satisfiesSeverityFilter = FormUtil.SatisfiesFilterEnum(t.Severity, severityFilter);
				bool satisfiesPriorityFilter = FormUtil.SatisfiesFilterEnum(t.Priority, priorityFilter);
				bool satisfiesTypeFilter = FormUtil.SatisfiesFilterEnum(t.Type, typeFilter);
				bool satisfiesCreatedFilter = FormUtil.SatisfiesFilterContains(t.CreateTimestamp, mTicketCreateFilter);
				bool satisfiesModifiedFilter = FormUtil.SatisfiesFilterContains(t.ModifyTimestamp, mTicketModifyFilter);

				return
					satisfiesSummaryFilter &&
					satisfiesReporterFilter &&
					satisfiesAssignedFilter &&
					satisfiesStateFilter &&
					satisfiesSeverityFilter &&
					satisfiesPriorityFilter &&
					satisfiesTypeFilter &&
					satisfiesCreatedFilter &&
					satisfiesModifiedFilter;
			}).ToArray();

			// Cache milestones.
			var milestoneNames = new Dictionary<int, string>();
			var projectNames = new Dictionary<int, string>();
			Milestone[] milestones = Milestone.GetMilestones(mContext);
			foreach (Milestone milestone in milestones) {
				milestoneNames[milestone.ID] = milestone.Name;
				projectNames[milestone.ID] = milestone.GetProject(mContext).Name;
			}

			var formatter = FormUtil.GetFormatter();
			ticketsListView.BeginUpdate();
			ticketsListView.Items.Clear();
			foreach (var ticket in tickets) {
				string ticketPriority = TicketChangeFormatter.Default.TranslateTicketPriority(ticket.Priority);
				string ticketType = TicketChangeFormatter.Default.TranslateTicketType(ticket.Type);
				string ticketSeverity = TicketChangeFormatter.Default.TranslateTicketSeverity(ticket.Severity);
				string ticketState = TicketChangeFormatter.Default.TranslateTicketState(ticket.State);

				var lvi = new ListViewItem() {
					Text = projectNames[ticket.MilestoneID],
					Tag = ticket,
				};

				lvi.SubItems.Add(milestoneNames[ticket.MilestoneID]);
				lvi.SubItems.Add(ticket.Summary);
				lvi.SubItems.Add(ticketPriority);
				lvi.SubItems.Add(ticketType);
				lvi.SubItems.Add(ticketSeverity);
				lvi.SubItems.Add(ticketState);
				lvi.SubItems.Add(formatter.Format(ticket.ModifyTimestamp));

				ticketsListView.Items.Add(lvi);
			}

			ticketsListView.EndUpdate();
			ticketsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

			// Reselect tickets.
			foreach (ListViewItem item in ticketsListView.Items) {
				var ticket = (Ticket)item.Tag;
				if (selectedTickets.Contains(ticket.ID)) {
					item.Selected = true;
				}
			}

			UpdateControlsEnabledProperty();

			mTicketTicketCount = new TicketCount(
				tickets.Count(t => t.State.IsOpen()),
				tickets.Length);

			UpdateStatusbar();
		}

		private void ResetTicketFilters() {
			mResettingTicketFilters = true;
			ticketSummaryTextBox.Text = string.Empty;
			FormUtil.SetOrDefault(ticketTicketAssignedToComboBox);
			FormUtil.SetOrDefault(ticketTicketReportersComboBox);
			FormUtil.SetOrDefault(ticketTicketPriorityComboBox);
			FormUtil.SetOrDefault(ticketTicketSeverityComboBox);
			FormUtil.SetOrDefault(ticketTicketStateComboBox);
			FormUtil.SetOrDefault(ticketTicketTypeComboBox);
			FormUtil.SetOrDefault(ticketProjectStateComboBox);
			mTicketModifyFilter = null;
			ticketModifiedTextBox.Text = string.Empty;
			mTicketCreateFilter = null;
			ticketCreatedTextBox.Text = string.Empty;
			mResettingTicketFilters = false;
		}

		private void AddTicket() {
			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), null, null)) {
				if (form.ShowDialog() != DialogResult.OK) return;
				Ticket ticket = form.RetrieveTicket();

				// Add.
				ticket.Add(mContext);

				// Flush.
				mContext.Flush();

				// Create ticket history entry.
				TicketHistory ticketHistory = ticket.NewHistory(Resources.String_TicketCreated);
				ticketHistory.Add(mContext);

				// Show tickets.
				ShowTickets();

				// Select new ticket.
				ticketsListView.SelectedItems.Clear();
				foreach (ListViewItem item in ticketsListView.Items) {
					Ticket t = (Ticket)item.Tag;
					if (t.ID == ticket.ID) {
						item.Selected = true;
						item.EnsureVisible();
						break;
					}
				}

				UpdateControlsEnabledProperty();

				ticketsListView.Focus();

				UpdateTicketOrProject();
			}
		}

		private void ShowTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			Project project = ticket.GetMilestone(mContext).GetProject(mContext);
			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), project, ticket)) {
				form.ReadOnly = true;
				form.ShowDialog();
			}
		}

		private void EditTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			Project project = ticket.GetMilestone(mContext).GetProject(mContext);
			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), project, ticket)) {
				if (form.ShowDialog() != DialogResult.OK) return;

				ticket.UpdateAndGenerateHistoryRecord(mContext, TicketChangeFormatter.Default, t => {
					return form.RetrieveTicket(t);
				});

				// Flush.
				mContext.Flush();

				UpdateTicketOrProject();
			}
		}

		private void ShowTicketHistory() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (TicketHistoryForm form = new TicketHistoryForm(mContext, ticket)) {
				form.ShowDialog();
			}
		}

		private void ShowAttachments() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new AttachmentsForm(mContext, ticket)) {
				form.ShowDialog();
			}
		}

		private void DeleteTicket() {
			if (ticketsListView.SelectedItems.Count == 0) return;

			DialogResult result = MessageBox.Show(
				Resources.String_AreYouSureYouWantToDeleteSelectedTickets,
				Resources.String_DeleteTickets,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			if (result != DialogResult.Yes) {
				return;
			}

			// Delete tickets.
			for (int i = 0; i < ticketsListView.SelectedItems.Count; i++) {
				var ticket = (Ticket)ticketsListView.SelectedItems[i].Tag;
				ticket.Delete(mContext);
			}

			// Flush.
			mContext.Flush();

			UpdateTicketOrProject();
		}
		#endregion

		#endregion
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class ProjectForm : Form {
		private MainForm mMainForm = null;
		private bool mResettingTicketFilters = false;
		private DateRange mTicketCreateFilter = null;
		private DateRange mTicketModifyFilter = null;

		public Project Project { get; private set; }

		public ProjectForm(Project project, MainForm mainForm) {
			if (project == null) throw new ArgumentNullException(nameof(project));
			if (mainForm == null) throw new ArgumentNullException(nameof(mainForm));

			Project = project;
			mMainForm = mainForm;

			InitializeComponent();

			// Center on the parent, we assume modeless here and CenterParent doesn't work on modeless
			StartPosition = FormStartPosition.Manual;
			Location = new Point(
				mainForm.Location.X + (mainForm.Width - Width) / 2,
				mainForm.Location.Y + (mainForm.Height - Height) / 2);

			ShowProjectDetails();
			ShowMilestones();
			ShowTickets();
			PopulateTicketFilters();

			Text = "Project - " + project.Name;
		}

		private void milestonesListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateButtonsEnabledProperty();
		}

		private void milestonesListView_DoubleClick(object sender, EventArgs e) {
			ShowMilestone();
		}

		private void milestonesListView_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter) return;
			ShowMilestone();
		}

		private void ticketsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateButtonsEnabledProperty();
		}

		private void ticketsListView_DoubleClick(object sender, EventArgs e) {
			EditTicket();
		}

		private void ticketsListView_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode != Keys.Enter) return;
			EditTicket();
		}

		private void changeProjectDetailsButton_Click(object sender, EventArgs e) {
			ChangeProjectDetails();
		}

		private void ProjectForm_FormClosed(object sender, FormClosedEventArgs e) {
			mMainForm.CloseProjectForm(this);
		}

		#region Milestone modification UI
		#region Buttons
		private void addMilestoneButton_Click(object sender, EventArgs e) {
			AddMilestone();
		}

		private void showMilestoneButton_Click(object sender, EventArgs e) {
			ShowMilestone();
		}

		private void editMilestoneButton_Click(object sender, EventArgs e) {
			EditMilestone();
		}

		private void deleteMilestoneButton_Click(object sender, EventArgs e) {
			DeleteMilestone();
		}
		#endregion

		#region Context menu
		private void milestoneContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			int selectedMilestonesCount = milestonesListView.SelectedItems.Count;
			showMilestoneToolStripMenuItem.Enabled = selectedMilestonesCount == 1;
			editMilestoneToolStripMenuItem.Enabled = selectedMilestonesCount == 1;
			deleteMilestoneToolStripMenuItem.Enabled = selectedMilestonesCount > 0;
		}

		private void addMilestoneToolStripMenuItem_Click(object sender, EventArgs e) {
			AddMilestone();
		}

		private void showMilestoneToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowMilestone();
		}

		private void editMilestoneToolStripMenuItem_Click(object sender, EventArgs e) {
			EditMilestone();
		}

		private void deleteMilestoneToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteMilestone();
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

		#region Ticket filter UI
		private void ticketTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketTextBox_TextChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketStateComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketPriorityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketSeverityComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketTypeComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketAssignedToComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketReportersComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void ticketMilestoneComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			ShowTickets();
		}

		private void resetTicketFilterButton_Click(object sender, EventArgs e) {
			ResetTicketFilters();
			ShowTickets();
		}

		private void createdTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void modifiedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketCreatedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mTicketCreateFilter, "Created")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel)
					return;
				if (result == DialogResult.No) {
					mTicketCreateFilter = null;
					createdTextBox.Text = string.Empty;
					ShowTickets();
					return;
				}
				mTicketCreateFilter = form.Range;
				createdTextBox.Text = mTicketCreateFilter?.ToString() ?? string.Empty;
				ShowTickets();
			}
		}

		private void ticketModifiedButton_Click(object sender, EventArgs e) {
			using (var form = new DateRangeForm(mTicketModifyFilter, "Modified")) {
				var result = form.ShowDialog();
				if (result == DialogResult.Cancel) {
					return;
				}
				if (result == DialogResult.No) {
					mTicketModifyFilter = null;
					modifiedTextBox.Text = string.Empty;
					ShowTickets();
					return;
				}
				mTicketModifyFilter = form.Range;
				modifiedTextBox.Text = mTicketModifyFilter?.ToString() ?? string.Empty;
				ShowTickets();
			}
		}
		#endregion

		#region Utility functions
		private void UpdateButtonsEnabledProperty() {
			int selectedMilestonesCount = milestonesListView.SelectedItems.Count;
			showMilestoneButton.Enabled = selectedMilestonesCount == 1;
			editMilestoneButton.Enabled = selectedMilestonesCount == 1;
			deleteMilestoneButton.Enabled = selectedMilestonesCount > 0;

			int selectedTicketsCount = ticketsListView.SelectedItems.Count;
			showTicketButton.Enabled = selectedTicketsCount == 1;
			editTicketButton.Enabled = selectedTicketsCount == 1;
			showTicketHistoryButton.Enabled = selectedTicketsCount == 1;
			deleteTicketButton.Enabled = selectedTicketsCount > 0;
			showTicketAttachmentsButton.Enabled = selectedTicketsCount == 1;
		}

		private void ShowProjectDetails() {
			projectDetailsUserControl.ShowProject(Project);
		}

		private void ChangeProjectDetails() {
			using (var form = new ProjectDetailsForm()) {
				form.ProjectDetailsUserControl.ShowProject(Project);

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
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					form.ProjectDetailsUserControl.RetrieveProject(Project);

					// Update project.
					Project.Update();

					// Flush.
					Database.Flush();

					ShowProjectDetails();

					mMainForm.UpdateTicketOrProject();
				}
			}
		}

		#region Milestone
		private void ShowMilestones() {
			// Save selected milestones.
			var selectedMilestones = new List<int>();
			foreach (ListViewItem item in milestonesListView.SelectedItems) {
				var milestone = (Milestone)item.Tag;
				selectedMilestones.Add(milestone.ID);
			}

			Milestone[] milestones = Project.GetMilestones();

			milestonesListView.BeginUpdate();
			milestonesListView.Items.Clear();
			foreach (var milestone in milestones) {
				string milestoneState;
				switch (milestone.State) {
					case MilestoneState.Active:
						milestoneState = Resources.String_Active;
						break;

					case MilestoneState.Completed:
						milestoneState = Resources.String_Completed;
						break;

					case MilestoneState.Cancelled:
						milestoneState = Resources.String_Cancelled;
						break;

					default:
						milestoneState = string.Empty;
						break;
				}

				var lvi = new ListViewItem() {
					Text = milestone.Name,
					Tag = milestone,
				};

				lvi.SubItems.Add(milestoneState);
				milestonesListView.Items.Add(lvi);
			}
			milestonesListView.EndUpdate();
			milestonesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

			// Reselect milestones.
			foreach (ListViewItem item in milestonesListView.Items) {
				var milestone = (Milestone)item.Tag;
				if (selectedMilestones.Contains(milestone.ID)) {
					item.Selected = true;
				}
			}

			UpdateButtonsEnabledProperty();

			ShowTickets();
		}

		private void AddMilestone() {
			Milestone milestone = Project.NewMilestone();
			using (var form = new MilestoneDetailsForm()) {
				form.ShowMilestone(milestone);
				form.State = MilestoneState.Active;

				Again:
				if (form.ShowDialog() == DialogResult.OK) {
					// Check name.
					if (string.IsNullOrWhiteSpace(form.MilestoneName)) {
						MessageBox.Show(
							Resources.String_TheMilestoneNameCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check state.
					if (form.State == (MilestoneState)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyMilestoneState,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					form.RetrieveMilestone(milestone);

					// Add.
					milestone.Add();

					// Flush.
					Database.Flush();

					// Show milestones.
					ShowMilestones();

					// Select new milestone.
					milestonesListView.SelectedItems.Clear();
					foreach (ListViewItem item in milestonesListView.Items) {
						var m = (Milestone)item.Tag;
						if (m.ID == milestone.ID) {
							item.Selected = true;
							item.EnsureVisible();
							break;
						}
					}

					PopulateTicketFilters();

					UpdateButtonsEnabledProperty();

					milestonesListView.Focus();
				}
			}
		}

		private void ShowMilestone() {
			if (milestonesListView.SelectedItems.Count != 1) {
				return;
			}

			var milestone = (Milestone)milestonesListView.SelectedItems[0].Tag;
			using (var form = new MilestoneDetailsForm()) {
				form.ShowMilestone(milestone);
				form.ReadOnly = true;

				form.ShowDialog();
			}
		}

		private void EditMilestone() {
			if (milestonesListView.SelectedItems.Count != 1) {
				return;
			}

			var milestone = (Milestone)milestonesListView.SelectedItems[0].Tag;
			using (var form = new MilestoneDetailsForm()) {
				form.ShowMilestone(milestone);

				Again:
				if (form.ShowDialog() == DialogResult.OK) {
					// Check name.
					if (string.IsNullOrWhiteSpace(form.MilestoneName)) {
						MessageBox.Show(
							Resources.String_TheMilestoneNameCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check state.
					if (form.State == (MilestoneState)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyMilestoneState,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					form.RetrieveMilestone(milestone);

					// Update milestones.
					milestone.Update();

					// Flush.
					Database.Flush();

					// Show milestones.
					ShowMilestones();

					PopulateTicketFilters();

					// Tickets will have outdated naming potentially if we don't update the ticket display
					ShowTickets();
				}
			}
		}

		private void DeleteMilestone() {
			if (milestonesListView.SelectedItems.Count != 0) return;

			DialogResult result = MessageBox.Show(
				Resources.String_AreYouSureYouWantToDeleteSelectedMilestonesAndTheirTickets,
				Resources.String_DeleteMilestones,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			if (result != DialogResult.Yes) {
				return;
			}

			// Delete milestones.
			for (int i = 0; i < milestonesListView.SelectedItems.Count; i++) {
				var milestone = (Milestone)milestonesListView.SelectedItems[i].Tag;
				milestone.Delete();
			}

			// Flush.
			Database.Flush();

			// Show milestones.
			ShowMilestones();

			PopulateTicketFilters();

			// Tickets may change as the result of removing a milestone
			ShowTickets();
		}
		#endregion

		#region Ticket
		private void TicketBatch<TValue>(Action<Ticket, TValue, bool> ticketFunc, TValue value) {
			for (int i = 0, end = ticketsListView.SelectedItems.Count; i < end; i++) {
				var ticket = (Ticket)ticketsListView.SelectedItems[i].Tag;
				ticketFunc(ticket, value, true);
			}

			// Flush.
			Database.Flush();

			// Show tickets.
			ShowTickets();

			UpdateTicket(true);
		}

		private void TicketSingle(Ticket ticket, bool batch, Action<Ticket> changes) {
			bool applied = ticket.UpdateAndGenerateHistoryRecord(TicketChangeFormatter.Default, changes);

			if (!applied || batch) return;

			// Flush.
			Database.Flush();

			// Show tickets.
			ShowTickets();

			UpdateTicket(true);
		}

		private void SetTicketState(TicketState state) {
			TicketBatch(SetTicketState, state);
		}

		private void SetTicketState(Ticket ticket, TicketState state, bool batch = false) {
			TicketSingle(ticket, batch, t => t.State = state);
		}

		private void SetTicketPriority(TicketPriority priority) {
			TicketBatch(SetTicketPriority, priority);
		}

		private void SetTicketPriority(Ticket ticket, TicketPriority priority, bool batch = false) {
			TicketSingle(ticket, batch, t => t.Priority = priority);
		}

		private void SetTicketSeverity(TicketSeverity severity) {
			TicketBatch(SetTicketSeverity, severity);
		}

		private void SetTicketSeverity(Ticket ticket, TicketSeverity severity, bool batch = false) {
			TicketSingle(ticket, batch, t => t.Severity = severity);
		}

		private void SetTicketType(TicketType type) {
			TicketBatch(SetTicketType, type);
		}

		private void SetTicketType(Ticket ticket, TicketType type, bool batch = false) {
			TicketSingle(ticket, batch, t => t.Type = type);
		}

		private void ShowTickets() {
			if (mResettingTicketFilters) return;

			// Save selected tickets.
			var selectedTickets = new List<int>();
			foreach (ListViewItem item in ticketsListView.SelectedItems) {
				var ticket = (Ticket)item.Tag;
				selectedTickets.Add(ticket.ID);
			}

			string summaryFilter = ticketTextBox.Text;
			var reporterFilter = (string)ticketReportersComboBox.SelectedItem;
			var assignedFilter = (string)ticketAssignedToComboBox.SelectedItem;
			string milestoneFilter = (string)ticketMilestoneComboBox.SelectedItem;
			var stateFilter = FormUtil.CastBox<MetaTicketState>(ticketStateComboBox);
			var severityFilter = FormUtil.CastBox<TicketSeverity>(ticketSeverityComboBox);
			var priorityFilter = FormUtil.CastBox<TicketPriority>(ticketPriorityComboBox);
			var typeFilter = FormUtil.CastBox<TicketType>(ticketTypeComboBox);

			Ticket[] tickets = Project.GetTickets();

			tickets = tickets.Where(t => {
				bool satisfiesSummaryFilter = FormUtil.FilterContains(t.Summary, summaryFilter);
				bool satisfiesReporterFilter = FormUtil.FilterMatch(t.ReportedBy, reporterFilter);
				bool satisfiesAssignedFilter = FormUtil.FilterMatch(t.AssignedTo, assignedFilter);
				bool satisfiesMilestoneFilter = FormUtil.FilterMatch(t.GetMilestone().Name, milestoneFilter);
				bool satisfiesStateFilter = stateFilter == null || stateFilter.Value.AppliesTo(t.State);
				bool satisfiesSeverityFilter = FormUtil.FilterEnum(t.Severity, severityFilter);
				bool satisfiesPriorityFilter = FormUtil.FilterEnum(t.Priority, priorityFilter);
				bool satisfiesTypeFilter = FormUtil.FilterEnum(t.Type, typeFilter);
				bool satisfiesCreatedFilter = FormUtil.FilterContains(t.CreateTimestamp, mTicketCreateFilter);
				bool satisfiesModifiedFilter = FormUtil.FilterContains(t.ModifyTimestamp, mTicketModifyFilter);

				return
					satisfiesSummaryFilter &&
					satisfiesReporterFilter &&
					satisfiesAssignedFilter &&
					satisfiesMilestoneFilter &&
					satisfiesStateFilter &&
					satisfiesSeverityFilter &&
					satisfiesPriorityFilter &&
					satisfiesTypeFilter &&
					satisfiesCreatedFilter &&
					satisfiesModifiedFilter;
			}).ToArray();

			// Cache milestones.
			var milestoneNames = new Dictionary<int, string>();
			Milestone[] milestones = Milestone.GetMilestones();
			foreach (Milestone milestone in milestones) {
				milestoneNames[milestone.ID] = milestone.Name;
			}

			ticketsListView.BeginUpdate();
			ticketsListView.Items.Clear();
			foreach (var ticket in tickets) {
				string ticketPriority = TicketChangeFormatter.Default.TranslateTicketPriority(ticket.Priority);
				string ticketType = TicketChangeFormatter.Default.TranslateTicketType(ticket.Type);
				string ticketSeverity = TicketChangeFormatter.Default.TranslateTicketSeverity(ticket.Severity);
				string ticketState = TicketChangeFormatter.Default.TranslateTicketState(ticket.State);

				var lvi = new ListViewItem();

				lvi.Text = $"{ticket.TicketNumber}";
				lvi.SubItems.Add(ticket.Summary);
				lvi.SubItems.Add(milestoneNames[ticket.MilestoneID]);
				lvi.SubItems.Add(ticketPriority);
				lvi.SubItems.Add(ticketType);
				lvi.SubItems.Add(ticketSeverity);
				lvi.SubItems.Add(ticketState);
				lvi.Tag = ticket;

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

			UpdateButtonsEnabledProperty();
		}

		private void AddTicket() {
			Milestone[] milestones = Project.GetMilestones();
			if (milestones.Length == 0) {
				MessageBox.Show(
					Resources.String_PleaseAddAMilestoneBeforeAddingATicket,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));
				tabControl.SelectedTab = milestonesTabPage;
				return;
			}

			using (var form = new TicketDetailsForm(Project, null)) {
				form.ShowMilestones(milestones);

				form.Type = TicketType.Task;
				form.Severity = TicketSeverity.Normal;
				form.State = TicketState.Accepted;
				form.Priority = TicketPriority.Normal;
				if (milestones.Count() == 1) {
					form.Milestone = milestones.First();
				}

				form.InitializeNewTicket(FormUtil.GetFontContext());

				Again:
				if (form.ShowDialog() == DialogResult.OK) {
					// Check milestone.
					if (form.Milestone == null) {
						MessageBox.Show(
							Resources.String_PleaseSelectAMilestone,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check summary.
					if (string.IsNullOrWhiteSpace(form.Summary)) {
						MessageBox.Show(
							Resources.String_TheTicketSummaryCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check type.
					if (form.Type == (TicketType)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketType,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check severity.
					if (form.Severity == (TicketSeverity)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketSeverity,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check state.
					if (form.State == (TicketState)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketState,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check priority.
					if (form.Priority == (TicketPriority)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketPriority,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check description.
					if (string.IsNullOrWhiteSpace(form.Description)) {
						MessageBox.Show(
							Resources.String_TheTicketDescriptionCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					Milestone milestone = form.Milestone;
					Ticket ticket = milestone.NewTicket();
					form.RetrieveTicket(ticket);

					// Add.
					ticket.Add();

					// Flush.
					Database.Flush();

					// Create ticket history entry.
					TicketHistory ticketHistory = ticket.NewHistory(Resources.String_TicketCreated);
					ticketHistory.Add();

					// Show tickets.
					ShowTickets();

					// Select new ticket.
					ticketsListView.SelectedItems.Clear();
					foreach (ListViewItem item in ticketsListView.Items) {
						var t = (Ticket)item.Tag;
						if (t.ID == ticket.ID) {
							item.Selected = true;
							item.EnsureVisible();
							break;
						}
					}

					UpdateButtonsEnabledProperty();

					ticketsListView.Focus();

					UpdateTicket(true);
				}
			}
		}

		private void ShowTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;

			using (var form = new TicketDetailsForm(Project, ticket)) {
				Milestone[] milestones = Project.GetMilestones();
				form.ShowMilestones(milestones);

				form.ShowTicket(ticket, FormUtil.GetFormatter(), FormUtil.GetFontContext());
				form.ReadOnly = true;

				form.ShowDialog();
			}
		}

		private void EditTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;

			using (var form = new TicketDetailsForm(Project, ticket)) {
				Milestone[] milestones = Project.GetMilestones();
				form.ShowMilestones(milestones);

				form.ShowTicket(ticket, FormUtil.GetFormatter(), FormUtil.GetFontContext());

				Again:
				if (form.ShowDialog() == DialogResult.OK) {
					// Check milestone.
					if (form.Milestone == null) {
						MessageBox.Show(
							Resources.String_PleaseSelectAMilestone,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check summary.
					if (string.IsNullOrWhiteSpace(form.Summary)) {
						MessageBox.Show(
							Resources.String_TheTicketSummaryCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check type.
					if (form.Type == (TicketType)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketType,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check severity.
					if (form.Severity == (TicketSeverity)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketSeverity,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check state.
					if (form.State == (TicketState)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketState,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check priority.
					if (form.Priority == (TicketPriority)(-1)) {
						MessageBox.Show(
							Resources.String_PleaseSpecifyTicketPriority,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					// Check description.
					if (string.IsNullOrWhiteSpace(form.Description)) {
						MessageBox.Show(
							Resources.String_TheTicketDescriptionCannotBeBlank,
							Resources.String_Error,
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1,
							FormUtil.GetMessageBoxOptions(this));
						goto Again;
					}

					ticket.UpdateAndGenerateHistoryRecord(TicketChangeFormatter.Default, t => {
						form.RetrieveTicket(t);
					});

					// Flush.
					Database.Flush();

					// Show tickets.
					ShowTickets();

					UpdateTicket(true);
				}
			}
		}

		private void ShowTicketHistory() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new TicketHistoryForm(ticket)) {
				form.ShowDialog();
			}
		}

		private void ShowAttachments() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var ticket = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new AttachmentsForm(ticket)) {
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
				ticket.Delete();
			}

			// Flush.
			Database.Flush();

			// Show tickets.
			ShowTickets();

			mMainForm.UpdateTicketOrProject();
		}
		#endregion

		private void PopulateTicketFilters() {
			FormUtil.UpdateUserBoxWithSelectedItem(ticketReportersComboBox, Ticket.GetReporters());
			FormUtil.UpdateUserBoxWithSelectedItem(ticketAssignedToComboBox, Ticket.GetAssignees());
			FormUtil.UpdateUserBoxWithSelectedItem(
				ticketMilestoneComboBox,
				Project.GetMilestones().Select(m => m.Name),
				hasEmptyItem: true);
		}

		private void ResetTicketFilters() {
			mResettingTicketFilters = true;
			ticketTextBox.Text = string.Empty;
			FormUtil.SetOrDefault(ticketAssignedToComboBox);
			FormUtil.SetOrDefault(ticketReportersComboBox);
			FormUtil.SetOrDefault(ticketPriorityComboBox);
			FormUtil.SetOrDefault(ticketSeverityComboBox);
			FormUtil.SetOrDefault(ticketStateComboBox);
			FormUtil.SetOrDefault(ticketTypeComboBox);
			mTicketModifyFilter = null;
			modifiedTextBox.Text = string.Empty;
			mTicketCreateFilter = null;
			createdTextBox.Text = string.Empty;
			ticketMilestoneComboBox.SelectedItem = null;
			mResettingTicketFilters = false;
		}

		internal void ActivateTicketTab() {
			tabControl.SelectedTab = ticketsTabPage;
		}

		internal void UpdateSettings() {
			FormUtil.FormatDateFilter(createdTextBox, mTicketCreateFilter);
			FormUtil.FormatDateFilter(modifiedTextBox, mTicketModifyFilter);

			// Because ticket details forms (history too) are modal and prevent usage of the main application, we can safely assume here that we don't need to update them
			// That is, ticket details can't be open while options change
		}

		internal void UpdateTicket() {
			UpdateTicket(false);
		}

		private void UpdateTicket(bool privateCall) {
			PopulateTicketFilters();

			// Without this bool, this would end up in an infinite loop
			// This is due to the fact that updating a ticket may add an assignee/reporter and all dialogs must be updated to account for it
			if (privateCall)
				mMainForm.UpdateTicketOrProject();
		}
		#endregion
	}
}

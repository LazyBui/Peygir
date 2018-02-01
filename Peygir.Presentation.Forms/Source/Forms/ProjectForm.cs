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
		private FormContext mContext = null;
		private bool mResettingTicketFilters = false;
		private DateRange mTicketCreateFilter = null;
		private DateRange mTicketModifyFilter = null;

		public Project Project { get; private set; }

		public ProjectForm(MainForm mainForm, FormContext context, Project project) {
			if (mainForm == null) throw new ArgumentNullException(nameof(mainForm));
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (project == null) throw new ArgumentNullException(nameof(project));

			mMainForm = mainForm;
			mContext = context;
			Project = project;

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
			UpdateTitlebar();
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
		private void ticketSummaryTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketSummaryTextBox_TextChanged(object sender, EventArgs e) {
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
		#endregion

		#region Utility functions
		private void UpdateTitlebar() {
			Text = "Project - " + Project.Name;
		}

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
			using (var form = new ProjectDetailsForm(mContext, Project)) {
				if (form.ShowDialog() != DialogResult.OK) return;
				Project = form.RetrieveProject(Project);

				// Update project.
				Project.Update(mContext);

				// Flush.
				mContext.Flush();

				UpdateTitlebar();
				ShowProjectDetails();

				mMainForm.UpdateProject();
			}
		}

		#region Milestone
		private void ShowMilestones() {
			FormUtil.Reselect<Milestone>(milestonesListView, () => {
				Milestone[] milestones = Project.GetMilestones(mContext);

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

					Ticket[] tickets = Ticket.GetTickets(mContext, milestone.ID);
					var lvi = new ListViewItem() {
						Text = milestone.Name,
						Tag = milestone,
					};

					lvi.SubItems.Add(milestoneState);
					lvi.SubItems.Add(tickets.Count(t => t.State.IsOpen()).ToString());
					lvi.SubItems.Add(tickets.Length.ToString());
					milestonesListView.Items.Add(lvi);
				}
				milestonesListView.EndUpdate();
				milestonesListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			});

			UpdateButtonsEnabledProperty();
			ShowTickets();
		}

		private void AddMilestone() {
			using (var form = new MilestoneDetailsForm(mContext, Project, null)) {
				if (form.ShowDialog() != DialogResult.OK) return;
				Milestone milestone = form.RetrieveMilestone();

				// Add.
				milestone.Add(mContext);

				// Flush.
				mContext.Flush();

				// Show milestones.
				ShowMilestones();

				FormUtil.SelectNew(milestonesListView, milestone);

				PopulateTicketFilters();

				UpdateButtonsEnabledProperty();

				milestonesListView.Focus();
			}
		}

		private void ShowMilestone() {
			if (milestonesListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Milestone)milestonesListView.SelectedItems[0].Tag;
			using (var form = new MilestoneDetailsForm(mContext, Project, tag)) {
				form.ReadOnly = true;
				form.ShowDialog();
			}
		}

		private void EditMilestone() {
			if (milestonesListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Milestone)milestonesListView.SelectedItems[0].Tag;
			using (var form = new MilestoneDetailsForm(mContext, Project, tag)) {
				if (form.ShowDialog() != DialogResult.OK) return;
				tag = form.RetrieveMilestone(tag);

				// Update milestones.
				tag.Update(mContext);

				// Flush.
				mContext.Flush();

				// Show milestones.
				ShowMilestones();

				PopulateTicketFilters();

				// Tickets will have outdated naming potentially if we don't update the ticket display
				ShowTickets();

				mMainForm.UpdateMilestone();
			}
		}

		private void DeleteMilestone() {
			if (milestonesListView.SelectedItems.Count == 0) return;

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

			FormUtil.DeleteSelected<Milestone>(milestonesListView, mContext);

			// Flush.
			mContext.Flush();

			// Show milestones.
			ShowMilestones();

			PopulateTicketFilters();

			// Tickets may change as the result of removing a milestone
			ShowTickets();

			mMainForm.UpdateTicket();
		}
		#endregion

		#region Ticket
		private void TicketBatch<TValue>(Action<Ticket, TValue, bool> ticketFunc, TValue value) {
			for (int i = 0, end = ticketsListView.SelectedItems.Count; i < end; i++) {
				var tag = (Ticket)ticketsListView.SelectedItems[i].Tag;
				ticketFunc(tag, value, true);
			}

			// Flush.
			mContext.Flush();

			// Show tickets.
			ShowTickets();

			UpdateTicket(true);
		}

		private void TicketSingle(Ticket ticket, bool batch, Func<Ticket, Ticket> changes) {
			bool applied = ticket.UpdateAndGenerateHistoryRecord(mContext, TicketChangeFormatter.Default, changes);

			if (!applied || batch) return;

			// Flush.
			mContext.Flush();

			// Show tickets.
			ShowTickets();

			UpdateTicket(true);
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
			if (mResettingTicketFilters) {
				return;
			}

			FormUtil.Reselect<Ticket>(ticketsListView, () => {
				string summaryFilter = ticketSummaryTextBox.Text;
				var reporterFilter = (string)ticketReportersComboBox.SelectedItem;
				var assignedFilter = (string)ticketAssignedToComboBox.SelectedItem;
				string milestoneFilter = (string)ticketMilestoneComboBox.SelectedItem;
				var stateFilter = FormUtil.CastBoxToEnum<MetaTicketState>(ticketStateComboBox);
				var severityFilter = FormUtil.CastBoxToEnum<TicketSeverity>(ticketSeverityComboBox);
				var priorityFilter = FormUtil.CastBoxToEnum<TicketPriority>(ticketPriorityComboBox);
				var typeFilter = FormUtil.CastBoxToEnum<TicketType>(ticketTypeComboBox);

				Ticket[] tickets = Project.GetTickets(mContext);

				tickets = tickets.Where(t => {
					bool satisfiesSummaryFilter = FormUtil.SatisfiesFilterContains(t.Summary, summaryFilter);
					bool satisfiesReporterFilter = FormUtil.SatisfiesFilterMatch(t.ReportedBy, reporterFilter);
					bool satisfiesAssignedFilter = FormUtil.SatisfiesFilterMatch(t.AssignedTo, assignedFilter);
					bool satisfiesMilestoneFilter = FormUtil.SatisfiesFilterMatch(t.GetMilestone(mContext).Name, milestoneFilter);
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
				Milestone[] milestones = Milestone.GetMilestones(mContext);
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
			});

			UpdateButtonsEnabledProperty();
		}

		private void AddTicket() {
			Milestone[] milestones = Project.GetMilestones(mContext);
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

			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), Project, null)) {
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

				FormUtil.SelectNew(ticketsListView, ticket);

				UpdateButtonsEnabledProperty();

				ticketsListView.Focus();

				UpdateTicket(true);
			}
		}

		private void ShowTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), Project, tag)) {
				form.ReadOnly = true;
				form.ShowDialog();
			}
		}

		private void EditTicket() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new TicketDetailsForm(mContext, FormUtil.GetFontContext(), FormUtil.GetFormatter(), Project, tag)) {
				if (form.ShowDialog() != DialogResult.OK) return;

				tag.UpdateAndGenerateHistoryRecord(mContext, TicketChangeFormatter.Default, t => {
					return form.RetrieveTicket(t);
				});

				// Flush.
				mContext.Flush();

				// Show tickets.
				ShowTickets();

				UpdateTicket(true);
			}
		}

		private void ShowTicketHistory() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new TicketHistoryForm(mContext, tag)) {
				form.ShowDialog();
			}
		}

		private void ShowAttachments() {
			if (ticketsListView.SelectedItems.Count != 1) {
				return;
			}

			var tag = (Ticket)ticketsListView.SelectedItems[0].Tag;
			using (var form = new AttachmentsForm(mContext, tag)) {
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

			FormUtil.DeleteSelected<Ticket>(ticketsListView, mContext);

			// Flush.
			mContext.Flush();

			// Show tickets.
			ShowTickets();

			UpdateTicket(true);
		}
		#endregion

		private void PopulateTicketFilters() {
			FormUtil.UpdateUserBoxWithSelectedItem(ticketReportersComboBox, Ticket.GetReporters(mContext));
			FormUtil.UpdateUserBoxWithSelectedItem(ticketAssignedToComboBox, Ticket.GetAssignees(mContext));
			FormUtil.UpdateUserBoxWithSelectedItem(
				ticketMilestoneComboBox,
				Project.GetMilestones(mContext).Select(m => m.Name),
				hasEmptyItem: true);
		}

		private void ResetTicketFilters() {
			mResettingTicketFilters = true;
			ticketSummaryTextBox.Text = string.Empty;
			FormUtil.SetOrDefault(ticketAssignedToComboBox);
			FormUtil.SetOrDefault(ticketReportersComboBox);
			FormUtil.SetOrDefault(ticketPriorityComboBox);
			FormUtil.SetOrDefault(ticketSeverityComboBox);
			FormUtil.SetOrDefault(ticketStateComboBox);
			FormUtil.SetOrDefault(ticketTypeComboBox);
			mTicketModifyFilter = null;
			ticketModifiedTextBox.Text = string.Empty;
			mTicketCreateFilter = null;
			ticketCreatedTextBox.Text = string.Empty;
			ticketMilestoneComboBox.SelectedItem = null;
			mResettingTicketFilters = false;
		}

		internal void ActivateTicketTab() {
			tabControl.SelectedTab = ticketsTabPage;
		}

		internal void ActivateProjectTab() {
			tabControl.SelectedTab = projectInfoTabPage;
		}

		internal void UpdateSettings() {
			FormUtil.FormatDateFilter(ticketCreatedTextBox, mTicketCreateFilter);
			FormUtil.FormatDateFilter(ticketModifiedTextBox, mTicketModifyFilter);

			// Because ticket details forms (history too) are modal and prevent usage of the main application, we can safely assume here that we don't need to update them
			// That is, ticket details can't be open while options change
		}

		internal void SaveDatabaseAs(FormContext context) {
			mContext = context;
		}

		internal void UpdateTicket() {
			UpdateTicket(false);
		}

		private void UpdateTicket(bool privateCall) {
			PopulateTicketFilters();

			// Without this bool, this would end up in an infinite loop
			// This is due to the fact that updating a ticket may add an assignee/reporter and all dialogs must be updated to account for it
			if (privateCall)
				mMainForm.UpdateTicket();
		}
		#endregion
	}
}

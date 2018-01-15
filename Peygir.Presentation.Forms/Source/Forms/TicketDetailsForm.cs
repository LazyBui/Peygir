using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class TicketDetailsForm : Form {
		private bool readOnly;
		private FontContext mFontContext;
		private FormContext mContext;
		private DateTimeFormatter mFormatter;
		private Project mProject;
		private Ticket mTicket;

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public TicketDetailsForm(
			FormContext context,
			FontContext font,
			DateTimeFormatter formatter,
			Project project,
			Ticket ticket)
		{
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (font == null) throw new ArgumentNullException(nameof(font));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));

			mContext = context;
			mFontContext = font;
			mFormatter = formatter;
			mProject = project;
			mTicket = ticket;

			InitializeComponent();

			SetTitle();
			InitializeFontContext();
			InitializeComboBoxes(
				project != null ?
					new[] { project } :
					Project.GetProjects(context),
				project != null ?
					mProject.GetMilestones(context) :
					new Milestone[0]);
			InitializeTicketControls();

			ReadOnly = false;
		}

		private void SetTitle() {
			if (object.ReferenceEquals(mProject, null)) {
				Text = "New Ticket";
			}
			else if (object.ReferenceEquals(mTicket, null)) {
				Text = mProject.Name + " - New Ticket";
			}
			else {
				Text = mProject.Name + " - " + mTicket.Summary;
			}
		}

		private void InitializeFontContext() {
			if (mFontContext.UseSansSerif) {
				descriptionTextBox.Font = mFontContext.SansSerif;
			}
			else {
				monospaceButton.Checked = true;
				descriptionTextBox.Font = mFontContext.Monospace;
			}

			if (!mFontContext.WordWrap) {
				wordWrapCheckBox.Checked = false;
				descriptionTextBox.WordWrap = false;
			}
		}

		private void InitializeTicketControls() {
			if (object.ReferenceEquals(mTicket, null)) {
				// Set defaults
				typeComboBox.SelectedIndex = (int)TicketType.Task;
				severityComboBox.SelectedIndex = (int)TicketSeverity.Normal;
				stateComboBox.SelectedIndex = (int)TicketState.Accepted;
				priorityComboBox.SelectedIndex = (int)TicketPriority.Normal;
			}
			else {
				ticketNumberTextBox.Text = string.Format("{0}", mTicket.TicketNumber);
				summaryTextBox.Text = mTicket.Summary;
				reportedByComboBox.Text = mTicket.ReportedBy;
				assignedToComboBox.Text = mTicket.AssignedTo;
				descriptionTextBox.Text = mTicket.Description;
				typeComboBox.SelectedIndex = (int)mTicket.Type;
				severityComboBox.SelectedIndex = (int)mTicket.Severity;
				stateComboBox.SelectedIndex = (int)mTicket.State;
				priorityComboBox.SelectedIndex = (int)mTicket.Priority;
				createdTextBox.Text = mFormatter.Format(mTicket.CreateTimestamp);
				modifiedTextBox.Text = mFormatter.Format(mTicket.ModifyTimestamp);
			}
		}

		private void InitializeComboBoxes(Project[] projects, Milestone[] milestones) {
			// Milestones intentionally first because updating the project combo (e.g. if there's only one project) could be overwritten otherwise
			milestoneComboBox.BeginUpdate();
			milestoneComboBox.Items.Clear();
			milestoneComboBox.Items.AddRange(milestones);
			milestoneComboBox.EndUpdate();
			if (mTicket != null) {
				milestoneComboBox.SelectedIndex = -1;
				for (int i = 0; i < milestoneComboBox.Items.Count; i++) {
					var milestone = (Milestone)milestoneComboBox.Items[i];
					if (milestone.ID == mTicket.MilestoneID) {
						milestoneComboBox.SelectedIndex = i;
						break;
					}
				}
			}
			else if (milestones.Length == 1) {
				milestoneComboBox.SelectedItem = milestones[0];
			}
			else if (milestones.Length == 0) {
				milestoneComboBox.Enabled = false;
			}

			projectComboBox.BeginUpdate();
			projectComboBox.Items.Clear();
			projectComboBox.Items.AddRange(projects);
			projectComboBox.EndUpdate();
			if (mProject != null) {
				projectComboBox.SelectedIndex = -1;
				int projectId = mProject.ID;
				for (int i = 0; i < projectComboBox.Items.Count; i++) {
					var project = (Project)projectComboBox.Items[i];
					if (project.ID == projectId) {
						projectComboBox.SelectedIndex = i;
						break;
					}
				}
				projectComboBox.Enabled = false;
			}
			else if (projects.Length == 1) {
				projectComboBox.SelectedItem = projects[0];
				projectComboBox.Enabled = false;
			}

			reportedByComboBox.Items.Clear();
			reportedByComboBox.Items.AddRange(Ticket.GetReporters(mContext));

			assignedToComboBox.Items.Clear();
			assignedToComboBox.Items.AddRange(Ticket.GetAssignees(mContext));
		}

		public Ticket RetrieveTicket(Ticket @base = null) {
			var ticket = @base;
			var milestone = (Milestone)milestoneComboBox.SelectedItem;
			if (ticket == null) {
				ticket = milestone.NewTicket(mContext);
			}

			ticket.MilestoneID = milestone.ID;
			ticket.Summary = summaryTextBox.Text;
			ticket.ReportedBy = reportedByComboBox.Text.Substring(0, Math.Min(255, reportedByComboBox.Text.Length)); // Max 255 characters.
			ticket.Type = (TicketType)typeComboBox.SelectedIndex;
			ticket.Severity = (TicketSeverity)severityComboBox.SelectedIndex;
			ticket.State = (TicketState)stateComboBox.SelectedIndex;
			ticket.AssignedTo = assignedToComboBox.Text.Substring(0, Math.Min(255, assignedToComboBox.Text.Length)); // Max 255 characters.
			ticket.Priority = (TicketPriority)priorityComboBox.SelectedIndex;
			ticket.Description = descriptionTextBox.Text;
			return ticket;
		}

		private void UpdateReadOnlyState() {
			projectComboBox.Enabled = !readOnly && projectComboBox.Items.Count > 1;
			milestoneComboBox.Enabled = !readOnly && milestoneComboBox.Items.Count > 0;
			summaryTextBox.ReadOnly = readOnly;
			reportedByComboBox.Enabled = !readOnly;
			typeComboBox.Enabled = !readOnly;
			severityComboBox.Enabled = !readOnly;
			stateComboBox.Enabled = !readOnly;
			assignedToComboBox.Enabled = !readOnly;
			priorityComboBox.Enabled = !readOnly;
			descriptionTextBox.ReadOnly = readOnly;
		}

		private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			int selectedIndex = projectComboBox.SelectedIndex;

			milestoneComboBox.BeginUpdate();
			milestoneComboBox.SelectedItem = null;
			milestoneComboBox.Items.Clear();
			milestoneComboBox.Enabled = false;
			if (selectedIndex != -1) {	
				var project = (Project)projectComboBox.SelectedItem;
				var milestones = project.GetMilestones(mContext);
				if (!milestones.Any()) {
					DialogResult result = MessageBox.Show(
						Resources.String_AskUserAboutMilestone,
						Resources.String_Error,
						MessageBoxButtons.YesNoCancel,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1,
						FormUtil.GetMessageBoxOptions(this));
					
					if (result == DialogResult.Yes) {
						using (var form = new MilestoneDetailsForm(mContext, project, null)) {
							if (form.ShowDialog() != DialogResult.OK) return;
							Milestone milestone = form.RetrieveMilestone();

							// Add.
							milestone.Add(mContext);

							// Flush.
							mContext.Flush();

							milestones = new[] { milestone };
						}
					}
				}
				milestoneComboBox.Items.AddRange(milestones);
				milestoneComboBox.Enabled = milestones.Any();
				if (milestones.Length == 1) {
					milestoneComboBox.SelectedItem = milestones[0];
				}
			}
			milestoneComboBox.EndUpdate();
		}

		private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void summaryTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void ticketNumberTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void createdTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void modifiedTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void sansSerifButton_CheckedChanged(object sender, EventArgs e) {
			if (!sansSerifButton.Checked) return;
			descriptionTextBox.Font = mFontContext.SansSerif;
		}

		private void monospaceButton_CheckedChanged(object sender, EventArgs e) {
			if (!monospaceButton.Checked) return;
			descriptionTextBox.Font = mFontContext.Monospace;
		}

		private void wordWrapCheckBox_CheckedChanged(object sender, EventArgs e) {
			descriptionTextBox.WordWrap = wordWrapCheckBox.Checked;
		}

		private void TicketDetailsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (DialogResult != DialogResult.OK) return;
	
			var problems = new List<string>();
			if (milestoneComboBox.SelectedItem == null) problems.Add(Resources.String_PleaseSelectAMilestone);
			if (string.IsNullOrWhiteSpace(summaryTextBox.Text)) problems.Add(Resources.String_TheTicketSummaryCannotBeBlank);
			if (typeComboBox.SelectedIndex == -1) problems.Add(Resources.String_PleaseSpecifyTicketType);
			if (severityComboBox.SelectedIndex == -1) problems.Add(Resources.String_PleaseSpecifyTicketSeverity);
			if (stateComboBox.SelectedIndex == -1) problems.Add(Resources.String_PleaseSpecifyTicketState);
			if (priorityComboBox.SelectedIndex == -1) problems.Add(Resources.String_PleaseSpecifyTicketPriority);
			if (string.IsNullOrWhiteSpace(descriptionTextBox.Text)) problems.Add(Resources.String_TheTicketDescriptionCannotBeBlank);
			if (!problems.Any()) return;

			MessageBox.Show(
				string.Join(Environment.NewLine, problems),
				Resources.String_Error,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			e.Cancel = true;
		}
	}
}

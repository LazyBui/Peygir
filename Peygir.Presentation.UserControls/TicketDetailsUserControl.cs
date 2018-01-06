using System;
using System.Drawing;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class TicketDetailsUserControl : UserControl {
		private bool readOnly;
		private static readonly Font SansSerif = new Font("Tahoma", 8.5f, GraphicsUnit.Point);
		private static readonly Font Monospace = new Font("Courier New", 9f, GraphicsUnit.Point);

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public ComboBox MilestoneComboBox {
			get {
				return milestoneComboBox;
			}
		}

		public Milestone Milestone {
			get {
				return (Milestone)milestoneComboBox.SelectedItem;
			}
			set {
				if (value == null) {
					milestoneComboBox.SelectedIndex = -1;
				}
				else {
					milestoneComboBox.SelectedIndex = -1;
					for (int i = 0; i < milestoneComboBox.Items.Count; i++) {
						Milestone milestone = (Milestone)milestoneComboBox.Items[i];
						if (milestone.ID == value.ID) {
							milestoneComboBox.SelectedIndex = i;
							break;
						}
					}
				}
			}
		}

		public string Summary {
			get { return summaryTextBox.Text; }
			set { summaryTextBox.Text = value; }
		}

		public string ReportedBy {
			get { return reportedByComboBox.Text; }
			set { reportedByComboBox.Text = value; }
		}

		public TicketType Type {
			get { return (TicketType)typeComboBox.SelectedIndex; }
			set { typeComboBox.SelectedIndex = (int)value; }
		}

		public TicketSeverity Severity {
			get { return (TicketSeverity)severityComboBox.SelectedIndex; }
			set { severityComboBox.SelectedIndex = (int)value; }
		}

		public TicketState State {
			get { return (TicketState)stateComboBox.SelectedIndex; }
			set { stateComboBox.SelectedIndex = (int)value; }
		}

		public string AssignedTo {
			get { return assignedToComboBox.Text; }
			set { assignedToComboBox.Text = value; }
		}

		public TicketPriority Priority {
			get { return (TicketPriority)priorityComboBox.SelectedIndex; }
			set { priorityComboBox.SelectedIndex = (int)value; }
		}

		public string Description {
			get { return descriptionTextBox.Text; }
			set { descriptionTextBox.Text = value; }
		}

		public TicketDetailsUserControl() {
			InitializeComponent();

			ReadOnly = false;
		}

		public void ShowMilestones(Milestone[] milestones) {
			if (milestones == null) {
				throw new ArgumentNullException(nameof(milestones));
			}

			milestoneComboBox.BeginUpdate();
			milestoneComboBox.Items.Clear();
			milestoneComboBox.Items.AddRange(milestones);
			milestoneComboBox.EndUpdate();

			reportedByComboBox.Items.Clear();
			reportedByComboBox.Items.AddRange(Ticket.GetReporters());

			assignedToComboBox.Items.Clear();
			assignedToComboBox.Items.AddRange(Ticket.GetAssignees());
		}

		public void ShowTicket(Ticket ticket, DateTimeFormatter formatter) {
			if (ticket == null) {
				throw new ArgumentNullException(nameof(ticket));
			}

			milestoneComboBox.SelectedIndex = -1;
			for (int i = 0; i < milestoneComboBox.Items.Count; i++) {
				Milestone milestone = (Milestone)milestoneComboBox.Items[i];
				if (milestone.ID == ticket.MilestoneID) {
					milestoneComboBox.SelectedIndex = i;
					break;
				}
			}

			ticketNumberTextBox.Text = string.Format("{0}", ticket.TicketNumber);
			summaryTextBox.Text = ticket.Summary;
			reportedByComboBox.Text = ticket.ReportedBy;
			typeComboBox.SelectedIndex = (int)ticket.Type;
			severityComboBox.SelectedIndex = (int)ticket.Severity;
			stateComboBox.SelectedIndex = (int)ticket.State;
			assignedToComboBox.Text = ticket.AssignedTo;
			priorityComboBox.SelectedIndex = (int)ticket.Priority;
			descriptionTextBox.Text = ticket.Description;
			createdTextBox.Text = formatter.Format(ticket.CreateTimestamp);
			modifiedTextBox.Text = formatter.Format(ticket.ModifyTimestamp);
		}

		public void RetrieveTicket(Ticket ticket) {
			if (ticket == null) {
				throw new ArgumentNullException(nameof(ticket));
			}

			Milestone milestone = (Milestone)milestoneComboBox.SelectedItem;

			ticket.MilestoneID = milestone.ID;
			ticket.Summary = summaryTextBox.Text;
			ticket.ReportedBy = reportedByComboBox.Text.Substring(0, Math.Min(255, reportedByComboBox.Text.Length)); // Max 255 characters.
			ticket.Type = (TicketType)typeComboBox.SelectedIndex;
			ticket.Severity = (TicketSeverity)severityComboBox.SelectedIndex;
			ticket.State = (TicketState)stateComboBox.SelectedIndex;
			ticket.AssignedTo = assignedToComboBox.Text.Substring(0, Math.Min(255, assignedToComboBox.Text.Length)); // Max 255 characters.
			ticket.Priority = (TicketPriority)priorityComboBox.SelectedIndex;
			ticket.Description = descriptionTextBox.Text;
		}

		private void UpdateReadOnlyState() {
			milestoneComboBox.Enabled = !readOnly;
			summaryTextBox.ReadOnly = readOnly;
			reportedByComboBox.Enabled = !readOnly;
			typeComboBox.Enabled = !readOnly;
			severityComboBox.Enabled = !readOnly;
			stateComboBox.Enabled = !readOnly;
			assignedToComboBox.Enabled = !readOnly;
			priorityComboBox.Enabled = !readOnly;
			descriptionTextBox.ReadOnly = readOnly;
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
			descriptionTextBox.Font = SansSerif;
		}

		private void monospaceButton_CheckedChanged(object sender, EventArgs e) {
			if (!monospaceButton.Checked) return;
			descriptionTextBox.Font = Monospace;
		}

		private void wordWrapCheckBox_CheckedChanged(object sender, EventArgs e) {
			descriptionTextBox.WordWrap = wordWrapCheckBox.Checked;
		}
	}
}

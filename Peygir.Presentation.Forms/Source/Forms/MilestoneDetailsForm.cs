using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class MilestoneDetailsForm : Form {
		private bool readOnly;
		private FormContext mContext;
		private Milestone mMilestone;
		private Project mProject;

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public MilestoneDetailsForm(FormContext context, Project project, Milestone milestone) {
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (project == null) throw new ArgumentNullException(nameof(project));

			mContext = context;
			mProject = project;
			mMilestone = milestone;

			InitializeComponent();

			InitializeMilestoneControls();

			ReadOnly = false;
		}

		private void InitializeMilestoneControls() {
			if (object.ReferenceEquals(mMilestone, null)) {
				// Set defaults
				stateComboBox.SelectedIndex = (int)MilestoneState.Active;
			}
			else {
				nameTextBox.Text = mMilestone.Name;
				stateComboBox.SelectedIndex = (int)mMilestone.State;
				displayOrderNumericUpDown.Value = Math.Min(mMilestone.DisplayOrder, displayOrderNumericUpDown.Maximum);
				descriptionTextBox.Text = mMilestone.Description;
			}
		}

		public Milestone RetrieveMilestone(Milestone @base = null) {
			Milestone milestone = @base;
			if (milestone == null) {
				milestone = mProject.NewMilestone(mContext);
			}

			milestone.Name = nameTextBox.Text;
			milestone.State = (MilestoneState)stateComboBox.SelectedIndex;
			milestone.DisplayOrder = (int)displayOrderNumericUpDown.Value;
			milestone.Description = descriptionTextBox.Text;

			return milestone;
		}

		private void UpdateReadOnlyState() {
			nameTextBox.ReadOnly = readOnly;
			stateComboBox.Enabled = !readOnly;
			displayOrderNumericUpDown.ReadOnly = readOnly;
			descriptionTextBox.ReadOnly = readOnly;
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void MilestoneDetailsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (DialogResult != DialogResult.OK) return;
	
			var problems = new List<string>();
			if (string.IsNullOrWhiteSpace(nameTextBox.Text)) problems.Add(Resources.String_TheMilestoneNameCannotBeBlank);
			if (stateComboBox.SelectedIndex == -1) problems.Add(Resources.String_PleaseSpecifyMilestoneState);
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

using System;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class ProjectDetailsUserControl : UserControl {
		private bool readOnly;

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public string ProjectName {
			get { return nameTextBox.Text; }
			set { nameTextBox.Text = value; }
		}

		public int DisplayOrder {
			get { return (int)displayOrderNumericUpDown.Value; }
			set { displayOrderNumericUpDown.Value = Math.Min(value, displayOrderNumericUpDown.Maximum); }
		}

		public string Description {
			get { return descriptionTextBox.Text; }
			set { descriptionTextBox.Text = value; }
		}

		public ProjectDetailsUserControl() {
			InitializeComponent();

			ReadOnly = false;
		}

		public void ShowProject(Project project) {
			if (project == null) {
				// Blank
			}
			else {
				nameTextBox.Text = project.Name;
				displayOrderNumericUpDown.Value = Math.Min(project.DisplayOrder, displayOrderNumericUpDown.Maximum);
				descriptionTextBox.Text = project.Description;
			}
		}

		private void UpdateReadOnlyState() {
			nameTextBox.ReadOnly = readOnly;
			displayOrderNumericUpDown.ReadOnly = readOnly;
			descriptionTextBox.ReadOnly = readOnly;
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}
	}
}

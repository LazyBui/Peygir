﻿using System;
using System.ComponentModel;
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

		[ReadOnly(true)]
		[Browsable(false)]
		public string ProjectName {
			get { return nameTextBox.Text; }
		}

		[ReadOnly(true)]
		[Browsable(false)]
		public int DisplayOrder {
			get { return (int)displayOrderNumericUpDown.Value; }
		}

		[ReadOnly(true)]
		[Browsable(false)]
		public string Description {
			get { return descriptionTextBox.Text; }
		}

		[ReadOnly(true)]
		[Browsable(false)]
		public ProjectState State {
			get {
				if (activeRadioButton.Checked) return ProjectState.Active;
				if (inactiveRadioButton.Checked) return ProjectState.Inactive;
				throw new InvalidOperationException();
			}
		}

		public ProjectDetailsUserControl() {
			InitializeComponent();

			ReadOnly = false;
		}

		public void ShowProject(Project project) {
			if (project == null) {
				activeRadioButton.Checked = true;
			}
			else {
				nameTextBox.Text = project.Name;
				displayOrderNumericUpDown.Value = Math.Min(project.DisplayOrder, displayOrderNumericUpDown.Maximum);
				descriptionTextBox.Text = project.Description;
				switch (project.State) {
					case ProjectState.Active:
						activeRadioButton.Checked = true;
						break;
					case ProjectState.Inactive:
						inactiveRadioButton.Checked = true;
						break;
					default: throw new NotImplementedException();
				}
			}
		}

		private void UpdateReadOnlyState() {
			nameTextBox.ReadOnly = readOnly;
			displayOrderNumericUpDown.ReadOnly = readOnly;
			descriptionTextBox.ReadOnly = readOnly;
			activeRadioButton.Enabled = !readOnly;
			inactiveRadioButton.Enabled = !readOnly;
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}
	}
}

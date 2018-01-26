namespace Peygir.Presentation.UserControls {
	partial class ProjectDetailsUserControl {
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectDetailsUserControl));
			this.descriptionTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.displayOrderNumericUpDown = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.nameTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.activeRadioButton = new System.Windows.Forms.RadioButton();
			this.inactiveRadioButton = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.displayOrderNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// descriptionTextBox
			// 
			this.descriptionTextBox.AcceptsReturn = true;
			resources.ApplyResources(this.descriptionTextBox, "descriptionTextBox");
			this.descriptionTextBox.Name = "descriptionTextBox";
			this.descriptionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.descriptionTextBox_KeyDown);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// displayOrderNumericUpDown
			// 
			resources.ApplyResources(this.displayOrderNumericUpDown, "displayOrderNumericUpDown");
			this.displayOrderNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.displayOrderNumericUpDown.Name = "displayOrderNumericUpDown";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// nameTextBox
			// 
			resources.ApplyResources(this.nameTextBox, "nameTextBox");
			this.nameTextBox.Name = "nameTextBox";
			this.nameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nameTextBox_KeyDown);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// activeRadioButton
			// 
			resources.ApplyResources(this.activeRadioButton, "activeRadioButton");
			this.activeRadioButton.Checked = true;
			this.activeRadioButton.Name = "activeRadioButton";
			this.activeRadioButton.TabStop = true;
			this.activeRadioButton.UseVisualStyleBackColor = true;
			// 
			// inactiveRadioButton
			// 
			resources.ApplyResources(this.inactiveRadioButton, "inactiveRadioButton");
			this.inactiveRadioButton.Name = "inactiveRadioButton";
			this.inactiveRadioButton.UseVisualStyleBackColor = true;
			// 
			// ProjectDetailsUserControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.inactiveRadioButton);
			this.Controls.Add(this.activeRadioButton);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.descriptionTextBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.displayOrderNumericUpDown);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.nameTextBox);
			this.Controls.Add(this.label1);
			this.Name = "ProjectDetailsUserControl";
			((System.ComponentModel.ISupportInitialize)(this.displayOrderNumericUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox descriptionTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown displayOrderNumericUpDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox nameTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton activeRadioButton;
		private System.Windows.Forms.RadioButton inactiveRadioButton;
	}
}

namespace Peygir.Presentation.Forms {
	partial class OptionsForm {
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.formatDateTimePanel = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePatternTextBox = new System.Windows.Forms.TextBox();
			this.calendarComboBox = new System.Windows.Forms.ComboBox();
			this.formatDateTimeCheckBox = new System.Windows.Forms.CheckBox();
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageDateTime = new System.Windows.Forms.TabPage();
			this.tabPageText = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.sansSerifTextBox = new System.Windows.Forms.TextBox();
			this.sansSerifButton = new System.Windows.Forms.Button();
			this.monospaceButton = new System.Windows.Forms.Button();
			this.monospaceTextBox = new System.Windows.Forms.TextBox();
			this.wordWrapCheckBox = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.sansSerifRadioButton = new System.Windows.Forms.RadioButton();
			this.monospaceRadioButton = new System.Windows.Forms.RadioButton();
			this.formatDateTimePanel.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPageDateTime.SuspendLayout();
			this.tabPageText.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// textBox2
			// 
			resources.ApplyResources(this.textBox2, "textBox2");
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
			// 
			// formatDateTimePanel
			// 
			this.formatDateTimePanel.Controls.Add(this.label1);
			this.formatDateTimePanel.Controls.Add(this.label2);
			this.formatDateTimePanel.Controls.Add(this.dateTimePatternTextBox);
			this.formatDateTimePanel.Controls.Add(this.calendarComboBox);
			resources.ApplyResources(this.formatDateTimePanel, "formatDateTimePanel");
			this.formatDateTimePanel.Name = "formatDateTimePanel";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// dateTimePatternTextBox
			// 
			resources.ApplyResources(this.dateTimePatternTextBox, "dateTimePatternTextBox");
			this.dateTimePatternTextBox.Name = "dateTimePatternTextBox";
			this.dateTimePatternTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePatternTextBox_KeyDown);
			// 
			// calendarComboBox
			// 
			this.calendarComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.calendarComboBox.FormattingEnabled = true;
			this.calendarComboBox.Items.AddRange(new object[] {
            resources.GetString("calendarComboBox.Items"),
            resources.GetString("calendarComboBox.Items1"),
            resources.GetString("calendarComboBox.Items2"),
            resources.GetString("calendarComboBox.Items3"),
            resources.GetString("calendarComboBox.Items4"),
            resources.GetString("calendarComboBox.Items5"),
            resources.GetString("calendarComboBox.Items6"),
            resources.GetString("calendarComboBox.Items7"),
            resources.GetString("calendarComboBox.Items8"),
            resources.GetString("calendarComboBox.Items9"),
            resources.GetString("calendarComboBox.Items10"),
            resources.GetString("calendarComboBox.Items11"),
            resources.GetString("calendarComboBox.Items12"),
            resources.GetString("calendarComboBox.Items13")});
			resources.ApplyResources(this.calendarComboBox, "calendarComboBox");
			this.calendarComboBox.Name = "calendarComboBox";
			// 
			// formatDateTimeCheckBox
			// 
			resources.ApplyResources(this.formatDateTimeCheckBox, "formatDateTimeCheckBox");
			this.formatDateTimeCheckBox.Name = "formatDateTimeCheckBox";
			this.formatDateTimeCheckBox.UseVisualStyleBackColor = true;
			this.formatDateTimeCheckBox.CheckedChanged += new System.EventHandler(this.formatDateTimeCheckBox_CheckedChanged);
			// 
			// cancelButton
			// 
			resources.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Cancel;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.UseVisualStyleBackColor = true;
			// 
			// okButton
			// 
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_OK;
			this.okButton.Name = "okButton";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPageDateTime);
			this.tabControl1.Controls.Add(this.tabPageText);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPageDateTime
			// 
			this.tabPageDateTime.Controls.Add(this.textBox2);
			this.tabPageDateTime.Controls.Add(this.label3);
			this.tabPageDateTime.Controls.Add(this.formatDateTimePanel);
			this.tabPageDateTime.Controls.Add(this.formatDateTimeCheckBox);
			resources.ApplyResources(this.tabPageDateTime, "tabPageDateTime");
			this.tabPageDateTime.Name = "tabPageDateTime";
			this.tabPageDateTime.UseVisualStyleBackColor = true;
			// 
			// tabPageText
			// 
			this.tabPageText.Controls.Add(this.monospaceRadioButton);
			this.tabPageText.Controls.Add(this.sansSerifRadioButton);
			this.tabPageText.Controls.Add(this.label6);
			this.tabPageText.Controls.Add(this.wordWrapCheckBox);
			this.tabPageText.Controls.Add(this.monospaceButton);
			this.tabPageText.Controls.Add(this.monospaceTextBox);
			this.tabPageText.Controls.Add(this.sansSerifButton);
			this.tabPageText.Controls.Add(this.sansSerifTextBox);
			this.tabPageText.Controls.Add(this.label5);
			this.tabPageText.Controls.Add(this.label4);
			resources.ApplyResources(this.tabPageText, "tabPageText");
			this.tabPageText.Name = "tabPageText";
			this.tabPageText.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// sansSerifTextBox
			// 
			resources.ApplyResources(this.sansSerifTextBox, "sansSerifTextBox");
			this.sansSerifTextBox.Name = "sansSerifTextBox";
			this.sansSerifTextBox.ReadOnly = true;
			// 
			// sansSerifButton
			// 
			this.sansSerifButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			resources.ApplyResources(this.sansSerifButton, "sansSerifButton");
			this.sansSerifButton.Name = "sansSerifButton";
			this.sansSerifButton.UseVisualStyleBackColor = true;
			this.sansSerifButton.Click += new System.EventHandler(this.sansSerifButton_Click);
			// 
			// monospaceButton
			// 
			this.monospaceButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			resources.ApplyResources(this.monospaceButton, "monospaceButton");
			this.monospaceButton.Name = "monospaceButton";
			this.monospaceButton.UseVisualStyleBackColor = true;
			this.monospaceButton.Click += new System.EventHandler(this.monospaceButton_Click);
			// 
			// monospaceTextBox
			// 
			resources.ApplyResources(this.monospaceTextBox, "monospaceTextBox");
			this.monospaceTextBox.Name = "monospaceTextBox";
			this.monospaceTextBox.ReadOnly = true;
			// 
			// wordWrapCheckBox
			// 
			resources.ApplyResources(this.wordWrapCheckBox, "wordWrapCheckBox");
			this.wordWrapCheckBox.Name = "wordWrapCheckBox";
			this.wordWrapCheckBox.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// sansSerifRadioButton
			// 
			resources.ApplyResources(this.sansSerifRadioButton, "sansSerifRadioButton");
			this.sansSerifRadioButton.Name = "sansSerifRadioButton";
			this.sansSerifRadioButton.TabStop = true;
			this.sansSerifRadioButton.UseVisualStyleBackColor = true;
			// 
			// monospaceRadioButton
			// 
			resources.ApplyResources(this.monospaceRadioButton, "monospaceRadioButton");
			this.monospaceRadioButton.Name = "monospaceRadioButton";
			this.monospaceRadioButton.TabStop = true;
			this.monospaceRadioButton.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.okButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OptionsForm";
			this.ShowInTaskbar = false;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
			this.formatDateTimePanel.ResumeLayout(false);
			this.formatDateTimePanel.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPageDateTime.ResumeLayout(false);
			this.tabPageDateTime.PerformLayout();
			this.tabPageText.ResumeLayout(false);
			this.tabPageText.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.CheckBox formatDateTimeCheckBox;
		private System.Windows.Forms.ComboBox calendarComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel formatDateTimePanel;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox dateTimePatternTextBox;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageDateTime;
		private System.Windows.Forms.TabPage tabPageText;
		private System.Windows.Forms.TextBox sansSerifTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button sansSerifButton;
		private System.Windows.Forms.Button monospaceButton;
		private System.Windows.Forms.TextBox monospaceTextBox;
		private System.Windows.Forms.RadioButton monospaceRadioButton;
		private System.Windows.Forms.RadioButton sansSerifRadioButton;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.CheckBox wordWrapCheckBox;
	}
}
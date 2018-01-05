namespace Peygir.Presentation.Forms {
	partial class DateRangeForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangeForm));
			this.cancelButton = new System.Windows.Forms.Button();
			this.okButton = new System.Windows.Forms.Button();
			this.lowBoundCheckbox = new System.Windows.Forms.CheckBox();
			this.highBoundCheckbox = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lowDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.highDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
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
			// lowBoundCheckbox
			// 
			resources.ApplyResources(this.lowBoundCheckbox, "lowBoundCheckbox");
			this.lowBoundCheckbox.Name = "lowBoundCheckbox";
			this.lowBoundCheckbox.UseVisualStyleBackColor = true;
			this.lowBoundCheckbox.CheckedChanged += new System.EventHandler(this.lowBoundCheckbox_CheckedChanged);
			// 
			// highBoundCheckbox
			// 
			resources.ApplyResources(this.highBoundCheckbox, "highBoundCheckbox");
			this.highBoundCheckbox.Name = "highBoundCheckbox";
			this.highBoundCheckbox.UseVisualStyleBackColor = true;
			this.highBoundCheckbox.CheckedChanged += new System.EventHandler(this.highBoundCheckbox_CheckedChanged);
			// 
			// button1
			// 
			resources.ApplyResources(this.button1, "button1");
			this.button1.DialogResult = System.Windows.Forms.DialogResult.No;
			this.button1.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Show;
			this.button1.Name = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// lowDateTimePicker
			// 
			resources.ApplyResources(this.lowDateTimePicker, "lowDateTimePicker");
			this.lowDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.lowDateTimePicker.Name = "lowDateTimePicker";
			this.lowDateTimePicker.ValueChanged += new System.EventHandler(this.lowDateTimePicker_ValueChanged);
			// 
			// highDateTimePicker
			// 
			resources.ApplyResources(this.highDateTimePicker, "highDateTimePicker");
			this.highDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.highDateTimePicker.Name = "highDateTimePicker";
			this.highDateTimePicker.ValueChanged += new System.EventHandler(this.highDateTimePicker_ValueChanged);
			// 
			// DateRangeForm
			// 
			this.AcceptButton = this.okButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancelButton;
			this.Controls.Add(this.highDateTimePicker);
			this.Controls.Add(this.lowDateTimePicker);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.highBoundCheckbox);
			this.Controls.Add(this.lowBoundCheckbox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.okButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateRangeForm";
			this.ShowInTaskbar = false;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.CheckBox lowBoundCheckbox;
		private System.Windows.Forms.CheckBox highBoundCheckbox;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DateTimePicker lowDateTimePicker;
		private System.Windows.Forms.DateTimePicker highDateTimePicker;
	}
}
namespace Peygir.Presentation.Forms {
	partial class TicketHistoryForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketHistoryForm));
			this.groupBox = new System.Windows.Forms.GroupBox();
			this.okButton = new System.Windows.Forms.Button();
			this.ticketHistoryListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.commentTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.changesTextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.timestampTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox
			// 
			resources.ApplyResources(this.groupBox, "groupBox");
			this.groupBox.Controls.Add(this.commentTextBox);
			this.groupBox.Controls.Add(this.label2);
			this.groupBox.Controls.Add(this.changesTextBox);
			this.groupBox.Controls.Add(this.label3);
			this.groupBox.Controls.Add(this.timestampTextBox);
			this.groupBox.Controls.Add(this.label1);
			this.groupBox.Name = "groupBox";
			this.groupBox.TabStop = false;
			// 
			// okButton
			// 
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_OK;
			this.okButton.Name = "okButton";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// ticketHistoryListView
			// 
			this.ticketHistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.ticketHistoryListView.FullRowSelect = true;
			this.ticketHistoryListView.GridLines = true;
			this.ticketHistoryListView.HideSelection = false;
			resources.ApplyResources(this.ticketHistoryListView, "ticketHistoryListView");
			this.ticketHistoryListView.Name = "ticketHistoryListView";
			this.ticketHistoryListView.UseCompatibleStateImageBehavior = false;
			this.ticketHistoryListView.View = System.Windows.Forms.View.Details;
			this.ticketHistoryListView.SelectedIndexChanged += new System.EventHandler(this.ticketHistoryListView_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			resources.ApplyResources(this.columnHeader1, "columnHeader1");
			// 
			// commentTextBox
			// 
			resources.ApplyResources(this.commentTextBox, "commentTextBox");
			this.commentTextBox.Name = "commentTextBox";
			this.commentTextBox.ReadOnly = true;
			this.commentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commentTextBox_KeyDown);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// changesTextBox
			// 
			resources.ApplyResources(this.changesTextBox, "changesTextBox");
			this.changesTextBox.Name = "changesTextBox";
			this.changesTextBox.ReadOnly = true;
			this.changesTextBox.TabStop = false;
			this.changesTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.changesTextBox_KeyDown);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// timestampTextBox
			// 
			resources.ApplyResources(this.timestampTextBox, "timestampTextBox");
			this.timestampTextBox.Name = "timestampTextBox";
			this.timestampTextBox.ReadOnly = true;
			this.timestampTextBox.TabStop = false;
			this.timestampTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.timestampTextBox_KeyDown);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// TicketHistoryForm
			// 
			this.AcceptButton = this.okButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.Controls.Add(this.ticketHistoryListView);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.groupBox);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TicketHistoryForm";
			this.ShowInTaskbar = false;
			this.groupBox.ResumeLayout(false);
			this.groupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.ListView ticketHistoryListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox commentTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox changesTextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox timestampTextBox;
		private System.Windows.Forms.Label label1;
	}
}
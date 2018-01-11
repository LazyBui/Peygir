namespace Peygir.Presentation.Forms {
	partial class AttachmentsForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentsForm));
			this.addButton = new System.Windows.Forms.Button();
			this.saveButton = new System.Windows.Forms.Button();
			this.deleteButton = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.okButton = new System.Windows.Forms.Button();
			this.attachmentsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.attachmentsListView = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.attachmentsContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// addButton
			// 
			resources.ApplyResources(this.addButton, "addButton");
			this.addButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addButton.Name = "addButton";
			this.addButton.UseVisualStyleBackColor = true;
			this.addButton.Click += new System.EventHandler(this.addButton_Click);
			// 
			// saveButton
			// 
			resources.ApplyResources(this.saveButton, "saveButton");
			this.saveButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Save;
			this.saveButton.Name = "saveButton";
			this.saveButton.UseVisualStyleBackColor = true;
			this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
			// 
			// deleteButton
			// 
			resources.ApplyResources(this.deleteButton, "deleteButton");
			this.deleteButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteButton.Name = "deleteButton";
			this.deleteButton.UseVisualStyleBackColor = true;
			this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
			// 
			// openFileDialog
			// 
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// saveFileDialog
			// 
			resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
			// 
			// okButton
			// 
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_OK;
			this.okButton.Name = "okButton";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// attachmentsContextMenu
			// 
			this.attachmentsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAttachmentToolStripMenuItem,
            this.saveAttachmentToolStripMenuItem,
            this.deleteAttachmentToolStripMenuItem});
			this.attachmentsContextMenu.Name = "attachmentsContextMenu";
			this.attachmentsContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			resources.ApplyResources(this.attachmentsContextMenu, "attachmentsContextMenu");
			this.attachmentsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.attachmentsContextMenu_Opening);
			// 
			// addAttachmentToolStripMenuItem
			// 
			this.addAttachmentToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addAttachmentToolStripMenuItem.Name = "addAttachmentToolStripMenuItem";
			resources.ApplyResources(this.addAttachmentToolStripMenuItem, "addAttachmentToolStripMenuItem");
			this.addAttachmentToolStripMenuItem.Click += new System.EventHandler(this.addAttachmentToolStripMenuItem_Click);
			// 
			// saveAttachmentToolStripMenuItem
			// 
			this.saveAttachmentToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Save;
			this.saveAttachmentToolStripMenuItem.Name = "saveAttachmentToolStripMenuItem";
			resources.ApplyResources(this.saveAttachmentToolStripMenuItem, "saveAttachmentToolStripMenuItem");
			this.saveAttachmentToolStripMenuItem.Click += new System.EventHandler(this.saveAttachmentToolStripMenuItem_Click);
			// 
			// deleteAttachmentToolStripMenuItem
			// 
			this.deleteAttachmentToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteAttachmentToolStripMenuItem.Name = "deleteAttachmentToolStripMenuItem";
			resources.ApplyResources(this.deleteAttachmentToolStripMenuItem, "deleteAttachmentToolStripMenuItem");
			this.deleteAttachmentToolStripMenuItem.Click += new System.EventHandler(this.deleteAttachmentToolStripMenuItem_Click);
			// 
			// attachmentsListView
			// 
			resources.ApplyResources(this.attachmentsListView, "attachmentsListView");
			this.attachmentsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.attachmentsListView.ContextMenuStrip = this.attachmentsContextMenu;
			this.attachmentsListView.FullRowSelect = true;
			this.attachmentsListView.GridLines = true;
			this.attachmentsListView.HideSelection = false;
			this.attachmentsListView.Name = "attachmentsListView";
			this.attachmentsListView.UseCompatibleStateImageBehavior = false;
			this.attachmentsListView.View = System.Windows.Forms.View.Details;
			this.attachmentsListView.SelectedIndexChanged += new System.EventHandler(this.attachmentsListView_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			resources.ApplyResources(this.columnHeader1, "columnHeader1");
			// 
			// columnHeader2
			// 
			resources.ApplyResources(this.columnHeader2, "columnHeader2");
			// 
			// AttachmentsForm
			// 
			this.AcceptButton = this.okButton;
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.okButton;
			this.Controls.Add(this.attachmentsListView);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.deleteButton);
			this.Controls.Add(this.saveButton);
			this.Controls.Add(this.addButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AttachmentsForm";
			this.ShowInTaskbar = false;
			this.attachmentsContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button addButton;
		private System.Windows.Forms.Button saveButton;
		private System.Windows.Forms.Button deleteButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.ContextMenuStrip attachmentsContextMenu;
		private System.Windows.Forms.ToolStripMenuItem addAttachmentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAttachmentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteAttachmentToolStripMenuItem;
		private System.Windows.Forms.ListView attachmentsListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}
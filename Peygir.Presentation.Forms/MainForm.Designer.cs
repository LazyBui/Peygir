namespace Peygir.Presentation.Forms {
	partial class MainForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.projectsGroupBox = new System.Windows.Forms.GroupBox();
			this.editTicketsButton = new System.Windows.Forms.Button();
			this.deleteProjectButton = new System.Windows.Forms.Button();
			this.editProjectButton = new System.Windows.Forms.Button();
			this.addProjectButton = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveDatabaseAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.persianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.databaseToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.projectsListUserControl = new Peygir.Presentation.UserControls.ProjectsListUserControl();
			this.projectsGroupBox.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// projectsGroupBox
			// 
			resources.ApplyResources(this.projectsGroupBox, "projectsGroupBox");
			this.projectsGroupBox.Controls.Add(this.editTicketsButton);
			this.projectsGroupBox.Controls.Add(this.deleteProjectButton);
			this.projectsGroupBox.Controls.Add(this.editProjectButton);
			this.projectsGroupBox.Controls.Add(this.addProjectButton);
			this.projectsGroupBox.Controls.Add(this.projectsListUserControl);
			this.projectsGroupBox.Name = "projectsGroupBox";
			this.projectsGroupBox.TabStop = false;
			// 
			// editTicketsButton
			// 
			this.editTicketsButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Open;
			resources.ApplyResources(this.editTicketsButton, "editTicketsButton");
			this.editTicketsButton.Name = "editTicketsButton";
			this.editTicketsButton.UseVisualStyleBackColor = true;
			this.editTicketsButton.Click += new System.EventHandler(this.editTicketsButton_Click);
			// 
			// deleteProjectButton
			// 
			resources.ApplyResources(this.deleteProjectButton, "deleteProjectButton");
			this.deleteProjectButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteProjectButton.Name = "deleteProjectButton";
			this.deleteProjectButton.UseVisualStyleBackColor = true;
			this.deleteProjectButton.Click += new System.EventHandler(this.deleteProjectButton_Click);
			// 
			// editProjectButton
			// 
			resources.ApplyResources(this.editProjectButton, "editProjectButton");
			this.editProjectButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editProjectButton.Name = "editProjectButton";
			this.editProjectButton.UseVisualStyleBackColor = true;
			this.editProjectButton.Click += new System.EventHandler(this.editProjectButton_Click);
			// 
			// addProjectButton
			// 
			resources.ApplyResources(this.addProjectButton, "addProjectButton");
			this.addProjectButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addProjectButton.Name = "addProjectButton";
			this.addProjectButton.UseVisualStyleBackColor = true;
			this.addProjectButton.Click += new System.EventHandler(this.addProjectButton_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.languageToolStripMenuItem});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDatabaseToolStripMenuItem,
            this.openDatabaseToolStripMenuItem,
            this.saveDatabaseAsToolStripMenuItem,
            this.closeDatabaseToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
			// 
			// newDatabaseToolStripMenuItem
			// 
			this.newDatabaseToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_New;
			this.newDatabaseToolStripMenuItem.Name = "newDatabaseToolStripMenuItem";
			resources.ApplyResources(this.newDatabaseToolStripMenuItem, "newDatabaseToolStripMenuItem");
			this.newDatabaseToolStripMenuItem.Click += new System.EventHandler(this.newDatabaseToolStripMenuItem_Click);
			// 
			// openDatabaseToolStripMenuItem
			// 
			this.openDatabaseToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Open;
			this.openDatabaseToolStripMenuItem.Name = "openDatabaseToolStripMenuItem";
			resources.ApplyResources(this.openDatabaseToolStripMenuItem, "openDatabaseToolStripMenuItem");
			this.openDatabaseToolStripMenuItem.Click += new System.EventHandler(this.openDatabaseToolStripMenuItem_Click);
			// 
			// saveDatabaseAsToolStripMenuItem
			// 
			this.saveDatabaseAsToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_SaveAs;
			this.saveDatabaseAsToolStripMenuItem.Name = "saveDatabaseAsToolStripMenuItem";
			resources.ApplyResources(this.saveDatabaseAsToolStripMenuItem, "saveDatabaseAsToolStripMenuItem");
			this.saveDatabaseAsToolStripMenuItem.Click += new System.EventHandler(this.saveDatabaseAsToolStripMenuItem_Click);
			// 
			// closeDatabaseToolStripMenuItem
			// 
			this.closeDatabaseToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Close;
			this.closeDatabaseToolStripMenuItem.Name = "closeDatabaseToolStripMenuItem";
			resources.ApplyResources(this.closeDatabaseToolStripMenuItem, "closeDatabaseToolStripMenuItem");
			this.closeDatabaseToolStripMenuItem.Click += new System.EventHandler(this.closeDatabaseToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Exit;
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewHelpToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
			// 
			// viewHelpToolStripMenuItem
			// 
			this.viewHelpToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Help;
			this.viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
			resources.ApplyResources(this.viewHelpToolStripMenuItem, "viewHelpToolStripMenuItem");
			this.viewHelpToolStripMenuItem.Click += new System.EventHandler(this.viewHelpToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Peygir;
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.persianToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
			// 
			// englishToolStripMenuItem
			// 
			this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
			this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
			// 
			// persianToolStripMenuItem
			// 
			this.persianToolStripMenuItem.Name = "persianToolStripMenuItem";
			resources.ApplyResources(this.persianToolStripMenuItem, "persianToolStripMenuItem");
			this.persianToolStripMenuItem.Click += new System.EventHandler(this.persianToolStripMenuItem_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripStatusLabel});
			resources.ApplyResources(this.statusStrip1, "statusStrip1");
			this.statusStrip1.Name = "statusStrip1";
			// 
			// databaseToolStripStatusLabel
			// 
			this.databaseToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.databaseToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.databaseToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
			this.databaseToolStripStatusLabel.Name = "databaseToolStripStatusLabel";
			resources.ApplyResources(this.databaseToolStripStatusLabel, "databaseToolStripStatusLabel");
			// 
			// openFileDialog
			// 
			resources.ApplyResources(this.openFileDialog, "openFileDialog");
			// 
			// saveFileDialog
			// 
			resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
			// 
			// projectsListUserControl
			// 
			resources.ApplyResources(this.projectsListUserControl, "projectsListUserControl");
			this.projectsListUserControl.Name = "projectsListUserControl";
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.projectsGroupBox);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.projectsGroupBox.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox projectsGroupBox;
		private UserControls.ProjectsListUserControl projectsListUserControl;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.Button deleteProjectButton;
		private System.Windows.Forms.Button editProjectButton;
		private System.Windows.Forms.Button addProjectButton;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel databaseToolStripStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem newDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem closeDatabaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem saveDatabaseAsToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.ToolStripMenuItem viewHelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem persianToolStripMenuItem;
		private System.Windows.Forms.Button editTicketsButton;
	}
}
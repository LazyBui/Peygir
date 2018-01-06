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
			this.components = new System.ComponentModel.Container();
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
			this.projectContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editTicketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openTicketsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.totalTicketsToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.projectsListUserControl = new Peygir.Presentation.UserControls.ProjectsListUserControl();
			this.resetFilterButton = new System.Windows.Forms.Button();
			this.createdButton = new System.Windows.Forms.Button();
			this.modifiedButton = new System.Windows.Forms.Button();
			this.modifiedTextBox = new System.Windows.Forms.TextBox();
			this.createdTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.reportersComboBox = new System.Windows.Forms.ComboBox();
			this.assignedToComboBox = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.ticketTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ticketSeverityComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ticketPriorityComboBox = new System.Windows.Forms.ComboBox();
			this.projectTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ticketStateComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.projectsGroupBox.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.projectContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// projectsGroupBox
			// 
			resources.ApplyResources(this.projectsGroupBox, "projectsGroupBox");
			this.projectsGroupBox.Controls.Add(this.label5);
			this.projectsGroupBox.Controls.Add(this.resetFilterButton);
			this.projectsGroupBox.Controls.Add(this.label1);
			this.projectsGroupBox.Controls.Add(this.editTicketsButton);
			this.projectsGroupBox.Controls.Add(this.createdButton);
			this.projectsGroupBox.Controls.Add(this.deleteProjectButton);
			this.projectsGroupBox.Controls.Add(this.modifiedButton);
			this.projectsGroupBox.Controls.Add(this.editProjectButton);
			this.projectsGroupBox.Controls.Add(this.modifiedTextBox);
			this.projectsGroupBox.Controls.Add(this.addProjectButton);
			this.projectsGroupBox.Controls.Add(this.createdTextBox);
			this.projectsGroupBox.Controls.Add(this.projectsListUserControl);
			this.projectsGroupBox.Controls.Add(this.label9);
			this.projectsGroupBox.Controls.Add(this.projectTextBox);
			this.projectsGroupBox.Controls.Add(this.label8);
			this.projectsGroupBox.Controls.Add(this.ticketStateComboBox);
			this.projectsGroupBox.Controls.Add(this.reportersComboBox);
			this.projectsGroupBox.Controls.Add(this.label2);
			this.projectsGroupBox.Controls.Add(this.assignedToComboBox);
			this.projectsGroupBox.Controls.Add(this.ticketPriorityComboBox);
			this.projectsGroupBox.Controls.Add(this.label7);
			this.projectsGroupBox.Controls.Add(this.label3);
			this.projectsGroupBox.Controls.Add(this.label6);
			this.projectsGroupBox.Controls.Add(this.ticketSeverityComboBox);
			this.projectsGroupBox.Controls.Add(this.ticketTypeComboBox);
			this.projectsGroupBox.Controls.Add(this.label4);
			this.projectsGroupBox.Name = "projectsGroupBox";
			this.projectsGroupBox.TabStop = false;
			// 
			// editTicketsButton
			// 
			resources.ApplyResources(this.editTicketsButton, "editTicketsButton");
			this.editTicketsButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Open;
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
            this.databaseToolStripStatusLabel,
            this.openTicketsToolStripStatusLabel,
            this.totalTicketsToolStripStatusLabel});
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
			// projectContextMenu
			// 
			this.projectContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectToolStripMenuItem,
            this.editProjectToolStripMenuItem,
            this.editTicketsToolStripMenuItem,
            this.deleteProjectToolStripMenuItem});
			this.projectContextMenu.Name = "projectContextMenu";
			this.projectContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			resources.ApplyResources(this.projectContextMenu, "projectContextMenu");
			this.projectContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.projectContextMenu_Opening);
			// 
			// addProjectToolStripMenuItem
			// 
			this.addProjectToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addProjectToolStripMenuItem.Name = "addProjectToolStripMenuItem";
			resources.ApplyResources(this.addProjectToolStripMenuItem, "addProjectToolStripMenuItem");
			this.addProjectToolStripMenuItem.Click += new System.EventHandler(this.addProjectToolStripMenuItem_Click);
			// 
			// editProjectToolStripMenuItem
			// 
			this.editProjectToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editProjectToolStripMenuItem.Name = "editProjectToolStripMenuItem";
			resources.ApplyResources(this.editProjectToolStripMenuItem, "editProjectToolStripMenuItem");
			this.editProjectToolStripMenuItem.Click += new System.EventHandler(this.editProjectToolStripMenuItem_Click);
			// 
			// editTicketsToolStripMenuItem
			// 
			this.editTicketsToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Open;
			this.editTicketsToolStripMenuItem.Name = "editTicketsToolStripMenuItem";
			resources.ApplyResources(this.editTicketsToolStripMenuItem, "editTicketsToolStripMenuItem");
			this.editTicketsToolStripMenuItem.Click += new System.EventHandler(this.editTicketsToolStripMenuItem_Click);
			// 
			// deleteProjectToolStripMenuItem
			// 
			this.deleteProjectToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteProjectToolStripMenuItem.Name = "deleteProjectToolStripMenuItem";
			resources.ApplyResources(this.deleteProjectToolStripMenuItem, "deleteProjectToolStripMenuItem");
			this.deleteProjectToolStripMenuItem.Click += new System.EventHandler(this.deleteProjectToolStripMenuItem_Click);
			// 
			// openTicketsToolStripStatusLabel
			// 
			this.openTicketsToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.openTicketsToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.openTicketsToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
			this.openTicketsToolStripStatusLabel.Name = "openTicketsToolStripStatusLabel";
			resources.ApplyResources(this.openTicketsToolStripStatusLabel, "openTicketsToolStripStatusLabel");
			// 
			// totalTicketsToolStripStatusLabel
			// 
			this.totalTicketsToolStripStatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.totalTicketsToolStripStatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.totalTicketsToolStripStatusLabel.Margin = new System.Windows.Forms.Padding(0, 4, 3, 0);
			this.totalTicketsToolStripStatusLabel.Name = "totalTicketsToolStripStatusLabel";
			resources.ApplyResources(this.totalTicketsToolStripStatusLabel, "totalTicketsToolStripStatusLabel");
			// 
			// projectsListUserControl
			// 
			resources.ApplyResources(this.projectsListUserControl, "projectsListUserControl");
			this.projectsListUserControl.Name = "projectsListUserControl";
			// 
			// resetFilterButton
			// 
			resources.ApplyResources(this.resetFilterButton, "resetFilterButton");
			this.resetFilterButton.Name = "resetFilterButton";
			this.resetFilterButton.UseVisualStyleBackColor = true;
			this.resetFilterButton.Click += new System.EventHandler(this.resetFilterButton_Click);
			// 
			// createdButton
			// 
			resources.ApplyResources(this.createdButton, "createdButton");
			this.createdButton.Name = "createdButton";
			this.createdButton.UseVisualStyleBackColor = true;
			this.createdButton.Click += new System.EventHandler(this.createdButton_Click);
			// 
			// modifiedButton
			// 
			resources.ApplyResources(this.modifiedButton, "modifiedButton");
			this.modifiedButton.Name = "modifiedButton";
			this.modifiedButton.UseVisualStyleBackColor = true;
			this.modifiedButton.Click += new System.EventHandler(this.modifiedButton_Click);
			// 
			// modifiedTextBox
			// 
			resources.ApplyResources(this.modifiedTextBox, "modifiedTextBox");
			this.modifiedTextBox.Name = "modifiedTextBox";
			this.modifiedTextBox.ReadOnly = true;
			this.modifiedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.modifiedTextBox_KeyDown);
			// 
			// createdTextBox
			// 
			resources.ApplyResources(this.createdTextBox, "createdTextBox");
			this.createdTextBox.Name = "createdTextBox";
			this.createdTextBox.ReadOnly = true;
			this.createdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.createdTextBox_KeyDown);
			// 
			// label9
			// 
			resources.ApplyResources(this.label9, "label9");
			this.label9.Name = "label9";
			this.label9.Click += new System.EventHandler(this.modifiedButton_Click);
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// reportersComboBox
			// 
			this.reportersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.reportersComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.reportersComboBox, "reportersComboBox");
			this.reportersComboBox.Name = "reportersComboBox";
			this.reportersComboBox.SelectedIndexChanged += new System.EventHandler(this.reporterComboBox_SelectedIndexChanged);
			// 
			// assignedToComboBox
			// 
			this.assignedToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.assignedToComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.assignedToComboBox, "assignedToComboBox");
			this.assignedToComboBox.Name = "assignedToComboBox";
			this.assignedToComboBox.SelectedIndexChanged += new System.EventHandler(this.assignedComboBox_SelectedIndexChanged);
			// 
			// label7
			// 
			resources.ApplyResources(this.label7, "label7");
			this.label7.Name = "label7";
			// 
			// label6
			// 
			resources.ApplyResources(this.label6, "label6");
			this.label6.Name = "label6";
			// 
			// ticketTypeComboBox
			// 
			this.ticketTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketTypeComboBox.FormattingEnabled = true;
			this.ticketTypeComboBox.Items.AddRange(new object[] {
            resources.GetString("ticketTypeComboBox.Items"),
            resources.GetString("ticketTypeComboBox.Items1"),
            resources.GetString("ticketTypeComboBox.Items2"),
            resources.GetString("ticketTypeComboBox.Items3")});
			resources.ApplyResources(this.ticketTypeComboBox, "ticketTypeComboBox");
			this.ticketTypeComboBox.Name = "ticketTypeComboBox";
			this.ticketTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketTypeComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// ticketSeverityComboBox
			// 
			this.ticketSeverityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketSeverityComboBox.FormattingEnabled = true;
			this.ticketSeverityComboBox.Items.AddRange(new object[] {
            resources.GetString("ticketSeverityComboBox.Items"),
            resources.GetString("ticketSeverityComboBox.Items1"),
            resources.GetString("ticketSeverityComboBox.Items2"),
            resources.GetString("ticketSeverityComboBox.Items3"),
            resources.GetString("ticketSeverityComboBox.Items4"),
            resources.GetString("ticketSeverityComboBox.Items5"),
            resources.GetString("ticketSeverityComboBox.Items6")});
			resources.ApplyResources(this.ticketSeverityComboBox, "ticketSeverityComboBox");
			this.ticketSeverityComboBox.Name = "ticketSeverityComboBox";
			this.ticketSeverityComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketSeverityComboBox_SelectedIndexChanged);
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// ticketPriorityComboBox
			// 
			this.ticketPriorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketPriorityComboBox.FormattingEnabled = true;
			this.ticketPriorityComboBox.Items.AddRange(new object[] {
            resources.GetString("ticketPriorityComboBox.Items"),
            resources.GetString("ticketPriorityComboBox.Items1"),
            resources.GetString("ticketPriorityComboBox.Items2"),
            resources.GetString("ticketPriorityComboBox.Items3"),
            resources.GetString("ticketPriorityComboBox.Items4"),
            resources.GetString("ticketPriorityComboBox.Items5")});
			resources.ApplyResources(this.ticketPriorityComboBox, "ticketPriorityComboBox");
			this.ticketPriorityComboBox.Name = "ticketPriorityComboBox";
			this.ticketPriorityComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketPriorityComboBox_SelectedIndexChanged);
			// 
			// projectTextBox
			// 
			resources.ApplyResources(this.projectTextBox, "projectTextBox");
			this.projectTextBox.Name = "projectTextBox";
			this.projectTextBox.TextChanged += new System.EventHandler(this.projectTextBox_TextChanged);
			this.projectTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.projectTextBox_KeyDown);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// ticketStateComboBox
			// 
			this.ticketStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketStateComboBox.FormattingEnabled = true;
			this.ticketStateComboBox.Items.AddRange(new object[] {
            resources.GetString("ticketStateComboBox.Items"),
            resources.GetString("ticketStateComboBox.Items1"),
            resources.GetString("ticketStateComboBox.Items2"),
            resources.GetString("ticketStateComboBox.Items3"),
            resources.GetString("ticketStateComboBox.Items4"),
            resources.GetString("ticketStateComboBox.Items5"),
            resources.GetString("ticketStateComboBox.Items6"),
            resources.GetString("ticketStateComboBox.Items7"),
            resources.GetString("ticketStateComboBox.Items8")});
			resources.ApplyResources(this.ticketStateComboBox, "ticketStateComboBox");
			this.ticketStateComboBox.Name = "ticketStateComboBox";
			this.ticketStateComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketStateComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
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
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.projectsGroupBox.ResumeLayout(false);
			this.projectsGroupBox.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.projectContextMenu.ResumeLayout(false);
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
		private System.Windows.Forms.ContextMenuStrip projectContextMenu;
		private System.Windows.Forms.ToolStripMenuItem addProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editTicketsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel openTicketsToolStripStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel totalTicketsToolStripStatusLabel;
		private System.Windows.Forms.Button resetFilterButton;
		private System.Windows.Forms.Button createdButton;
		private System.Windows.Forms.Button modifiedButton;
		private System.Windows.Forms.TextBox modifiedTextBox;
		private System.Windows.Forms.TextBox createdTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox projectTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox ticketStateComboBox;
		private System.Windows.Forms.ComboBox reportersComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox assignedToComboBox;
		private System.Windows.Forms.ComboBox ticketPriorityComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox ticketSeverityComboBox;
		private System.Windows.Forms.ComboBox ticketTypeComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
	}
}
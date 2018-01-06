namespace Peygir.Presentation.Forms {
	partial class ProjectForm {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectForm));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.projectInfoTabPage = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.changeProjectDetailsButton = new System.Windows.Forms.Button();
			this.projectDetailsUserControl = new Peygir.Presentation.UserControls.ProjectDetailsUserControl();
			this.milestonesTabPage = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.showMilestoneButton = new System.Windows.Forms.Button();
			this.deleteMilestoneButton = new System.Windows.Forms.Button();
			this.editMilestoneButton = new System.Windows.Forms.Button();
			this.addMilestoneButton = new System.Windows.Forms.Button();
			this.milestonesListUserControl = new Peygir.Presentation.UserControls.MilestonesListUserControl();
			this.ticketsTabPage = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ticketMilestoneComboBox = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.resetTicketFilterButton = new System.Windows.Forms.Button();
			this.ticketCreatedButton = new System.Windows.Forms.Button();
			this.ticketModifiedButton = new System.Windows.Forms.Button();
			this.modifiedTextBox = new System.Windows.Forms.TextBox();
			this.createdTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.ticketReportersComboBox = new System.Windows.Forms.ComboBox();
			this.ticketAssignedToComboBox = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.ticketTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ticketSeverityComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ticketPriorityComboBox = new System.Windows.Forms.ComboBox();
			this.ticketTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ticketStateComboBox = new System.Windows.Forms.ComboBox();
			this.showTicketAttachmentsButton = new System.Windows.Forms.Button();
			this.showTicketHistoryButton = new System.Windows.Forms.Button();
			this.deleteTicketButton = new System.Windows.Forms.Button();
			this.editTicketButton = new System.Windows.Forms.Button();
			this.showTicketButton = new System.Windows.Forms.Button();
			this.addTicketButton = new System.Windows.Forms.Button();
			this.ticketsListUserControl = new Peygir.Presentation.UserControls.TicketsListUserControl();
			this.ticketContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.stateNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateAcceptedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateInProgressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateBlockedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateCompletedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.stateClosedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.priorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lowestPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lowPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.normalPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highestPriorityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.severityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trivialSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.minorSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.normalSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.majorSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.criticalSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.blockerSeverityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.typeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.defectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.featureRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.milestoneContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.projectInfoTabPage.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.milestonesTabPage.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.ticketsTabPage.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.ticketContextMenu.SuspendLayout();
			this.milestoneContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.tabControl);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// tabControl
			// 
			resources.ApplyResources(this.tabControl, "tabControl");
			this.tabControl.Controls.Add(this.projectInfoTabPage);
			this.tabControl.Controls.Add(this.milestonesTabPage);
			this.tabControl.Controls.Add(this.ticketsTabPage);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			// 
			// projectInfoTabPage
			// 
			this.projectInfoTabPage.Controls.Add(this.groupBox2);
			resources.ApplyResources(this.projectInfoTabPage, "projectInfoTabPage");
			this.projectInfoTabPage.Name = "projectInfoTabPage";
			this.projectInfoTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			resources.ApplyResources(this.groupBox2, "groupBox2");
			this.groupBox2.Controls.Add(this.changeProjectDetailsButton);
			this.groupBox2.Controls.Add(this.projectDetailsUserControl);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.TabStop = false;
			// 
			// changeProjectDetailsButton
			// 
			resources.ApplyResources(this.changeProjectDetailsButton, "changeProjectDetailsButton");
			this.changeProjectDetailsButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Change;
			this.changeProjectDetailsButton.Name = "changeProjectDetailsButton";
			this.changeProjectDetailsButton.UseVisualStyleBackColor = true;
			this.changeProjectDetailsButton.Click += new System.EventHandler(this.changeProjectDetailsButton_Click);
			// 
			// projectDetailsUserControl
			// 
			resources.ApplyResources(this.projectDetailsUserControl, "projectDetailsUserControl");
			this.projectDetailsUserControl.Description = "";
			this.projectDetailsUserControl.DisplayOrder = 0;
			this.projectDetailsUserControl.Name = "projectDetailsUserControl";
			this.projectDetailsUserControl.ProjectName = "";
			this.projectDetailsUserControl.ReadOnly = true;
			// 
			// milestonesTabPage
			// 
			this.milestonesTabPage.Controls.Add(this.groupBox3);
			resources.ApplyResources(this.milestonesTabPage, "milestonesTabPage");
			this.milestonesTabPage.Name = "milestonesTabPage";
			this.milestonesTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			resources.ApplyResources(this.groupBox3, "groupBox3");
			this.groupBox3.Controls.Add(this.showMilestoneButton);
			this.groupBox3.Controls.Add(this.deleteMilestoneButton);
			this.groupBox3.Controls.Add(this.editMilestoneButton);
			this.groupBox3.Controls.Add(this.addMilestoneButton);
			this.groupBox3.Controls.Add(this.milestonesListUserControl);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.TabStop = false;
			// 
			// showMilestoneButton
			// 
			resources.ApplyResources(this.showMilestoneButton, "showMilestoneButton");
			this.showMilestoneButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Show;
			this.showMilestoneButton.Name = "showMilestoneButton";
			this.showMilestoneButton.UseVisualStyleBackColor = true;
			this.showMilestoneButton.Click += new System.EventHandler(this.showMilestoneButton_Click);
			// 
			// deleteMilestoneButton
			// 
			resources.ApplyResources(this.deleteMilestoneButton, "deleteMilestoneButton");
			this.deleteMilestoneButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteMilestoneButton.Name = "deleteMilestoneButton";
			this.deleteMilestoneButton.UseVisualStyleBackColor = true;
			this.deleteMilestoneButton.Click += new System.EventHandler(this.deleteMilestoneButton_Click);
			// 
			// editMilestoneButton
			// 
			resources.ApplyResources(this.editMilestoneButton, "editMilestoneButton");
			this.editMilestoneButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editMilestoneButton.Name = "editMilestoneButton";
			this.editMilestoneButton.UseVisualStyleBackColor = true;
			this.editMilestoneButton.Click += new System.EventHandler(this.editMilestoneButton_Click);
			// 
			// addMilestoneButton
			// 
			resources.ApplyResources(this.addMilestoneButton, "addMilestoneButton");
			this.addMilestoneButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addMilestoneButton.Name = "addMilestoneButton";
			this.addMilestoneButton.UseVisualStyleBackColor = true;
			this.addMilestoneButton.Click += new System.EventHandler(this.addMilestoneButton_Click);
			// 
			// milestonesListUserControl
			// 
			resources.ApplyResources(this.milestonesListUserControl, "milestonesListUserControl");
			this.milestonesListUserControl.Name = "milestonesListUserControl";
			// 
			// ticketsTabPage
			// 
			this.ticketsTabPage.Controls.Add(this.groupBox4);
			resources.ApplyResources(this.ticketsTabPage, "ticketsTabPage");
			this.ticketsTabPage.Name = "ticketsTabPage";
			this.ticketsTabPage.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			resources.ApplyResources(this.groupBox4, "groupBox4");
			this.groupBox4.Controls.Add(this.ticketMilestoneComboBox);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.resetTicketFilterButton);
			this.groupBox4.Controls.Add(this.ticketCreatedButton);
			this.groupBox4.Controls.Add(this.ticketModifiedButton);
			this.groupBox4.Controls.Add(this.modifiedTextBox);
			this.groupBox4.Controls.Add(this.createdTextBox);
			this.groupBox4.Controls.Add(this.label9);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.ticketReportersComboBox);
			this.groupBox4.Controls.Add(this.ticketAssignedToComboBox);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Controls.Add(this.ticketTypeComboBox);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.ticketSeverityComboBox);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.ticketPriorityComboBox);
			this.groupBox4.Controls.Add(this.ticketTextBox);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.ticketStateComboBox);
			this.groupBox4.Controls.Add(this.showTicketAttachmentsButton);
			this.groupBox4.Controls.Add(this.showTicketHistoryButton);
			this.groupBox4.Controls.Add(this.deleteTicketButton);
			this.groupBox4.Controls.Add(this.editTicketButton);
			this.groupBox4.Controls.Add(this.showTicketButton);
			this.groupBox4.Controls.Add(this.addTicketButton);
			this.groupBox4.Controls.Add(this.ticketsListUserControl);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.TabStop = false;
			// 
			// ticketMilestoneComboBox
			// 
			this.ticketMilestoneComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketMilestoneComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.ticketMilestoneComboBox, "ticketMilestoneComboBox");
			this.ticketMilestoneComboBox.Name = "ticketMilestoneComboBox";
			this.ticketMilestoneComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketMilestoneComboBox_SelectedIndexChanged);
			// 
			// label10
			// 
			resources.ApplyResources(this.label10, "label10");
			this.label10.Name = "label10";
			// 
			// resetTicketFilterButton
			// 
			resources.ApplyResources(this.resetTicketFilterButton, "resetTicketFilterButton");
			this.resetTicketFilterButton.Name = "resetTicketFilterButton";
			this.resetTicketFilterButton.UseVisualStyleBackColor = true;
			this.resetTicketFilterButton.Click += new System.EventHandler(this.resetTicketFilterButton_Click);
			// 
			// ticketCreatedButton
			// 
			this.ticketCreatedButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			resources.ApplyResources(this.ticketCreatedButton, "ticketCreatedButton");
			this.ticketCreatedButton.Name = "ticketCreatedButton";
			this.ticketCreatedButton.UseVisualStyleBackColor = true;
			this.ticketCreatedButton.Click += new System.EventHandler(this.ticketCreatedButton_Click);
			// 
			// ticketModifiedButton
			// 
			this.ticketModifiedButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			resources.ApplyResources(this.ticketModifiedButton, "ticketModifiedButton");
			this.ticketModifiedButton.Name = "ticketModifiedButton";
			this.ticketModifiedButton.UseVisualStyleBackColor = true;
			this.ticketModifiedButton.Click += new System.EventHandler(this.ticketModifiedButton_Click);
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
			// 
			// label8
			// 
			resources.ApplyResources(this.label8, "label8");
			this.label8.Name = "label8";
			// 
			// ticketReportersComboBox
			// 
			this.ticketReportersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketReportersComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.ticketReportersComboBox, "ticketReportersComboBox");
			this.ticketReportersComboBox.Name = "ticketReportersComboBox";
			this.ticketReportersComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketReportersComboBox_SelectedIndexChanged);
			// 
			// ticketAssignedToComboBox
			// 
			this.ticketAssignedToComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ticketAssignedToComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.ticketAssignedToComboBox, "ticketAssignedToComboBox");
			this.ticketAssignedToComboBox.Name = "ticketAssignedToComboBox";
			this.ticketAssignedToComboBox.SelectedIndexChanged += new System.EventHandler(this.ticketAssignedToComboBox_SelectedIndexChanged);
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
			// label5
			// 
			resources.ApplyResources(this.label5, "label5");
			this.label5.Name = "label5";
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
			// ticketTextBox
			// 
			resources.ApplyResources(this.ticketTextBox, "ticketTextBox");
			this.ticketTextBox.Name = "ticketTextBox";
			this.ticketTextBox.TextChanged += new System.EventHandler(this.ticketTextBox_TextChanged);
			this.ticketTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ticketTextBox_KeyDown);
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
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
			// showTicketAttachmentsButton
			// 
			resources.ApplyResources(this.showTicketAttachmentsButton, "showTicketAttachmentsButton");
			this.showTicketAttachmentsButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Attachment;
			this.showTicketAttachmentsButton.Name = "showTicketAttachmentsButton";
			this.showTicketAttachmentsButton.UseVisualStyleBackColor = true;
			this.showTicketAttachmentsButton.Click += new System.EventHandler(this.showTicketAttachmentsButton_Click);
			// 
			// showTicketHistoryButton
			// 
			resources.ApplyResources(this.showTicketHistoryButton, "showTicketHistoryButton");
			this.showTicketHistoryButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_History;
			this.showTicketHistoryButton.Name = "showTicketHistoryButton";
			this.showTicketHistoryButton.UseVisualStyleBackColor = true;
			this.showTicketHistoryButton.Click += new System.EventHandler(this.showTicketHistoryButton_Click);
			// 
			// deleteTicketButton
			// 
			resources.ApplyResources(this.deleteTicketButton, "deleteTicketButton");
			this.deleteTicketButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteTicketButton.Name = "deleteTicketButton";
			this.deleteTicketButton.UseVisualStyleBackColor = true;
			this.deleteTicketButton.Click += new System.EventHandler(this.deleteTicketButton_Click);
			// 
			// editTicketButton
			// 
			resources.ApplyResources(this.editTicketButton, "editTicketButton");
			this.editTicketButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editTicketButton.Name = "editTicketButton";
			this.editTicketButton.UseVisualStyleBackColor = true;
			this.editTicketButton.Click += new System.EventHandler(this.editTicketButton_Click);
			// 
			// showTicketButton
			// 
			resources.ApplyResources(this.showTicketButton, "showTicketButton");
			this.showTicketButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Show;
			this.showTicketButton.Name = "showTicketButton";
			this.showTicketButton.UseVisualStyleBackColor = true;
			this.showTicketButton.Click += new System.EventHandler(this.showTicketButton_Click);
			// 
			// addTicketButton
			// 
			resources.ApplyResources(this.addTicketButton, "addTicketButton");
			this.addTicketButton.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addTicketButton.Name = "addTicketButton";
			this.addTicketButton.UseVisualStyleBackColor = true;
			this.addTicketButton.Click += new System.EventHandler(this.addTicketButton_Click);
			// 
			// ticketsListUserControl
			// 
			resources.ApplyResources(this.ticketsListUserControl, "ticketsListUserControl");
			this.ticketsListUserControl.Name = "ticketsListUserControl";
			// 
			// ticketContextMenu
			// 
			this.ticketContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTicketToolStripMenuItem,
            this.showTicketToolStripMenuItem,
            this.editTicketToolStripMenuItem,
            this.showTicketHistoryToolStripMenuItem,
            this.deleteTicketToolStripMenuItem,
            this.showTicketAttachmentsToolStripMenuItem,
            this.toolStripSeparator1,
            this.stateNewToolStripMenuItem,
            this.stateAcceptedToolStripMenuItem,
            this.stateInProgressToolStripMenuItem,
            this.stateBlockedToolStripMenuItem,
            this.stateCompletedToolStripMenuItem,
            this.stateClosedToolStripMenuItem,
            this.toolStripSeparator2,
            this.priorityToolStripMenuItem,
            this.severityToolStripMenuItem,
            this.typeToolStripMenuItem});
			this.ticketContextMenu.Name = "ticketContextMenu";
			this.ticketContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			resources.ApplyResources(this.ticketContextMenu, "ticketContextMenu");
			this.ticketContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ticketContextMenu_Opening);
			// 
			// addTicketToolStripMenuItem
			// 
			this.addTicketToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addTicketToolStripMenuItem.Name = "addTicketToolStripMenuItem";
			resources.ApplyResources(this.addTicketToolStripMenuItem, "addTicketToolStripMenuItem");
			this.addTicketToolStripMenuItem.Click += new System.EventHandler(this.addTicketToolStripMenuItem_Click);
			// 
			// showTicketToolStripMenuItem
			// 
			this.showTicketToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Show;
			this.showTicketToolStripMenuItem.Name = "showTicketToolStripMenuItem";
			resources.ApplyResources(this.showTicketToolStripMenuItem, "showTicketToolStripMenuItem");
			this.showTicketToolStripMenuItem.Click += new System.EventHandler(this.showTicketToolStripMenuItem_Click);
			// 
			// editTicketToolStripMenuItem
			// 
			this.editTicketToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editTicketToolStripMenuItem.Name = "editTicketToolStripMenuItem";
			resources.ApplyResources(this.editTicketToolStripMenuItem, "editTicketToolStripMenuItem");
			this.editTicketToolStripMenuItem.Click += new System.EventHandler(this.editTicketToolStripMenuItem_Click);
			// 
			// showTicketHistoryToolStripMenuItem
			// 
			this.showTicketHistoryToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_History;
			this.showTicketHistoryToolStripMenuItem.Name = "showTicketHistoryToolStripMenuItem";
			resources.ApplyResources(this.showTicketHistoryToolStripMenuItem, "showTicketHistoryToolStripMenuItem");
			this.showTicketHistoryToolStripMenuItem.Click += new System.EventHandler(this.showTicketHistoryToolStripMenuItem_Click);
			// 
			// deleteTicketToolStripMenuItem
			// 
			this.deleteTicketToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteTicketToolStripMenuItem.Name = "deleteTicketToolStripMenuItem";
			resources.ApplyResources(this.deleteTicketToolStripMenuItem, "deleteTicketToolStripMenuItem");
			this.deleteTicketToolStripMenuItem.Click += new System.EventHandler(this.deleteTicketToolStripMenuItem_Click);
			// 
			// showTicketAttachmentsToolStripMenuItem
			// 
			this.showTicketAttachmentsToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Attachment;
			this.showTicketAttachmentsToolStripMenuItem.Name = "showTicketAttachmentsToolStripMenuItem";
			resources.ApplyResources(this.showTicketAttachmentsToolStripMenuItem, "showTicketAttachmentsToolStripMenuItem");
			this.showTicketAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.showTicketAttachmentsToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			// 
			// stateNewToolStripMenuItem
			// 
			this.stateNewToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Help;
			this.stateNewToolStripMenuItem.Name = "stateNewToolStripMenuItem";
			resources.ApplyResources(this.stateNewToolStripMenuItem, "stateNewToolStripMenuItem");
			this.stateNewToolStripMenuItem.Click += new System.EventHandler(this.stateNewToolStripMenuItem_Click);
			// 
			// stateAcceptedToolStripMenuItem
			// 
			this.stateAcceptedToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_New;
			this.stateAcceptedToolStripMenuItem.Name = "stateAcceptedToolStripMenuItem";
			resources.ApplyResources(this.stateAcceptedToolStripMenuItem, "stateAcceptedToolStripMenuItem");
			this.stateAcceptedToolStripMenuItem.Click += new System.EventHandler(this.stateAcceptedToolStripMenuItem_Click);
			// 
			// stateInProgressToolStripMenuItem
			// 
			this.stateInProgressToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_SaveAs;
			this.stateInProgressToolStripMenuItem.Name = "stateInProgressToolStripMenuItem";
			resources.ApplyResources(this.stateInProgressToolStripMenuItem, "stateInProgressToolStripMenuItem");
			this.stateInProgressToolStripMenuItem.Click += new System.EventHandler(this.stateInProgressToolStripMenuItem_Click);
			// 
			// stateBlockedToolStripMenuItem
			// 
			this.stateBlockedToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Cancel;
			this.stateBlockedToolStripMenuItem.Name = "stateBlockedToolStripMenuItem";
			resources.ApplyResources(this.stateBlockedToolStripMenuItem, "stateBlockedToolStripMenuItem");
			this.stateBlockedToolStripMenuItem.Click += new System.EventHandler(this.stateBlockedToolStripMenuItem_Click);
			// 
			// stateCompletedToolStripMenuItem
			// 
			this.stateCompletedToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_OK;
			this.stateCompletedToolStripMenuItem.Name = "stateCompletedToolStripMenuItem";
			resources.ApplyResources(this.stateCompletedToolStripMenuItem, "stateCompletedToolStripMenuItem");
			this.stateCompletedToolStripMenuItem.Click += new System.EventHandler(this.stateCompletedToolStripMenuItem_Click);
			// 
			// stateClosedToolStripMenuItem
			// 
			this.stateClosedToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Exit;
			this.stateClosedToolStripMenuItem.Name = "stateClosedToolStripMenuItem";
			resources.ApplyResources(this.stateClosedToolStripMenuItem, "stateClosedToolStripMenuItem");
			this.stateClosedToolStripMenuItem.Click += new System.EventHandler(this.stateClosedToolStripMenuItem_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			// 
			// priorityToolStripMenuItem
			// 
			this.priorityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lowestPriorityToolStripMenuItem,
            this.lowPriorityToolStripMenuItem,
            this.normalPriorityToolStripMenuItem,
            this.highPriorityToolStripMenuItem,
            this.highestPriorityToolStripMenuItem});
			this.priorityToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Open;
			this.priorityToolStripMenuItem.Name = "priorityToolStripMenuItem";
			resources.ApplyResources(this.priorityToolStripMenuItem, "priorityToolStripMenuItem");
			// 
			// lowestPriorityToolStripMenuItem
			// 
			this.lowestPriorityToolStripMenuItem.Name = "lowestPriorityToolStripMenuItem";
			resources.ApplyResources(this.lowestPriorityToolStripMenuItem, "lowestPriorityToolStripMenuItem");
			this.lowestPriorityToolStripMenuItem.Click += new System.EventHandler(this.lowestPriorityToolStripMenuItem_Click);
			// 
			// lowPriorityToolStripMenuItem
			// 
			this.lowPriorityToolStripMenuItem.Name = "lowPriorityToolStripMenuItem";
			resources.ApplyResources(this.lowPriorityToolStripMenuItem, "lowPriorityToolStripMenuItem");
			this.lowPriorityToolStripMenuItem.Click += new System.EventHandler(this.lowPriorityToolStripMenuItem_Click);
			// 
			// normalPriorityToolStripMenuItem
			// 
			this.normalPriorityToolStripMenuItem.Name = "normalPriorityToolStripMenuItem";
			resources.ApplyResources(this.normalPriorityToolStripMenuItem, "normalPriorityToolStripMenuItem");
			this.normalPriorityToolStripMenuItem.Click += new System.EventHandler(this.normalPriorityToolStripMenuItem_Click);
			// 
			// highPriorityToolStripMenuItem
			// 
			this.highPriorityToolStripMenuItem.Name = "highPriorityToolStripMenuItem";
			resources.ApplyResources(this.highPriorityToolStripMenuItem, "highPriorityToolStripMenuItem");
			this.highPriorityToolStripMenuItem.Click += new System.EventHandler(this.highPriorityToolStripMenuItem_Click);
			// 
			// highestPriorityToolStripMenuItem
			// 
			this.highestPriorityToolStripMenuItem.Name = "highestPriorityToolStripMenuItem";
			resources.ApplyResources(this.highestPriorityToolStripMenuItem, "highestPriorityToolStripMenuItem");
			this.highestPriorityToolStripMenuItem.Click += new System.EventHandler(this.highestPriorityToolStripMenuItem_Click);
			// 
			// severityToolStripMenuItem
			// 
			this.severityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trivialSeverityToolStripMenuItem,
            this.minorSeverityToolStripMenuItem,
            this.normalSeverityToolStripMenuItem,
            this.majorSeverityToolStripMenuItem,
            this.criticalSeverityToolStripMenuItem,
            this.blockerSeverityToolStripMenuItem});
			this.severityToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Peygir;
			this.severityToolStripMenuItem.Name = "severityToolStripMenuItem";
			resources.ApplyResources(this.severityToolStripMenuItem, "severityToolStripMenuItem");
			// 
			// trivialSeverityToolStripMenuItem
			// 
			this.trivialSeverityToolStripMenuItem.Name = "trivialSeverityToolStripMenuItem";
			resources.ApplyResources(this.trivialSeverityToolStripMenuItem, "trivialSeverityToolStripMenuItem");
			this.trivialSeverityToolStripMenuItem.Click += new System.EventHandler(this.trivialSeverityToolStripMenuItem_Click);
			// 
			// minorSeverityToolStripMenuItem
			// 
			this.minorSeverityToolStripMenuItem.Name = "minorSeverityToolStripMenuItem";
			resources.ApplyResources(this.minorSeverityToolStripMenuItem, "minorSeverityToolStripMenuItem");
			this.minorSeverityToolStripMenuItem.Click += new System.EventHandler(this.minorSeverityToolStripMenuItem_Click);
			// 
			// normalSeverityToolStripMenuItem
			// 
			this.normalSeverityToolStripMenuItem.Name = "normalSeverityToolStripMenuItem";
			resources.ApplyResources(this.normalSeverityToolStripMenuItem, "normalSeverityToolStripMenuItem");
			this.normalSeverityToolStripMenuItem.Click += new System.EventHandler(this.normalSeverityToolStripMenuItem_Click);
			// 
			// majorSeverityToolStripMenuItem
			// 
			this.majorSeverityToolStripMenuItem.Name = "majorSeverityToolStripMenuItem";
			resources.ApplyResources(this.majorSeverityToolStripMenuItem, "majorSeverityToolStripMenuItem");
			this.majorSeverityToolStripMenuItem.Click += new System.EventHandler(this.majorSeverityToolStripMenuItem_Click);
			// 
			// criticalSeverityToolStripMenuItem
			// 
			this.criticalSeverityToolStripMenuItem.Name = "criticalSeverityToolStripMenuItem";
			resources.ApplyResources(this.criticalSeverityToolStripMenuItem, "criticalSeverityToolStripMenuItem");
			this.criticalSeverityToolStripMenuItem.Click += new System.EventHandler(this.criticalSeverityToolStripMenuItem_Click);
			// 
			// blockerSeverityToolStripMenuItem
			// 
			this.blockerSeverityToolStripMenuItem.Name = "blockerSeverityToolStripMenuItem";
			resources.ApplyResources(this.blockerSeverityToolStripMenuItem, "blockerSeverityToolStripMenuItem");
			this.blockerSeverityToolStripMenuItem.Click += new System.EventHandler(this.blockerSeverityToolStripMenuItem_Click);
			// 
			// typeToolStripMenuItem
			// 
			this.typeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defectToolStripMenuItem,
            this.featureRequestToolStripMenuItem,
            this.taskToolStripMenuItem});
			this.typeToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Options;
			this.typeToolStripMenuItem.Name = "typeToolStripMenuItem";
			resources.ApplyResources(this.typeToolStripMenuItem, "typeToolStripMenuItem");
			// 
			// defectToolStripMenuItem
			// 
			this.defectToolStripMenuItem.Name = "defectToolStripMenuItem";
			resources.ApplyResources(this.defectToolStripMenuItem, "defectToolStripMenuItem");
			this.defectToolStripMenuItem.Click += new System.EventHandler(this.defectToolStripMenuItem_Click);
			// 
			// featureRequestToolStripMenuItem
			// 
			this.featureRequestToolStripMenuItem.Name = "featureRequestToolStripMenuItem";
			resources.ApplyResources(this.featureRequestToolStripMenuItem, "featureRequestToolStripMenuItem");
			this.featureRequestToolStripMenuItem.Click += new System.EventHandler(this.featureRequestToolStripMenuItem_Click);
			// 
			// taskToolStripMenuItem
			// 
			this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
			resources.ApplyResources(this.taskToolStripMenuItem, "taskToolStripMenuItem");
			this.taskToolStripMenuItem.Click += new System.EventHandler(this.taskToolStripMenuItem_Click);
			// 
			// milestoneContextMenu
			// 
			this.milestoneContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMilestoneToolStripMenuItem,
            this.showMilestoneToolStripMenuItem,
            this.editMilestoneToolStripMenuItem,
            this.deleteMilestoneToolStripMenuItem});
			this.milestoneContextMenu.Name = "milestoneContextMenu";
			this.milestoneContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			resources.ApplyResources(this.milestoneContextMenu, "milestoneContextMenu");
			this.milestoneContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.milestoneContextMenu_Opening);
			// 
			// addMilestoneToolStripMenuItem
			// 
			this.addMilestoneToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Add;
			this.addMilestoneToolStripMenuItem.Name = "addMilestoneToolStripMenuItem";
			resources.ApplyResources(this.addMilestoneToolStripMenuItem, "addMilestoneToolStripMenuItem");
			this.addMilestoneToolStripMenuItem.Click += new System.EventHandler(this.addMilestoneToolStripMenuItem_Click);
			// 
			// showMilestoneToolStripMenuItem
			// 
			this.showMilestoneToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Show;
			this.showMilestoneToolStripMenuItem.Name = "showMilestoneToolStripMenuItem";
			resources.ApplyResources(this.showMilestoneToolStripMenuItem, "showMilestoneToolStripMenuItem");
			this.showMilestoneToolStripMenuItem.Click += new System.EventHandler(this.showMilestoneToolStripMenuItem_Click);
			// 
			// editMilestoneToolStripMenuItem
			// 
			this.editMilestoneToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Edit;
			this.editMilestoneToolStripMenuItem.Name = "editMilestoneToolStripMenuItem";
			resources.ApplyResources(this.editMilestoneToolStripMenuItem, "editMilestoneToolStripMenuItem");
			this.editMilestoneToolStripMenuItem.Click += new System.EventHandler(this.editMilestoneToolStripMenuItem_Click);
			// 
			// deleteMilestoneToolStripMenuItem
			// 
			this.deleteMilestoneToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteMilestoneToolStripMenuItem.Name = "deleteMilestoneToolStripMenuItem";
			resources.ApplyResources(this.deleteMilestoneToolStripMenuItem, "deleteMilestoneToolStripMenuItem");
			this.deleteMilestoneToolStripMenuItem.Click += new System.EventHandler(this.deleteMilestoneToolStripMenuItem_Click);
			// 
			// ProjectForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectForm_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.projectInfoTabPage.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.milestonesTabPage.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ticketsTabPage.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ticketContextMenu.ResumeLayout(false);
			this.milestoneContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage projectInfoTabPage;
		private System.Windows.Forms.TabPage milestonesTabPage;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button changeProjectDetailsButton;
		private UserControls.ProjectDetailsUserControl projectDetailsUserControl;
		private System.Windows.Forms.GroupBox groupBox3;
		private UserControls.MilestonesListUserControl milestonesListUserControl;
		private System.Windows.Forms.Button showMilestoneButton;
		private System.Windows.Forms.Button deleteMilestoneButton;
		private System.Windows.Forms.Button editMilestoneButton;
		private System.Windows.Forms.Button addMilestoneButton;
		private System.Windows.Forms.TabPage ticketsTabPage;
		private System.Windows.Forms.GroupBox groupBox4;
		private UserControls.TicketsListUserControl ticketsListUserControl;
		private System.Windows.Forms.Button addTicketButton;
		private System.Windows.Forms.Button deleteTicketButton;
		private System.Windows.Forms.Button editTicketButton;
		private System.Windows.Forms.Button showTicketButton;
		private System.Windows.Forms.Button showTicketHistoryButton;
		private System.Windows.Forms.Button showTicketAttachmentsButton;
		private System.Windows.Forms.ContextMenuStrip ticketContextMenu;
		private System.Windows.Forms.ToolStripMenuItem addTicketToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showTicketToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editTicketToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showTicketHistoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showTicketAttachmentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteTicketToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip milestoneContextMenu;
		private System.Windows.Forms.ToolStripMenuItem addMilestoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showMilestoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editMilestoneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteMilestoneToolStripMenuItem;
		private System.Windows.Forms.ComboBox ticketMilestoneComboBox;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Button resetTicketFilterButton;
		private System.Windows.Forms.Button ticketCreatedButton;
		private System.Windows.Forms.Button ticketModifiedButton;
		private System.Windows.Forms.TextBox modifiedTextBox;
		private System.Windows.Forms.TextBox createdTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox ticketReportersComboBox;
		private System.Windows.Forms.ComboBox ticketAssignedToComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox ticketTypeComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox ticketSeverityComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox ticketPriorityComboBox;
		private System.Windows.Forms.TextBox ticketTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ticketStateComboBox;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem stateNewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateAcceptedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateInProgressToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateBlockedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateCompletedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stateClosedToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem priorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lowestPriorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem lowPriorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem normalPriorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem highPriorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem highestPriorityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem severityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem typeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem trivialSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem minorSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem normalSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem majorSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem criticalSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem blockerSeverityToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem defectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem featureRequestToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
	}
}
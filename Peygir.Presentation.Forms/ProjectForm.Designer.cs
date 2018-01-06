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
			this.milestonesTabPage = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.showMilestoneButton = new System.Windows.Forms.Button();
			this.deleteMilestoneButton = new System.Windows.Forms.Button();
			this.editMilestoneButton = new System.Windows.Forms.Button();
			this.addMilestoneButton = new System.Windows.Forms.Button();
			this.ticketsTabPage = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.showTicketAttachmentsButton = new System.Windows.Forms.Button();
			this.showTicketHistoryButton = new System.Windows.Forms.Button();
			this.deleteTicketButton = new System.Windows.Forms.Button();
			this.editTicketButton = new System.Windows.Forms.Button();
			this.showTicketButton = new System.Windows.Forms.Button();
			this.addTicketButton = new System.Windows.Forms.Button();
			this.ticketContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showTicketAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.milestoneContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.addMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteMilestoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.projectDetailsUserControl = new Peygir.Presentation.UserControls.ProjectDetailsUserControl();
			this.milestonesListUserControl = new Peygir.Presentation.UserControls.MilestonesListUserControl();
			this.ticketsListUserControl = new Peygir.Presentation.UserControls.TicketsListUserControl();
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
			// ticketContextMenu
			// 
			this.ticketContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTicketToolStripMenuItem,
            this.showTicketToolStripMenuItem,
            this.editTicketToolStripMenuItem,
            this.showTicketHistoryToolStripMenuItem,
            this.deleteTicketToolStripMenuItem,
            this.showTicketAttachmentsToolStripMenuItem});
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
			// showTicketAttachmentsToolStripMenuItem
			// 
			this.showTicketAttachmentsToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Attachment;
			this.showTicketAttachmentsToolStripMenuItem.Name = "showTicketAttachmentsToolStripMenuItem";
			resources.ApplyResources(this.showTicketAttachmentsToolStripMenuItem, "showTicketAttachmentsToolStripMenuItem");
			this.showTicketAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.showTicketAttachmentsToolStripMenuItem_Click);
			// 
			// deleteTicketToolStripMenuItem
			// 
			this.deleteTicketToolStripMenuItem.Image = global::Peygir.Presentation.Forms.Properties.Resources.Image_Delete;
			this.deleteTicketToolStripMenuItem.Name = "deleteTicketToolStripMenuItem";
			resources.ApplyResources(this.deleteTicketToolStripMenuItem, "deleteTicketToolStripMenuItem");
			this.deleteTicketToolStripMenuItem.Click += new System.EventHandler(this.deleteTicketToolStripMenuItem_Click);
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
			// projectDetailsUserControl
			// 
			resources.ApplyResources(this.projectDetailsUserControl, "projectDetailsUserControl");
			this.projectDetailsUserControl.Description = "";
			this.projectDetailsUserControl.DisplayOrder = 0;
			this.projectDetailsUserControl.Name = "projectDetailsUserControl";
			this.projectDetailsUserControl.ProjectName = "";
			this.projectDetailsUserControl.ReadOnly = true;
			// 
			// milestonesListUserControl
			// 
			resources.ApplyResources(this.milestonesListUserControl, "milestonesListUserControl");
			this.milestonesListUserControl.Name = "milestonesListUserControl";
			// 
			// ticketsListUserControl
			// 
			resources.ApplyResources(this.ticketsListUserControl, "ticketsListUserControl");
			this.ticketsListUserControl.Name = "ticketsListUserControl";
			// 
			// ProjectForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ProjectForm";
			this.ShowInTaskbar = false;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectForm_FormClosed);
			this.groupBox1.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.projectInfoTabPage.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.milestonesTabPage.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ticketsTabPage.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
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
	}
}
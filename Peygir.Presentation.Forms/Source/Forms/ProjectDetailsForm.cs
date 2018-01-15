using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class ProjectDetailsForm : Form {
		private FormContext mContext;
		private Project mProject;

		public ProjectDetailsForm(FormContext context, Project project) {
			if (context == null) throw new ArgumentNullException(nameof(context));

			mContext = context;
			mProject = project;

			InitializeComponent();

			projectDetailsUserControl.ShowProject(project);
		}

		public Project RetrieveProject(Project @base = null) {
			var project = @base;
			if (project == null) {
				project = new Project(mContext);
			}

			project.Name = projectDetailsUserControl.ProjectName;
			project.DisplayOrder = projectDetailsUserControl.DisplayOrder;
			project.Description = projectDetailsUserControl.Description;
			return project;
		}

		private void ProjectDetailsForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (DialogResult != DialogResult.OK) return;
	
			var problems = new List<string>();
			if (string.IsNullOrWhiteSpace(projectDetailsUserControl.ProjectName)) problems.Add(Resources.String_TheProjectNameCannotBeBlank);
			if (!problems.Any()) return;

			MessageBox.Show(
				string.Join(Environment.NewLine, problems),
				Resources.String_Error,
				MessageBoxButtons.OK,
				MessageBoxIcon.Error,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			e.Cancel = true;
		}
	}
}

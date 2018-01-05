using System.Windows.Forms;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class ProjectDetailsForm : Form {
		public ProjectDetailsUserControl ProjectDetailsUserControl {
			get { return projectDetailsUserControl; }
		}

		public ProjectDetailsForm() {
			InitializeComponent();
		}
	}
}

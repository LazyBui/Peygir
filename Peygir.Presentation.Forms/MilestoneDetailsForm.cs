using System.Windows.Forms;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class MilestoneDetailsForm : Form {
		public MilestoneDetailsUserControl MilestoneDetailsUserControl {
			get { return milestoneDetailsUserControl; }
		}

		public MilestoneDetailsForm() {
			InitializeComponent();
		}
	}
}

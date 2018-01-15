using System;
using System.Diagnostics;
using System.Windows.Forms;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	partial class AboutForm : Form {
		public AboutForm() {
			InitializeComponent();

			versionLabel.Text = string.Format(
				Resources.String_Version,
				PeygirApplication.AssemblyVersion);
		}

		private void OpenLink() {
			try {
				string address = string.Format("mailto:{0}", Settings.Default.ProgrammerEmail);
				Process.Start(address);
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));
			}
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			OpenLink();
		}

		private void descriptionTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}
	}
}

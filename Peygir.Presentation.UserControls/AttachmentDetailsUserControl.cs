using System;
using System.IO;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public partial class AttachmentDetailsUserControl : UserControl {
		private bool readOnly;

		public bool ReadOnly {
			get { return readOnly; }
			set {
				readOnly = value;
				UpdateReadOnlyState();
			}
		}

		public AttachmentDetailsUserControl() {
			InitializeComponent();

			contents = new byte[0];

			ReadOnly = false;
		}

		public void ShowAttachment(Attachment attachment) {
			if (attachment == null) {
				throw new ArgumentNullException(nameof(attachment));
			}

			nameTextBox.Text = attachment.Name;
			sizeTextBox.Text = string.Format("{0}", attachment.Size);
			contents = attachment.GetContents();
		}

		public void RetrieveAttachment(Attachment attachment) {
			if (attachment == null) {
				throw new ArgumentNullException(nameof(attachment));
			}

			attachment.Name = nameTextBox.Text;
			attachment.SetContents(contents);
		}

		private byte[] contents;

		private void UpdateReadOnlyState() {
			openButton.Enabled = !readOnly;
		}

		private void OpenFile() {
			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				string fileName = openFileDialog.FileName;

				contents = File.ReadAllBytes(fileName);
				nameTextBox.Text = fileName;
			}
		}

		private void SaveFile() {
			if (saveFileDialog.ShowDialog() == DialogResult.OK) {
				string fileName = saveFileDialog.FileName;

				File.WriteAllBytes(fileName, contents);
			}
		}

		private void openButton_Click(object sender, EventArgs e) {
			OpenFile();
		}

		private void saveButton_Click(object sender, EventArgs e) {
			SaveFile();
		}

		private void nameTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}

		private void sizeTextBox_KeyDown(object sender, KeyEventArgs e) {
			TextBoxUtil.TextBoxKeyDown(sender, e);
		}
	}
}

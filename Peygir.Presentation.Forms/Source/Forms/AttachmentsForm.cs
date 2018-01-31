using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	public partial class AttachmentsForm : Form {
		private FormContext mContext = null;
		private Ticket mTicket = null;

		public AttachmentsForm(FormContext context, Ticket ticket) {
			if (context == null) throw new ArgumentNullException(nameof(context));
			if (ticket == null) throw new ArgumentNullException(nameof(ticket));

			mContext = context;
			mTicket = ticket;

			InitializeComponent();
			ShowAttachments();
		}

		private void attachmentsListView_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateButtonsEnabledProperty();
		}

		#region Attachment modification UI
		#region Buttons
		private void addButton_Click(object sender, EventArgs e) {
			AddAttachment();
		}

		private void saveButton_Click(object sender, EventArgs e) {
			SaveAttachment();
		}

		private void deleteButton_Click(object sender, EventArgs e) {
			DeleteAttachment();
		}
		#endregion

		#region Context menu
		private void attachmentsContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			int count = attachmentsListView.SelectedItems.Count;
			saveAttachmentToolStripMenuItem.Enabled = count == 1;
			deleteAttachmentToolStripMenuItem.Enabled = count > 0;
		}

		private void addAttachmentToolStripMenuItem_Click(object sender, EventArgs e) {
			AddAttachment();
		}

		private void saveAttachmentToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveAttachment();
		}

		private void deleteAttachmentToolStripMenuItem_Click(object sender, EventArgs e) {
			DeleteAttachment();
		}
		#endregion
		#endregion

		#region Utility functions
		private void UpdateButtonsEnabledProperty() {
			int count = attachmentsListView.SelectedItems.Count;
			saveButton.Enabled = count == 1;
			deleteButton.Enabled = count > 0;
		}

		private void ShowAttachments() {
			FormUtil.Reselect<Attachment>(attachmentsListView, () => {
				Attachment[] attachments = mTicket.GetAttachmentsWithoutContents(mContext);

				attachmentsListView.BeginUpdate();
				attachmentsListView.Items.Clear();
				foreach (var attachment in attachments) {
					var lvi = new ListViewItem() {
						Text = attachment.Name,
						Tag = attachment,
					};

					lvi.SubItems.Add($"{attachment.Size}");

					attachmentsListView.Items.Add(lvi);
				}

				attachmentsListView.EndUpdate();
				attachmentsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			});

			UpdateButtonsEnabledProperty();
		}

		private void AddAttachment() {
			try {
				if (openFileDialog.ShowDialog() != DialogResult.OK) return;

				string fileName = openFileDialog.FileName;
				var fi = new FileInfo(fileName);

				Attachment attachment = mTicket.NewAttachment();

				attachment.Name = fi.Name.Substring(0, Math.Min(255, fi.Name.Length)); // Max 255 characters.
				attachment.SetContents(File.ReadAllBytes(fileName));

				attachment.Add(mContext);

				// Flush.
				mContext.Flush();

				ShowAttachments();

				FormUtil.SelectNew(attachmentsListView, attachment);
			}
			catch (Exception exception) {
				MessageBox.Show(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormUtil.GetMessageBoxOptions(this));

				ShowAttachments();
			}
		}

		private void SaveAttachment() {
			if (attachmentsListView.SelectedItems.Count != 1) return;
			try {
				var tag = (Attachment)attachmentsListView.SelectedItems[0].Tag;

				saveFileDialog.FileName = tag.Name;
				if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

				string fileName = saveFileDialog.FileName;
				Attachment attachment = Attachment.GetAttachment(mContext, tag.ID);

				File.WriteAllBytes(fileName, attachment.GetContents());
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

		private void DeleteAttachment() {
			if (attachmentsListView.Items.Count == 0) return;

			DialogResult result = MessageBox.Show(
				Resources.String_AreYouSureYouWantToDeleteAttachments,
				Resources.String_DeleteAttachments,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button1,
				FormUtil.GetMessageBoxOptions(this));

			if (result != DialogResult.Yes) {
				return;
			}

			FormUtil.DeleteSelected<Attachment>(attachmentsListView, mContext);

			// Flush.
			mContext.Flush();

			// Show attachments.
			ShowAttachments();
		}
		#endregion
	}
}

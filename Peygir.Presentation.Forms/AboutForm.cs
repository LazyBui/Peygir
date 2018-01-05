﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	partial class AboutForm : Form {
		public MessageBoxOptions FormMessageBoxOptions {
			get {
				MessageBoxOptions options = (MessageBoxOptions)0;
				if (RightToLeft == System.Windows.Forms.RightToLeft.Yes) {
					options = (MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
				}
				return options;
			}
		}

		public AboutForm() {
			InitializeComponent();

			versionLabel.Text = string.Format(Resources.String_Version, PeygirApplication.AssemblyVersion);
		}

		private void OpenLink() {
			try {
				string address = string.Format("mailto:{0}", Settings.Default.ProgrammerEmail);
				Process.Start(address);
			}
			catch (Exception exception) {
				MessageBox.Show
				(
					exception.Message,
					Resources.String_Error,
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1,
					FormMessageBoxOptions

				);
			}
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			OpenLink();
		}
	}
}

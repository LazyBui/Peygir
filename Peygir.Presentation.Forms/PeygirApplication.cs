using System;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	public static class PeygirApplication {
		public static Version AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version;
			}
		}

		public static void Run() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Change UI language.
			try {
				CultureInfo cultureInfo = new CultureInfo(Settings.Default.Language);
				Thread.CurrentThread.CurrentUICulture = cultureInfo;
			}
			catch (Exception) {
				// Nothing.
			}

			MainForm mainForm = new MainForm();
			Application.Run(mainForm);

			return;
		}
	}
}

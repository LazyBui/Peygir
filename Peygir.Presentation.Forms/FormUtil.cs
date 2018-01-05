using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	internal static class FormUtil {
		public static DateTimeFormatter GetFormatter() {
			// It's important to return a new instance each time because the settings might mutate
			if (Settings.Default.FormatDateTime) {
				return new DateTimeFormatter(
					Settings.Default.DateTimePattern,
					Settings.Default.Calendar);
			}
			return DateTimeFormatter.Default;
		}
	}
}

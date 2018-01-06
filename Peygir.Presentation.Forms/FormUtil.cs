using System;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	internal static class FormUtil {
		public static TValue? CastBox<TValue>(ComboBox input) where TValue : struct {
			return input.SelectedIndex > 0 ?
				(TValue?)(TValue)(object)(input.SelectedIndex - 1) :
				null;
		}

		public static void SetOrDefault(ComboBox input) {
			if (input.Items.Count == 0)
				return;
			input.SelectedIndex = 0;
		}

		public static void FormatDateFilter(TextBox input, DateRange range) {
			input.Text = range?.ToString() ?? string.Empty;
		}

		private static readonly StringComparison sComparison = StringComparison.InvariantCultureIgnoreCase;

		public static bool FilterContains(string input, string filter) {
			return
				string.IsNullOrEmpty(filter) ||
				input.IndexOf(filter, sComparison) >= 0;
		}

		public static bool FilterContains(DateTime input, DateRange filter) {
			return
				filter == null ||
				filter.Contains(input);
		}

		public static bool FilterMatch(string input, string filter) {
			return
				string.IsNullOrEmpty(filter) ||
				string.Compare(input, filter, sComparison) == 0;
		}

		public static bool FilterEnum<TValue>(TValue input, TValue? filter) where TValue : struct {
			return
				filter == null ||
				input.Equals(filter.Value);
		}

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

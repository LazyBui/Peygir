﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;
using Peygir.Presentation.UserControls;

namespace Peygir.Presentation.Forms {
	internal static class FormUtil {
		public static TValue? CastBoxToEnum<TValue>(ComboBox input) where TValue : struct {
			return input.SelectedIndex > 0 ?
				(TValue?)(TValue)(object)(input.SelectedIndex - 1) :
				null;
		}

		public static void SetOrDefault(ComboBox input) {
			if (input.Items.Count == 0)
				return;
			input.SelectedIndex = 0;
		}

		public static void UpdateUserBoxWithSelectedText(ComboBox input, IEnumerable<string> data, bool hasEmptyItem = false) {
			bool hadSelected = input.SelectedIndex != -1;
			string selectedText = string.Empty;
			if (hadSelected) {
				selectedText = input.SelectedText;
			}

			var casted = new List<string>(data);
			if (hasEmptyItem) casted.Insert(0, string.Empty);

			input.Items.Clear();
			input.Items.AddRange(casted.ToArray());
			if (hadSelected) {
				input.SelectedIndex = casted.IndexOf(selectedText);
			}
		}

		public static void UpdateUserBoxWithSelectedItem(ComboBox input, IEnumerable<string> data, bool hasEmptyItem = false) {
			bool hadSelected = input.SelectedIndex != -1;
			string selectedText = string.Empty;
			if (hadSelected) {
				selectedText = (string)input.SelectedItem;
			}

			var casted = new List<string>(data);
			if (hasEmptyItem) casted.Insert(0, string.Empty);
			input.Items.Clear();
			input.Items.AddRange(casted.ToArray());
			if (hadSelected) {
				input.SelectedItem = selectedText;
			}
		}

		public static MessageBoxOptions GetMessageBoxOptions(Form form) {
			MessageBoxOptions options = 0;
			if (form.RightToLeft == RightToLeft.Yes) {
				options = (MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);
			}
			return options;
		}

		public static void Reselect<TValue>(ListView view, Action code) where TValue : IEquatable<TValue> {
			var selected = new List<TValue>();
			foreach (ListViewItem item in view.SelectedItems) {
				var tag = (TValue)item.Tag;
				selected.Add(tag);
			}

			code();

			foreach (ListViewItem item in view.Items) {
				var tag = (TValue)item.Tag;
				if (selected.Contains(tag)) {
					item.Selected = true;
				}
			}
		}

		public static void SelectNew<TValue>(ListView view, TValue value) where TValue : IEquatable<TValue> {
			view.SelectedItems.Clear();
			foreach (ListViewItem item in view.Items) {
				var tag = (TValue)item.Tag;
				if (tag.Equals(value)) {
					item.Selected = true;
					item.EnsureVisible();
					break;
				}
			}
		}

		public static void DeleteSelected<TValue>(ListView view, IDatabaseProvider db) where TValue : DBObject {
			for (int i = 0; i < view.SelectedItems.Count; i++) {
				var tag = (DBObject)view.SelectedItems[i].Tag;
				tag.Delete(db);
			}
		}

		public static void FormatDateFilter(TextBox input, DateRange range) {
			input.Text = range?.ToString() ?? string.Empty;
		}

		private static readonly StringComparison sComparison = StringComparison.InvariantCultureIgnoreCase;

		public static bool SatisfiesFilterContains(string input, string filter) {
			return
				string.IsNullOrEmpty(filter) ||
				input.IndexOf(filter, sComparison) >= 0;
		}

		public static bool SatisfiesFilterContains(DateTime input, DateRange filter) {
			return
				filter == null ||
				filter.Contains(input);
		}

		public static bool SatisfiesFilterMatch(string input, string filter) {
			return
				string.IsNullOrEmpty(filter) ||
				string.Compare(input, filter, sComparison) == 0;
		}

		public static bool SatisfiesFilterEnum<TValue>(TValue input, TValue? filter) where TValue : struct {
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

		public static FontContext GetFontContext() {
			// It's important to return a new instance each time because the settings might mutate
			return new FontContext(
				new Font(
					Settings.Default.SansSerifFont,
					Settings.Default.SansSerifFontSize,
					Settings.Default.SansSerifFontStyle,
					GraphicsUnit.Point),
				new Font(
					Settings.Default.MonospaceFont,
					Settings.Default.MonospaceFontSize,
					Settings.Default.MonospaceFontStyle,
					GraphicsUnit.Point),
				Settings.Default.UseSansSerifDefault,
				Settings.Default.WordWrapDefault);
		}
	}
}

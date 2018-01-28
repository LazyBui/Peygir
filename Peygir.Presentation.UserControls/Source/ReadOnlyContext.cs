using System;
using System.Windows.Forms;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public sealed class ReadOnlyContext {
		public static readonly ReadOnlyContext Writable = new ReadOnlyContext(false);
		public static readonly ReadOnlyContext Readable = new ReadOnlyContext(true);

		public bool ReadOnly { get; private set; }
		public bool Enabled => !ReadOnly;

		private ReadOnlyContext(bool readOnly) {
			ReadOnly = readOnly;
		}

		public static ReadOnlyContext From(bool readOnly) {
			if (readOnly) return Readable;
			return Writable;
		}

		public void ApplyTo(params Control[] controls) {
			for (int i = 0; i < controls.Length; i++) {
				ApplyToInternal(controls[i]);
			}
		}

		private void ApplyToInternal(Control control) {
			Type controlType = control.GetType();
			if (controlType == typeof(TextBox)) ApplyTo((TextBox)control);
			else if (controlType == typeof(NumericUpDown)) ApplyTo((NumericUpDown)control);
			else if (controlType == typeof(CheckBox)) ApplyTo((CheckBox)control);
			else if (controlType == typeof(RadioButton)) ApplyTo((RadioButton)control);
			else if (controlType == typeof(ComboBox)) ApplyTo((ComboBox)control);
			else throw new NotImplementedException();
		}

		public void ApplyTo(TextBox textbox) {
			textbox.ReadOnly = ReadOnly;
		}

		public void ApplyTo(NumericUpDown numeric) {
			numeric.ReadOnly = ReadOnly;
			numeric.Enabled = Enabled;
		}

		public void ApplyTo(CheckBox checkbox) {
			checkbox.Enabled = Enabled;
		}

		public void ApplyTo(RadioButton button) {
			button.Enabled = Enabled;
		}

		public void ApplyTo(ComboBox combo) {
			combo.Enabled = Enabled;
		}
	}
}

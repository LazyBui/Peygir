using System;
using Peygir.Logic;

namespace Peygir.Presentation.UserControls {
	public sealed class FormContext : IDatabaseProvider {
		public static readonly FormContext Default = new FormContext();

		public Database DB { get; private set; }
		public bool HasDatabase => !object.ReferenceEquals(DB, null);

		private FormContext() {
			// Blank
		}

		public FormContext(Database db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			DB = db;
		}

		public void Close() {
			DB.Close();
		}

		public void Flush() {
			DB.Flush();
		}
	}
}

using System;
using System.Data;
using System.Data.OleDb;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class Version : DBObject {
		private Version() {
			// Blank
		}

		protected override void AddPrivate(Database db) {
			throw new InvalidOperationException();
		}

		protected override void UpdatePrivate(Database db) {
			VersionTableAdapter tableAdapter = db.VersionTableAdapter;

			tableAdapter.Update(ID + 1, ID);

			ID++;
		}

		protected override void DeletePrivate(Database db) {
			throw new InvalidOperationException();
		}

		private const int CurrentVersion = 1;
		public static void UpdateIfAppropriate(Database db) {
			VersionTableAdapter tableAdapter = db.VersionTableAdapter;
			attempt: {
				try {
					var tableData = tableAdapter.GetData();

					// This should never be the case outside of manual tampering
					// In which case, there's not really a suitable way to recover
					if (tableData.Count != 1) throw new ManualTamperingException(Resources.String_VersionManualTampering);

					var data = new Version(tableData[0]);
					int current = data.ID;

					// This should never be the case outside of manual tampering
					// In which case, there's not really a suitable way to recover
					if (current < 1) throw new ManualTamperingException(Resources.String_VersionManualTampering);

					// This DB is produced with a future version of the software
					// It may be backward-incompatible with this version but it also may not
					// For now, we'll play it safe and throw 
					if (current > CurrentVersion) throw new BackwardCompatibilityException(Resources.String_VersionBackwardCompatibility);

					// Nothing to do here
					if (current == CurrentVersion) return;

					applyUpdate: {
						switch (current) {
							// Add migrations as appropriate
							// These are specified in terms of current -> next
							// So if I'm looking to update to version 2, I should be putting my query in case 1
							case 1:
								break;
						}
						current++;
						data.UpdatePrivate(db);
						if (current < CurrentVersion) goto applyUpdate;
					}
				}
				catch (OleDbException) {
					// We don't have a version table, we can automatically make a new one
					ExecuteQuery(tableAdapter, "CREATE TABLE `Version` (ID INTEGER NOT NULL CONSTRAINT PK_Version PRIMARY KEY)");
					ExecuteQuery(tableAdapter, "INSERT INTO `Version` VALUES (1)");
					// We might have multiple versions to migrate after installing the table
					goto attempt;
				}
			}
		}

		private static void ExecuteQuery(VersionTableAdapter tableAdapter, string query) {
			using (var cmd = tableAdapter.Connection.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = query;
				cmd.ExecuteNonQuery();
			}
		}
		
		public override string ToString() {
			return ID.ToString();
		}

		internal Version(PeygirDatabaseDataSet.VersionRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
		}
	}
}

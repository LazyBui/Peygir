using System;
using System.Data;
using System.Data.OleDb;

namespace Peygir.Logic {
	internal static class OleDbConnectionExtensions {
		public static int GetInsertedIdentity(this OleDbConnection @this) {
			using (var cmd = @this.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT @@Identity";
				return (int)cmd.ExecuteScalar();
			}
		}
	}
}

using System;
using System.IO;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;

namespace Peygir.Logic {
	public class Database : IDatabaseProvider {
		public string CurrentDatabasePath { get; private set; }
		public bool IsOpen { get; private set; }

		internal ProjectsTableAdapter ProjectsTableAdapter { get; private set; }
		internal MilestonesTableAdapter MilestonesTableAdapter { get; private set; }
		internal TicketReportersTableAdapter TicketReportersTableAdapter { get; private set; }
		internal TicketAssigneesTableAdapter TicketAssigneesTableAdapter { get; private set; }
		internal TicketsTableAdapter TicketsTableAdapter { get; private set; }
		internal AttachmentsWithoutContentsTableAdapter AttachmentsWithoutContentsTableAdapter { get; private set; }
		internal AttachmentsTableAdapter AttachmentsTableAdapter { get; private set; }
		internal TicketsHistoryTableAdapter TicketsHistoryTableAdapter { get; private set; }

		public Database DB => this;

		private Database() {
			// Blank
		}

		public static Database CreateAndOpen(string databasePath) {
			if (databasePath == null) {
				throw new ArgumentNullException(nameof(databasePath));
			}

			// Copy default database to new location.
			string defaultDatabasePath = PeygirDatabaseDataSet.DefaultDatabaseFileName;
			File.Copy(defaultDatabasePath, databasePath, true);

			// Open database.
			return Open(databasePath);
		}

		public static Database Open(string databasePath) {
			if (databasePath == null) {
				throw new ArgumentNullException(nameof(databasePath));
			}

			PeygirDatabaseDataSet.ChangeDatabasePath(databasePath);

			var result = new Database();
			InitializeDatabase(result, databasePath);
			return result;
		}

		private static void InitializeDatabase(Database value, string databasePath) {
			value.ProjectsTableAdapter = new ProjectsTableAdapter();
			value.MilestonesTableAdapter = new MilestonesTableAdapter();
			value.TicketReportersTableAdapter = new TicketReportersTableAdapter();
			value.TicketAssigneesTableAdapter = new TicketAssigneesTableAdapter();
			value.TicketsTableAdapter = new TicketsTableAdapter();
			value.AttachmentsWithoutContentsTableAdapter = new AttachmentsWithoutContentsTableAdapter();
			value.AttachmentsTableAdapter = new AttachmentsTableAdapter();
			value.TicketsHistoryTableAdapter = new TicketsHistoryTableAdapter();

			value.ProjectsTableAdapter.Connection.Open();
			value.MilestonesTableAdapter.Connection.Open();
			value.TicketReportersTableAdapter.Connection.Open();
			value.TicketAssigneesTableAdapter.Connection.Open();
			value.TicketsTableAdapter.Connection.Open();
			value.AttachmentsWithoutContentsTableAdapter.Connection.Open();
			value.AttachmentsTableAdapter.Connection.Open();
			value.TicketsHistoryTableAdapter.Connection.Open();

			value.CurrentDatabasePath = databasePath;
			value.IsOpen = true;
		}

		public void Close() {
			if (!IsOpen) {
				return;
			}

			ProjectsTableAdapter.Connection.Close();
			MilestonesTableAdapter.Connection.Close();
			TicketReportersTableAdapter.Connection.Close();
			TicketAssigneesTableAdapter.Connection.Close();
			TicketsTableAdapter.Connection.Close();
			AttachmentsWithoutContentsTableAdapter.Connection.Close();
			AttachmentsTableAdapter.Connection.Close();
			TicketsHistoryTableAdapter.Connection.Close();

			ProjectsTableAdapter = null;
			MilestonesTableAdapter = null;
			TicketReportersTableAdapter = null;
			TicketAssigneesTableAdapter = null;
			TicketsTableAdapter = null;
			AttachmentsWithoutContentsTableAdapter = null;
			AttachmentsTableAdapter = null;
			TicketsHistoryTableAdapter = null;

			CurrentDatabasePath = null;
			IsOpen = false;
		}

		public void Flush() {
			if (!IsOpen) {
				throw new InvalidOperationException();
			}

			string databasePath = CurrentDatabasePath;

			// Reconnect.
			Close();

			PeygirDatabaseDataSet.ChangeDatabasePath(databasePath);
			InitializeDatabase(this, databasePath);
		}
	}
}

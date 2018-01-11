using System;
using System.IO;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;

namespace Peygir.Logic {
	public class Database : IDatabaseProvider {
		private string currentDatabasePath;
		public string CurrentDatabasePath {
			get { return currentDatabasePath; }
		}

		private bool isOpen;
		public bool IsOpen {
			get { return isOpen; }
		}

		private ProjectsTableAdapter projectsTableAdapter;
		internal ProjectsTableAdapter ProjectsTableAdapter {
			get { return projectsTableAdapter; }
		}

		private MilestonesTableAdapter milestonesTableAdapter;
		internal MilestonesTableAdapter MilestonesTableAdapter {
			get { return milestonesTableAdapter; }
		}

		private TicketReportersTableAdapter ticketReportersTableAdapter;
		internal TicketReportersTableAdapter TicketReportersTableAdapter {
			get { return ticketReportersTableAdapter; }
		}

		private TicketAssigneesTableAdapter ticketAssigneesTableAdapter;
		internal TicketAssigneesTableAdapter TicketAssigneesTableAdapter {
			get { return ticketAssigneesTableAdapter; }
		}

		private TicketsTableAdapter ticketsTableAdapter;
		internal TicketsTableAdapter TicketsTableAdapter {
			get { return ticketsTableAdapter; }
		}

		private AttachmentsWithoutContentsTableAdapter attachmentsWithoutContentsTableAdapter;
		internal AttachmentsWithoutContentsTableAdapter AttachmentsWithoutContentsTableAdapter {
			get { return attachmentsWithoutContentsTableAdapter; }
		}

		private AttachmentsTableAdapter attachmentsTableAdapter;
		internal AttachmentsTableAdapter AttachmentsTableAdapter {
			get { return attachmentsTableAdapter; }
		}

		private TicketsHistoryTableAdapter ticketsHistoryTableAdapter;
		internal TicketsHistoryTableAdapter TicketsHistoryTableAdapter {
			get { return ticketsHistoryTableAdapter; }
		}

		public Database DB => this;

		private Database() {

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
			value.projectsTableAdapter = new ProjectsTableAdapter();
			value.milestonesTableAdapter = new MilestonesTableAdapter();
			value.ticketReportersTableAdapter = new TicketReportersTableAdapter();
			value.ticketAssigneesTableAdapter = new TicketAssigneesTableAdapter();
			value.ticketsTableAdapter = new TicketsTableAdapter();
			value.attachmentsWithoutContentsTableAdapter = new AttachmentsWithoutContentsTableAdapter();
			value.attachmentsTableAdapter = new AttachmentsTableAdapter();
			value.ticketsHistoryTableAdapter = new TicketsHistoryTableAdapter();

			value.projectsTableAdapter.Connection.Open();
			value.milestonesTableAdapter.Connection.Open();
			value.ticketReportersTableAdapter.Connection.Open();
			value.ticketAssigneesTableAdapter.Connection.Open();
			value.ticketsTableAdapter.Connection.Open();
			value.attachmentsWithoutContentsTableAdapter.Connection.Open();
			value.attachmentsTableAdapter.Connection.Open();
			value.ticketsHistoryTableAdapter.Connection.Open();

			value.currentDatabasePath = databasePath;
			value.isOpen = true;
		}

		public void Close() {
			if (!isOpen) {
				return;
			}

			projectsTableAdapter.Connection.Close();
			milestonesTableAdapter.Connection.Close();
			ticketReportersTableAdapter.Connection.Close();
			ticketAssigneesTableAdapter.Connection.Close();
			ticketsTableAdapter.Connection.Close();
			attachmentsWithoutContentsTableAdapter.Connection.Close();
			attachmentsTableAdapter.Connection.Close();
			ticketsHistoryTableAdapter.Connection.Close();

			projectsTableAdapter = null;
			milestonesTableAdapter = null;
			ticketReportersTableAdapter = null;
			ticketAssigneesTableAdapter = null;
			ticketsTableAdapter = null;
			attachmentsWithoutContentsTableAdapter = null;
			attachmentsTableAdapter = null;
			ticketsHistoryTableAdapter = null;

			currentDatabasePath = null;
			isOpen = false;
		}

		public void Flush() {
			if (!isOpen) {
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

using System;
using System.Collections.Generic;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class TicketHistory : DBObject, IEquatable<TicketHistory> {
		public static TicketHistory[] GetTicketsHistory(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketsHistoryTableAdapter tableAdapter = db.DB.TicketsHistoryTableAdapter;
			PeygirDatabaseDataSet.TicketsHistoryDataTable rows = tableAdapter.GetData();

			// Create list.
			List<TicketHistory> ticketsHistory = new List<TicketHistory>();
			foreach (var row in rows) {
				// Add.
				TicketHistory ticketHistory = new TicketHistory(row);
				ticketsHistory.Add(ticketHistory);
			}

			return ticketsHistory.ToArray();
		}

		public static TicketHistory[] GetTicketHistoryByTicketID(IDatabaseProvider db, int ticketID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketsHistoryTableAdapter tableAdapter = db.DB.TicketsHistoryTableAdapter;
			PeygirDatabaseDataSet.TicketsHistoryDataTable rows = tableAdapter.GetDataByTicketID(ticketID);

			// Create list.
			List<TicketHistory> ticketsHistory = new List<TicketHistory>();
			foreach (var row in rows) {
				// Add.
				TicketHistory ticketHistory = new TicketHistory(row);
				ticketsHistory.Add(ticketHistory);
			}

			return ticketsHistory.ToArray();
		}

		public static TicketHistory GetTicketHistory(IDatabaseProvider db, int id) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketsHistoryTableAdapter tableAdapter = db.DB.TicketsHistoryTableAdapter;
			PeygirDatabaseDataSet.TicketsHistoryDataTable rows = tableAdapter.GetDataByID(id);

			if (rows.Count == 1) {
				// Found.
				TicketHistory ticketsHistory = new TicketHistory(rows[0]);
				return ticketsHistory;
			}

			// Not found.
			return null;
		}

		public int TicketID {
			get { return ticketID; }
		}

		public DateTime Timestamp {
			get { return timestamp; }
			set { timestamp = value; }
		}

		public string Changes {
			get { return changes; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				changes = value;
			}
		}

		public string Comment {
			get { return comment; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				comment = value;
			}
		}

		public TicketHistory(int ticketID) {
			if (ticketID == InvalidID) {
				string message = Resources.String_InvalidTicketID;
				throw new ArgumentException(message, nameof(ticketID));
			}

			this.ticketID = ticketID;
			timestamp = new DateTime();
			changes = string.Empty;
			comment = string.Empty;
		}

		protected override void AddPrivate(Database db) {
			TicketsHistoryTableAdapter tableAdapter = db.TicketsHistoryTableAdapter;

			tableAdapter.Insert(ticketID, timestamp, changes, comment);

			// Find ID.
			ID = tableAdapter.Connection.GetInsertedIdentity();
		}

		protected override void UpdatePrivate(Database db) {
			TicketsHistoryTableAdapter tableAdapter = db.TicketsHistoryTableAdapter;

			tableAdapter.UpdateByID(ticketID, timestamp, changes, comment, ID);
		}

		protected override void DeletePrivate(Database db) {
			TicketsHistoryTableAdapter tableAdapter = db.TicketsHistoryTableAdapter;

			tableAdapter.DeleteByID(ID);

			ID = InvalidID;
		}

		public Ticket GetTicket(IDatabaseProvider db) {
			return Ticket.GetTicket(db, ticketID);
		}

		public override int GetHashCode() => base.GetHashCode();
		public override bool Equals(object obj) => Equals(obj as TicketHistory);
		public bool Equals(TicketHistory other) => DBObject.IsEqual(this, other);
		public static bool operator==(TicketHistory lhs, TicketHistory rhs) => DBObject.IsEqual(lhs, rhs);
		public static bool operator!=(TicketHistory lhs, TicketHistory rhs) => !DBObject.IsEqual(lhs, rhs);

		internal TicketHistory(PeygirDatabaseDataSet.TicketsHistoryRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			ticketID = row.TicketID;
			timestamp = row.Timestamp;
			changes = row.Changes;
			comment = row.Comment;
		}

		private int ticketID;
		private DateTime timestamp;
		private string changes;
		private string comment;
	}
}

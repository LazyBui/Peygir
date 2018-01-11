using System;
using System.Collections.Generic;
using System.Text;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class Ticket : DBObject {
		public static string[] GetReporters(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketReportersTableAdapter tableAdapter = db.DB.TicketReportersTableAdapter;
			PeygirDatabaseDataSet.TicketReportersDataTable rows = tableAdapter.GetData();

			// Create list.
			List<string> reporters = new List<string>();
			foreach (var row in rows) {
				// Add.
				string reporter = row.Reporter;
				reporters.Add(reporter);
			}

			return reporters.ToArray();
		}

		public static string[] GetAssignees(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketAssigneesTableAdapter tableAdapter = db.DB.TicketAssigneesTableAdapter;
			PeygirDatabaseDataSet.TicketAssigneesDataTable rows = tableAdapter.GetData();

			// Create list.
			List<string> assignees = new List<string>();
			foreach (var row in rows) {
				// Add.
				string assignee = row.Assignee;
				assignees.Add(assignee);
			}

			return assignees.ToArray();
		}

		public static Ticket[] GetTickets(IDatabaseProvider db, int milestoneID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketsTableAdapter tableAdapter = db.DB.TicketsTableAdapter;

			PeygirDatabaseDataSet.TicketsDataTable rows = tableAdapter.GetDataByMilestoneID(milestoneID);

			// Create list.
			List<Ticket> tickets = new List<Ticket>();
			foreach (var row in rows) {
				// Add.
				Ticket ticket = new Ticket(row);
				tickets.Add(ticket);
			}

			return tickets.ToArray();
		}

		public static Ticket GetTicket(IDatabaseProvider db, int id) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			TicketsTableAdapter tableAdapter = db.DB.TicketsTableAdapter;

			PeygirDatabaseDataSet.TicketsDataTable rows = tableAdapter.GetDataByID(id);

			if (rows.Count == 1) {
				// Found.
				Ticket ticket = new Ticket(rows[0]);
				return ticket;
			}

			// Not found.
			return null;
		}

		public int MilestoneID {
			get { return milestoneID; }
			set {
				if (value == InvalidID) {
					string message = Resources.String_InvalidMilestoneID;
					throw new ArgumentException(message);
				}

				milestoneID = value;
			}
		}

		public int TicketNumber {
			get { return ticketNumber; }
			set { ticketNumber = value; }
		}

		public string Summary {
			get { return summary; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				summary = value;
			}
		}

		public string ReportedBy {
			get { return reportedBy; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				reportedBy = value;
			}
		}

		public TicketType Type {
			get { return type; }
			set { type = value; }
		}

		public TicketSeverity Severity {
			get { return severity; }
			set { severity = value; }
		}

		public TicketState State {
			get { return state; }
			set { state = value; }
		}

		public string AssignedTo {
			get { return assignedTo; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				assignedTo = value;
			}
		}

		public TicketPriority Priority {
			get { return priority; }
			set { priority = value; }
		}

		public string Description {
			get { return description; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				description = value;
			}
		}

		public DateTime CreateTimestamp {
			get { return createTimestamp; }
			set { createTimestamp = value; }
		}

		public DateTime ModifyTimestamp {
			get { return modifyTimestamp; }
			set { modifyTimestamp = value; }
		}

		private Ticket() {
			// Blank
		}

		public Ticket(IDatabaseProvider db, int projectID, int milestoneID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (projectID == InvalidID) {
				string message = Resources.String_InvalidProjectID;
				throw new ArgumentException(message, nameof(projectID));
			}
			if (milestoneID == InvalidID) {
				string message = Resources.String_InvalidMilestoneID;
				throw new ArgumentException(message, nameof(milestoneID));
			}

			this.milestoneID = milestoneID;
			ticketNumber = 0;
			summary = string.Empty;
			reportedBy = string.Empty;
			type = (TicketType)(-1);
			severity = (TicketSeverity)(-1);
			state = (TicketState)(-1);
			assignedTo = string.Empty;
			priority = (TicketPriority)(-1);
			description = string.Empty;

			// Find max ticket number.
			TicketsTableAdapter tableAdapter = db.DB.TicketsTableAdapter;
			int? maxTicketNumber = tableAdapter.GetMaxTicketNumber(projectID);
			if (maxTicketNumber.HasValue) {
				ticketNumber = maxTicketNumber.Value + 1;
			}
			else {
				ticketNumber = 1;
			}
		}

		protected override void AddPrivate(Database db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID != InvalidID) {
				string message = Resources.String_CurrentObjectAlreadyAdded;
				throw new InvalidOperationException(message);
			}

			// Add.

			createTimestamp = modifyTimestamp = DateTime.UtcNow;

			TicketsTableAdapter tableAdapter = db.TicketsTableAdapter;

			tableAdapter.Insert(
				milestoneID,
				ticketNumber,
				summary,
				reportedBy,
				(int)type,
				(int)severity,
				(int)state,
				assignedTo,
				(int)priority,
				description,
				createTimestamp,
				modifyTimestamp);

			// Find ID.
			ID = tableAdapter.GetID(
				milestoneID,
				ticketNumber,
				summary,
				reportedBy,
				(int)type,
				(int)severity,
				(int)state,
				assignedTo,
				(int)priority,
				description).Value;
		}

		public Ticket Copy() {
			return new Ticket() {
				ID = ID,
				AssignedTo = AssignedTo,
				CreateTimestamp = CreateTimestamp,
				Description = Description,
				MilestoneID = MilestoneID,
				ModifyTimestamp = ModifyTimestamp,
				Priority = Priority,
				ReportedBy = ReportedBy,
				Severity = Severity,
				State = State,
				Summary = Summary,
				TicketNumber = TicketNumber,
				Type = Type,
			};
		}

		public bool UpdateAndGenerateHistoryRecord(IDatabaseProvider db, ITicketChangeFormatter formatter, Action<Ticket> assignNewProperties) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (formatter == null) throw new ArgumentNullException(nameof(formatter));
			if (assignNewProperties == null) throw new ArgumentNullException(nameof(assignNewProperties));

			var @new = Copy();
			assignNewProperties(@new);

			if (@new.ID != ID) throw new InvalidOperationException("Cannot modify ticket ID");
			if (@new.TicketNumber != TicketNumber) throw new InvalidOperationException("Cannot modify ticket number");

			// Changes.
			var changesStringBuilder = new StringBuilder();

			// Milestone.
			if (MilestoneID != @new.MilestoneID) {
				changesStringBuilder.AppendFormat(formatter.Milestone(db, MilestoneID, @new.MilestoneID));
				changesStringBuilder.AppendLine();
				MilestoneID = @new.MilestoneID;
			}
			// Summary.
			if (Summary != @new.Summary) {
				changesStringBuilder.AppendFormat(formatter.Summary(Summary, @new.Summary));
				changesStringBuilder.AppendLine();
				Summary = @new.Summary;
			}
			// Reported by.
			if (ReportedBy != @new.ReportedBy) {
				changesStringBuilder.AppendFormat(formatter.ReportedBy(ReportedBy, @new.ReportedBy));
				changesStringBuilder.AppendLine();
				ReportedBy = @new.ReportedBy;
			}
			// Type.
			if (Type != @new.Type) {
				changesStringBuilder.AppendFormat(formatter.Type(Type, @new.Type));
				changesStringBuilder.AppendLine();
				Type = @new.Type;
			}
			// Severity.
			if (Severity != @new.Severity) {
				changesStringBuilder.AppendFormat(formatter.Severity(Severity, @new.Severity));
				changesStringBuilder.AppendLine();
				Severity = @new.Severity;
			}
			// State.
			if (State != @new.State) {
				changesStringBuilder.AppendFormat(formatter.State(State, @new.State));
				changesStringBuilder.AppendLine();
				State = @new.State;
			}
			// AssignedTo.
			if (AssignedTo != @new.AssignedTo) {
				changesStringBuilder.AppendFormat(formatter.AssignedTo(AssignedTo, @new.AssignedTo));
				changesStringBuilder.AppendLine();
				AssignedTo = @new.AssignedTo;
			}
			// Priority.
			if (Priority != @new.Priority) {
				changesStringBuilder.AppendFormat(formatter.Priority(Priority, @new.Priority));
				changesStringBuilder.AppendLine();
				Priority = @new.Priority;
			}
			// Description.
			if (Description != @new.Description) {
				changesStringBuilder.AppendFormat(formatter.Description(Description, @new.Description));
				changesStringBuilder.AppendLine();
				Description = @new.Description;
			}

			string changes = changesStringBuilder.ToString();
			if (string.IsNullOrEmpty(changes)) return false;

			UpdatePrivate(db.DB);
			
			TicketHistory ticketHistory = NewHistory(changes);
			ticketHistory.Add(db);
			return true;
		}

		protected override void UpdatePrivate(Database db) {
			modifyTimestamp = DateTime.UtcNow;

			TicketsTableAdapter tableAdapter = db.TicketsTableAdapter;

			tableAdapter.UpdateByID(
				milestoneID,
				ticketNumber,
				summary,
				reportedBy,
				(int)type,
				(int)severity,
				(int)state,
				assignedTo,
				(int)priority,
				description,
				modifyTimestamp,
				ID);
		}

		protected override void DeletePrivate(Database db) {
			TicketsTableAdapter tableAdapter = db.TicketsTableAdapter;

			tableAdapter.DeleteByID(ID);

			ID = InvalidID;
		}

		public Milestone GetMilestone(IDatabaseProvider db) {
			return Milestone.GetMilestone(db, milestoneID);
		}

		public TicketHistory[] GetHistory(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return TicketHistory.GetTicketHistoryByTicketID(db, ID);
		}

		public TicketHistory NewHistory(string changes) {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return new TicketHistory(ID) {
				Timestamp = DateTime.UtcNow,
				Changes = changes,
				Comment = Description,
			};
		}

		public Attachment[] GetAttachments(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return Attachment.GetAttachments(db, ID);
		}

		public Attachment[] GetAttachmentsWithoutContents(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return Attachment.GetAttachmentsWithoutContents(db, ID);
		}

		public Attachment NewAttachment() {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return new Attachment(ID);
		}

		public override string ToString() {
			return summary;
		}

		internal Ticket(PeygirDatabaseDataSet.TicketsRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			milestoneID = row.MilestoneID;
			ticketNumber = row.TicketNumber;
			summary = row.Summary;
			reportedBy = row.ReportedBy;
			type = (TicketType)row.Type;
			severity = (TicketSeverity)row.Severity;
			state = (TicketState)row.State;
			assignedTo = row.AssignedTo;
			priority = (TicketPriority)row.Priority;
			description = row.Description;
			createTimestamp = DateTime.SpecifyKind(row.CreateTimestamp, DateTimeKind.Utc);
			modifyTimestamp = DateTime.SpecifyKind(row.ModifyTimestamp, DateTimeKind.Utc);
		}

		private int milestoneID;
		private int ticketNumber;
		private string summary;
		private string reportedBy;
		private TicketType type;
		private TicketSeverity severity;
		private TicketState state;
		private string assignedTo;
		private TicketPriority priority;
		private string description;
		private DateTime createTimestamp;
		private DateTime modifyTimestamp;
	}
}

using System;
using System.Collections.Generic;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class Attachment : DBObject {
		public static Attachment[] GetAttachments(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			AttachmentsTableAdapter tableAdapter = db.DB.AttachmentsTableAdapter;
			PeygirDatabaseDataSet.AttachmentsDataTable rows = tableAdapter.GetData();

			// Create list.
			List<Attachment> attachments = new List<Attachment>();
			foreach (var row in rows) {
				// Add.
				Attachment attachment = new Attachment(row);
				attachments.Add(attachment);
			}

			return attachments.ToArray();
		}

		public static Attachment[] GetAttachments(IDatabaseProvider db, int ticketID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			AttachmentsTableAdapter tableAdapter = db.DB.AttachmentsTableAdapter;
			PeygirDatabaseDataSet.AttachmentsDataTable rows = tableAdapter.GetDataByTicketID(ticketID);

			// Create list.
			List<Attachment> attachments = new List<Attachment>();
			foreach (var row in rows) {
				// Add.
				Attachment attachment = new Attachment(row);
				attachments.Add(attachment);
			}

			return attachments.ToArray();
		}

		public static Attachment[] GetAttachmentsWithoutContents(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			AttachmentsWithoutContentsTableAdapter tableAdapter = db.DB.AttachmentsWithoutContentsTableAdapter;
			PeygirDatabaseDataSet.AttachmentsWithoutContentsDataTable rows = tableAdapter.GetData();

			// Create list.
			List<Attachment> attachments = new List<Attachment>();
			foreach (var row in rows) {
				// Add.
				Attachment attachment = new Attachment(row);
				attachments.Add(attachment);
			}

			return attachments.ToArray();
		}

		public static Attachment[] GetAttachmentsWithoutContents(IDatabaseProvider db, int ticketID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			AttachmentsWithoutContentsTableAdapter tableAdapter = db.DB.AttachmentsWithoutContentsTableAdapter;
			PeygirDatabaseDataSet.AttachmentsWithoutContentsDataTable rows = tableAdapter.GetDataByTicketID(ticketID);

			// Create list.
			List<Attachment> attachments = new List<Attachment>();
			foreach (var row in rows) {
				// Add.
				Attachment attachment = new Attachment(row);
				attachments.Add(attachment);
			}

			return attachments.ToArray();
		}

		public static Attachment GetAttachment(IDatabaseProvider db, int id) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			AttachmentsTableAdapter tableAdapter = db.DB.AttachmentsTableAdapter;
			PeygirDatabaseDataSet.AttachmentsDataTable rows = tableAdapter.GetDataByID(id);

			if (rows.Count == 1) {
				// Found.
				Attachment attachment = new Attachment(rows[0]);
				return attachment;
			}

			// Not found.
			return null;
		}

		public int TicketID {
			get { return ticketID; }
		}

		public string Name {
			get { return name; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				name = value;
			}
		}

		public int Size {
			get { return size; }
		}

		public Attachment(int ticketID) {
			if (ticketID == InvalidID) {
				string message = Resources.String_InvalidTicketID;
				throw new ArgumentException(message, nameof(ticketID));
			}

			this.ticketID = ticketID;
			name = string.Empty;
			size = 0;
			contents = string.Empty;
		}

		protected override void AddPrivate(Database db) {
			AttachmentsTableAdapter tableAdapter = db.AttachmentsTableAdapter;

			tableAdapter.Insert(ticketID, name, size, contents);

			// Find ID.
			ID = tableAdapter.Connection.GetInsertedIdentity();
		}

		protected override void UpdatePrivate(Database db) {
			AttachmentsTableAdapter tableAdapter = db.AttachmentsTableAdapter;

			tableAdapter.UpdateByID(ticketID, name, size, contents, ID);
		}

		protected override void DeletePrivate(Database db) {
			AttachmentsTableAdapter tableAdapter = db.AttachmentsTableAdapter;

			tableAdapter.DeleteByID(ID);

			ID = InvalidID;
		}

		public byte[] GetContents() {
			return Convert.FromBase64String(contents);
		}

		public void SetContents(byte[] contents) {
			if (contents == null) {
				throw new ArgumentNullException(nameof(contents));
			}

			this.contents = Convert.ToBase64String(contents);
			this.size = contents.Length;
		}

		public Ticket GetTicket(IDatabaseProvider db) {
			return Ticket.GetTicket(db, ticketID);
		}

		public override string ToString() {
			return name;
		}

		internal Attachment(PeygirDatabaseDataSet.AttachmentsRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			ticketID = row.TicketID;
			name = row.Name;
			size = row.Size;
			contents = row.Contents;
		}

		internal Attachment(PeygirDatabaseDataSet.AttachmentsWithoutContentsRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			ticketID = row.TicketID;
			name = row.Name;
			size = row.Size;
			contents = Convert.ToBase64String(new byte[0]);
		}

		private int ticketID;
		private string name;
		private int size;
		private string contents;
	}
}

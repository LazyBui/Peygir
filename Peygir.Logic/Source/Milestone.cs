using System;
using System.Collections.Generic;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class Milestone : DBObject {
		public static Milestone[] GetMilestones(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			MilestonesTableAdapter tableAdapter = db.DB.MilestonesTableAdapter;
			PeygirDatabaseDataSet.MilestonesDataTable rows = tableAdapter.GetData();

			// Create list.
			List<Milestone> milestones = new List<Milestone>();
			foreach (var row in rows) {
				// Add.
				Milestone milestone = new Milestone(row);
				milestones.Add(milestone);
			}

			return milestones.ToArray();
		}

		public static Milestone[] GetMilestones(IDatabaseProvider db, int projectID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			MilestonesTableAdapter tableAdapter = db.DB.MilestonesTableAdapter;
			PeygirDatabaseDataSet.MilestonesDataTable rows = tableAdapter.GetDataByProjectID(projectID);

			// Create list.
			List<Milestone> milestones = new List<Milestone>();
			foreach (var row in rows) {
				// Add.
				Milestone milestone = new Milestone(row);
				milestones.Add(milestone);
			}

			return milestones.ToArray();
		}

		public static Milestone GetMilestone(IDatabaseProvider db, int id) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			MilestonesTableAdapter tableAdapter = db.DB.MilestonesTableAdapter;
			PeygirDatabaseDataSet.MilestonesDataTable rows = tableAdapter.GetDataByID(id);

			if (rows.Count == 1) {
				// Found.
				Milestone milestone = new Milestone(rows[0]);
				return milestone;
			}

			// Not found.
			return null;
		}

		public int ProjectID {
			get { return projectID; }
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

		public string Description {
			get { return description; }
			set {
				if (value == null) {
					throw new ArgumentNullException();
				}
				description = value;
			}
		}

		public MilestoneState State {
			get { return state; }
			set { state = value; }
		}

		public int DisplayOrder {
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		public Milestone(IDatabaseProvider db, int projectID) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (projectID == InvalidID) {
				string message = Resources.String_InvalidProjectID;
				throw new ArgumentException(message, nameof(projectID));
			}

			this.projectID = projectID;
			name = string.Empty;
			description = string.Empty;
			state = (MilestoneState)(-1);
			displayOrder = -1;

			// Find max display order.
			MilestonesTableAdapter tableAdapter = db.DB.MilestonesTableAdapter;
			int? maxDisplayOrder = tableAdapter.GetMaxDisplayOrder(projectID);
			if (maxDisplayOrder.HasValue) {
				displayOrder = maxDisplayOrder.Value + 1;
			}
			else {
				displayOrder = 1;
			}
		}

		protected override void AddPrivate(Database db) {
			MilestonesTableAdapter tableAdapter = db.MilestonesTableAdapter;

			tableAdapter.Insert(projectID, name, description, (int)state, displayOrder);

			// Find ID.
			ID = tableAdapter.Connection.GetInsertedIdentity();
		}

		protected override void UpdatePrivate(Database db) {
			MilestonesTableAdapter tableAdapter = db.MilestonesTableAdapter;

			tableAdapter.UpdateByID(projectID, name, description, (int)state, displayOrder, ID);
		}

		protected override void DeletePrivate(Database db) {
			MilestonesTableAdapter tableAdapter = db.MilestonesTableAdapter;

			tableAdapter.DeleteByID(ID);

			ID = InvalidID;
		}

		public Project GetProject(IDatabaseProvider db) {
			return Project.GetProject(db, projectID);
		}

		public Ticket[] GetTickets(IDatabaseProvider db) {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return Ticket.GetTickets(db, ID);
		}

		public Ticket NewTicket(IDatabaseProvider db) {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return new Ticket(db, ProjectID, ID);
		}

		public override string ToString() {
			return name;
		}

		internal Milestone(PeygirDatabaseDataSet.MilestonesRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			projectID = row.ProjectID;
			name = row.Name;
			description = row.Description;
			state = (MilestoneState)row.State;
			displayOrder = row.DisplayOrder;
		}

		private int projectID;
		private string name;
		private string description;
		private MilestoneState state;
		private int displayOrder;
	}
}

using System;
using System.Collections.Generic;
using Peygir.Data;
using Peygir.Data.PeygirDatabaseDataSetTableAdapters;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public class Project : DBObject {
		public static Project[] GetProjects(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			ProjectsTableAdapter tableAdapter = db.DB.ProjectsTableAdapter;
			PeygirDatabaseDataSet.ProjectsDataTable rows = tableAdapter.GetData();

			// Create list.
			List<Project> projects = new List<Project>();
			foreach (var row in rows) {
				// Add.
				Project project = new Project(row);
				projects.Add(project);
			}

			return projects.ToArray();
		}

		public static Project GetProject(IDatabaseProvider db, int id) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			ProjectsTableAdapter tableAdapter = db.DB.ProjectsTableAdapter;
			PeygirDatabaseDataSet.ProjectsDataTable rows = tableAdapter.GetDataByID(id);

			if (rows.Count == 1) {
				// Found.
				Project project = new Project(rows[0]);
				return project;
			}

			// Not found.
			return null;
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

		public int DisplayOrder {
			get { return displayOrder; }
			set { displayOrder = value; }
		}

		public ProjectState State {
			get { return state; }
			set { state = value; }
		}

		public Project(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			name = string.Empty;
			description = string.Empty;
			displayOrder = -1;

			// Find max display order.
			ProjectsTableAdapter tableAdapter = db.DB.ProjectsTableAdapter;
			int? maxDisplayOrder = tableAdapter.GetMaxDisplayOrder();
			if (maxDisplayOrder.HasValue) {
				displayOrder = maxDisplayOrder.Value + 1;
			}
			else {
				displayOrder = 1;
			}

			state = ProjectState.Active;
		}

		protected override void AddPrivate(Database db) {
			ProjectsTableAdapter tableAdapter = db.ProjectsTableAdapter;

			tableAdapter.Insert(name, description, displayOrder, (int)state);

			// Find ID.
			ID = tableAdapter.Connection.GetInsertedIdentity();
		}

		protected override void UpdatePrivate(Database db) {
			ProjectsTableAdapter tableAdapter = db.ProjectsTableAdapter;

			tableAdapter.UpdateByID(name, description, displayOrder, (int)state, ID);
		}

		protected override void DeletePrivate(Database db) {
			ProjectsTableAdapter tableAdapter = db.ProjectsTableAdapter;

			tableAdapter.DeleteByID(ID);

			ID = InvalidID;
		}

		public Milestone[] GetMilestones(IDatabaseProvider db) {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return Milestone.GetMilestones(db, ID);
		}

		public Milestone NewMilestone(IDatabaseProvider db) {
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			return new Milestone(db, ID);
		}

		public Ticket[] GetTickets(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}

			TicketsTableAdapter tableAdapter = db.DB.TicketsTableAdapter;;

			PeygirDatabaseDataSet.TicketsDataTable rows = tableAdapter.GetDataByProjectID(ID);

			// Create list.
			List<Ticket> tickets = new List<Ticket>();
			foreach (var row in rows) {
				// Add.
				Ticket ticket = new Ticket(row);
				tickets.Add(ticket);
			}

			return tickets.ToArray();
		}

		public override string ToString() {
			return name;
		}

		internal Project(PeygirDatabaseDataSet.ProjectsRow row) {
			if (row == null) {
				throw new ArgumentNullException(nameof(row));
			}

			ID = row.ID;
			name = row.Name;
			description = row.Description;
			displayOrder = row.DisplayOrder;
			state = (ProjectState)row.State;
		}

		private string name;
		private string description;
		private int displayOrder;
		private ProjectState state;
	}
}

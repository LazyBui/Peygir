using System;
using Peygir.Logic.Properties;

namespace Peygir.Logic {
	public abstract class DBObject {
		public const int InvalidID = -1;

		public int ID { get; protected set; }

		public void Add(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID != InvalidID) {
				string message = Resources.String_CurrentObjectAlreadyAdded;
				throw new InvalidOperationException(message);
			}
			AddPrivate(db.DB);
		}

		protected abstract void AddPrivate(Database db);

		public void Update(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}
			UpdatePrivate(db.DB);
		}

		protected abstract void UpdatePrivate(Database db);

		public void Delete(IDatabaseProvider db) {
			if (db == null) throw new ArgumentNullException(nameof(db));
			if (ID == InvalidID) {
				string message = Resources.String_CurrentObjectDoesNotExistInTheDatabase;
				throw new InvalidOperationException(message);
			}
			DeletePrivate(db.DB);
		}

		protected abstract void DeletePrivate(Database db);

		protected DBObject() {
			ID = InvalidID;
		}

		protected static bool IsEqual<TValue>(TValue left, TValue right) where TValue : DBObject {
			if (object.ReferenceEquals(left, null) && object.ReferenceEquals(right, null)) return true;
			if (object.ReferenceEquals(left, null)) return false;
			if (object.ReferenceEquals(right, null)) return false;
			return left.ID == right.ID;
		}

		public override int GetHashCode() {
			return ID.GetHashCode();
		}
	}
}

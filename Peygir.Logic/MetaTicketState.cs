using System;

namespace Peygir.Logic {
	public enum MetaTicketState {
		// Actual ticket states, update these if TicketState updates
		New,
		Accepted,
		Closed,
		Completed,
		InProgress,
		Blocked,
		// Meta states
		Open,
		Finished,
	}

	public static class MetaTicketStateExtensions {
		public static bool AppliesTo(this MetaTicketState @this, TicketState state) {
			if (@this == MetaTicketState.Open) return state.IsOpen();
			if (@this == MetaTicketState.Finished) return state.IsFinished();
			if (@this == MetaTicketState.Accepted) return state == TicketState.Accepted;
			if (@this == MetaTicketState.Closed) return state == TicketState.Closed;
			if (@this == MetaTicketState.Completed) return state == TicketState.Completed;
			if (@this == MetaTicketState.New) return state == TicketState.New;
			if (@this == MetaTicketState.InProgress) return state == TicketState.InProgress;
			if (@this == MetaTicketState.Blocked) return state == TicketState.Blocked;
			throw new NotImplementedException();
		}
	}
}

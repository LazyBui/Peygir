namespace Peygir.Logic {
	public enum TicketState {
		New,
		Accepted,
		Closed,
		Completed,
		InProgress,
		Blocked,
	}

	public static class TicketStateExtensions {
		public static bool IsOpen(this TicketState @this) {
			return
				@this == TicketState.New ||
				@this == TicketState.Accepted ||
				@this == TicketState.InProgress ||
				@this == TicketState.Blocked;
		}

		public static bool IsFinished(this TicketState @this) {
			return @this == TicketState.Closed || @this == TicketState.Completed;
		}
	}
}

using System;

namespace Peygir.Logic {
	public interface ITicketChangeFormatter {
		string Milestone(int old, int @new);
		string Summary(string old, string @new);
		string ReportedBy(string old, string @new);
		string AssignedTo(string old, string @new);
		string Type(TicketType old, TicketType @new);
		string Severity(TicketSeverity old, TicketSeverity @new);
		string State(TicketState old, TicketState @new);
		string Priority(TicketPriority old, TicketPriority @new);
		string Description(string old, string @new);
	}
}

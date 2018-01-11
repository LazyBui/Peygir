using System;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	internal sealed class TicketChangeFormatter : ITicketChangeFormatter {
		public static readonly TicketChangeFormatter Default = new TicketChangeFormatter();

		public string AssignedTo(string old, string @new) {
			return string.Format(Resources.String_AssignedToChangesFromXToY,
				old,
				@new);
		}

		public string Description(string old, string @new) {
			return Resources.String_DescriptionChanges;
		}

		public string Milestone(int old, int @new) {
			return string.Format(Resources.String_MilestoneChangesFromXToY,
				Logic.Milestone.GetMilestone(old).Name,
				Logic.Milestone.GetMilestone(@new).Name);
		}

		public string Priority(TicketPriority old, TicketPriority @new) {
			return string.Format(Resources.String_PriorityChangesFromXToY,
				TranslateTicketPriority(old),
				TranslateTicketPriority(@new));
		}

		public string ReportedBy(string old, string @new) {
			return string.Format(Resources.String_ReportedByChangesFromXToY,
				old,
				@new);
		}

		public string Severity(TicketSeverity old, TicketSeverity @new) {
			return string.Format(Resources.String_SeverityChangesFromXToY,
				TranslateTicketSeverity(old),
				TranslateTicketSeverity(@new));
		}

		public string State(TicketState old, TicketState @new) {
			return string.Format(Resources.String_StateChangesFromXToY,
				TranslateTicketState(old),
				TranslateTicketState(@new));
		}

		public string Summary(string old, string @new) {
			return string.Format(Resources.String_SummaryChangesFromXToY,
				old,
				@new);
		}

		public string Type(TicketType old, TicketType @new) {
			return string.Format(Resources.String_TypeChangesFromXToY,
				TranslateTicketType(old),
				TranslateTicketType(@new));
		}

		private string TranslateTicketType(TicketType ticketType) {
			switch (ticketType) {
				case TicketType.Defect:
					return Resources.String_Defect;

				case TicketType.FeatureRequest:
					return Resources.String_FeatureRequest;

				case TicketType.Task:
					return Resources.String_Task;

				default:
					return ticketType.ToString();
			}
		}

		private string TranslateTicketSeverity(TicketSeverity ticketSeverity) {
			switch (ticketSeverity) {
				case TicketSeverity.Blocker:
					return Resources.String_Blocker;

				case TicketSeverity.Critical:
					return Resources.String_Critical;

				case TicketSeverity.Major:
					return Resources.String_Major;

				case TicketSeverity.Normal:
					return Resources.String_Normal;

				case TicketSeverity.Minor:
					return Resources.String_Minor;

				case TicketSeverity.Trivial:
					return Resources.String_Trivial;

				default:
					return ticketSeverity.ToString();
			}
		}

		private string TranslateTicketState(TicketState ticketState) {
			switch (ticketState) {
				case TicketState.New:
					return Resources.String_New;

				case TicketState.Accepted:
					return Resources.String_Accepted;

				case TicketState.Closed:
					return Resources.String_Closed;

				case TicketState.Completed:
					return Resources.String_Completed;

				case TicketState.InProgress:
					return Resources.String_InProgress;

				case TicketState.Blocked:
					return Resources.String_Blocked;

				default:
					return ticketState.ToString();
			}
		}

		private string TranslateTicketPriority(TicketPriority ticketPriority) {
			switch (ticketPriority) {
				case TicketPriority.Lowest:
					return Resources.String_Lowest;

				case TicketPriority.Low:
					return Resources.String_Low;

				case TicketPriority.Normal:
					return Resources.String_Normal;

				case TicketPriority.High:
					return Resources.String_High;

				case TicketPriority.Highest:
					return Resources.String_Highest;

				default:
					return ticketPriority.ToString();
			}
		}
	}
}

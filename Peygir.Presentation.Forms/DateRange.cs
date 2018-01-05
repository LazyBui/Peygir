using System;
using Peygir.Logic;
using Peygir.Presentation.Forms.Properties;

namespace Peygir.Presentation.Forms {
	public sealed class DateRange {
		public DateTime? LowBound { get; private set; }
		public DateTime? HighBound { get; private set; }

		public DateRange(DateTime? low, DateTime? high) {
			LowBound = low != null ?
				low.Value.ToUniversalTime() :
				null as DateTime?;
			HighBound = high != null ?
				high.Value.ToUniversalTime() :
				null as DateTime?;
			;
		}

		public DateRange(bool hasLow, DateTime low, bool hasHigh, DateTime high) {
			LowBound = hasLow ?
				low.ToUniversalTime() :
				null as DateTime?;
			HighBound = hasHigh ?
				high.ToUniversalTime() :
				null as DateTime?;
			;
		}

		public DateRange WithLowBound(DateTime? low) {
			if (low == null && HighBound == null)
				return null;
			return new DateRange(low, HighBound);
		}

		public DateRange WithLowBound(bool hasLow, DateTime low) {
			if (!hasLow && HighBound == null)
				return null;
			return new DateRange(low, HighBound);
		}

		public DateRange WithHighBound(DateTime? high) {
			if (LowBound == null && high == null)
				return null;
			return new DateRange(LowBound, high);
		}

		public DateRange WithHighBound(bool hasHigh, DateTime high) {
			if (LowBound == null && !hasHigh)
				return null;
			return new DateRange(LowBound, high);
		}

		internal static DateRange Normalize(DateTime? low, DateTime? high) {
			if (low == null && high == null)
				return null;
			return new DateRange(low, high);
		}

		internal static DateRange Normalize(bool hasLow, DateTime low, bool hasHigh, DateTime high) {
			if (!hasLow && !hasHigh)
				return null;
			return new DateRange(hasLow, low, hasHigh, high);
		}

		internal static DateRange Normalize(bool hasLow, DateTime low, DateTime? high) {
			if (!hasLow && high == null)
				return null;
			return new DateRange(hasLow ? low : null as DateTime?, high);
		}

		internal static DateRange Normalize(DateTime? low, bool hasHigh, DateTime high) {
			if (low == null && !hasHigh)
				return null;
			return new DateRange(low, hasHigh ? high : null as DateTime?);
		}

		public bool Contains(DateTime time) {
			bool lowSatisfied = LowBound == null || time >= LowBound;
			bool highSatisfied = HighBound == null || time < HighBound;
			return lowSatisfied && highSatisfied;
		}

		public string ToString(DateTimeFormatter formatter) {
			if (LowBound == null && HighBound == null)
				return null;
			if (LowBound == null)
				return "* - " + formatter.Format(HighBound.Value);
			if (HighBound == null)
				return formatter.Format(LowBound.Value) + " - *";
			return formatter.Format(LowBound.Value) + " - " + formatter.Format(HighBound.Value);
		}

		public override string ToString() {
			return ToString(FormUtil.GetFormatter());
		}
	}
}

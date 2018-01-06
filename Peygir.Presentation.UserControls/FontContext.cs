using System;
using System.Drawing;

namespace Peygir.Presentation.UserControls {
	public sealed class FontContext {
		public Font SansSerif { get; private set; }
		public Font Monospace { get; private set; }
		public bool UseSansSerif { get; private set; }
		public bool WordWrap { get; private set; }

		public FontContext(Font sansSerif, Font monospace, bool useSansSerif, bool wordWrap) {
			if (sansSerif == null) throw new ArgumentNullException(nameof(sansSerif));
			if (monospace == null) throw new ArgumentNullException(nameof(monospace));
			SansSerif = sansSerif;
			Monospace = monospace;
			UseSansSerif = useSansSerif;
			WordWrap = wordWrap;
		}
	}
}

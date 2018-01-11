using System;

namespace Peygir.Logic {
	public interface IDatabaseProvider {
		Database DB { get; }
	}
}

using System;

namespace Peygir.Logic {
	public sealed class BackwardCompatibilityException : InvalidOperationException {
		internal BackwardCompatibilityException(string message) : base(message) {
		}
	}
}

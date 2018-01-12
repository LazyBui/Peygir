using System;

namespace Peygir.Logic {
	public sealed class ManualTamperingException : InvalidOperationException {
		internal ManualTamperingException(string message) : base(message) {
		}
	}
}

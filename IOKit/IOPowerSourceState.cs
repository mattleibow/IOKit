using System;

namespace IOKit
{
	public readonly struct IOPowerSourceState : IEquatable<IOPowerSourceState>
	{
		private readonly string state;

		public static IOPowerSourceState OffLine { get; } = new IOPowerSourceState("Off Line");

		public static IOPowerSourceState ACPower { get; } = new IOPowerSourceState("AC Power");

		public static IOPowerSourceState BatteryPower { get; } = new IOPowerSourceState("Battery Power");

		IOPowerSourceState(string state)
		{
			if (state == null)
				throw new ArgumentNullException(nameof(state));

			if (state.Length == 0)
				throw new ArgumentException(nameof(state));

			this.state = state;
		}

		public static IOPowerSourceState Create(string state) =>
			new IOPowerSourceState(state);

		public bool Equals(IOPowerSourceState other) =>
			Equals(other.state);

		internal bool Equals(string other) =>
			string.Equals(state, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceState && Equals((IOPowerSourceState)obj);

		public override int GetHashCode() =>
			state == null ? 0 : state.GetHashCode();

		public override string ToString() =>
			state ?? string.Empty;

		public static bool operator ==(IOPowerSourceState left, IOPowerSourceState right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceState left, IOPowerSourceState right) =>
			!(left == right);
	}
}

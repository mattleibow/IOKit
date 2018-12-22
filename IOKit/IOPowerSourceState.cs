using System;

namespace IOKit
{
	public readonly struct IOPowerSourceState : IEquatable<IOPowerSourceState>
	{
		private const string kIOPSOffLineValue = "Off Line";
		private const string kIOPSACPowerValue = "AC Power";
		private const string kIOPSBatteryPowerValue = "Battery Power";

		private readonly string state;

		public static IOPowerSourceState OffLine { get; } = new IOPowerSourceState(kIOPSOffLineValue);

		public static IOPowerSourceState ACPower { get; } = new IOPowerSourceState(kIOPSACPowerValue);

		public static IOPowerSourceState BatteryPower { get; } = new IOPowerSourceState(kIOPSBatteryPowerValue);

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

using System;

namespace IOKit
{
	public readonly struct IOPowerSourceState : IEquatable<IOPowerSourceState>
	{
		private const string kIOPSOffLineValue = "Off Line";
		private const string kIOPSACPowerValue = "AC Power";
		private const string kIOPSBatteryPowerValue = "Battery Power";

		private readonly string value;

		public static IOPowerSourceState OffLine { get; } = new IOPowerSourceState(kIOPSOffLineValue);

		public static IOPowerSourceState ACPower { get; } = new IOPowerSourceState(kIOPSACPowerValue);

		public static IOPowerSourceState BatteryPower { get; } = new IOPowerSourceState(kIOPSBatteryPowerValue);

		IOPowerSourceState(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceState? Create(string value) =>
			value == null ? (IOPowerSourceState?)null : new IOPowerSourceState(value);

		public bool Equals(IOPowerSourceState other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceState && Equals((IOPowerSourceState)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceState left, IOPowerSourceState right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceState left, IOPowerSourceState right) =>
			!(left == right);
	}
}

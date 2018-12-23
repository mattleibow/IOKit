using System;

namespace IOKit
{
	public readonly struct IOPowerSourceBatteryHealth : IEquatable<IOPowerSourceBatteryHealth>
	{
		private const string kIOPSPoorValue = "Poor";
		private const string kIOPSFairValue = "Fair";
		private const string kIOPSGoodValue = "Good";

		private readonly string value;

		public static IOPowerSourceBatteryHealth Poor { get; } = new IOPowerSourceBatteryHealth(kIOPSPoorValue);

		public static IOPowerSourceBatteryHealth Fair { get; } = new IOPowerSourceBatteryHealth(kIOPSFairValue);

		public static IOPowerSourceBatteryHealth Good { get; } = new IOPowerSourceBatteryHealth(kIOPSGoodValue);

		IOPowerSourceBatteryHealth(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceBatteryHealth? Create(string value) =>
			value == null ? (IOPowerSourceBatteryHealth?)null : new IOPowerSourceBatteryHealth(value);

		public bool Equals(IOPowerSourceBatteryHealth other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceBatteryHealth && Equals((IOPowerSourceBatteryHealth)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceBatteryHealth left, IOPowerSourceBatteryHealth right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceBatteryHealth left, IOPowerSourceBatteryHealth right) =>
			!(left == right);
	}
}

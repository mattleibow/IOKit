using System;

namespace IOKit
{
	public readonly struct IOPowerSourceProvidingType : IEquatable<IOPowerSourceProvidingType>
	{
		private const string kIOPMUPSPowerKey = "UPS Power";
		private const string kIOPMBatteryPowerKey = "Battery Power";
		private const string kIOPMACPowerKey = "AC Power";

		private readonly string value;

		public static IOPowerSourceProvidingType UPS { get; } = new IOPowerSourceProvidingType(kIOPMUPSPowerKey);

		public static IOPowerSourceProvidingType Battery { get; } = new IOPowerSourceProvidingType(kIOPMBatteryPowerKey);

		public static IOPowerSourceProvidingType AC { get; } = new IOPowerSourceProvidingType(kIOPMACPowerKey);

		IOPowerSourceProvidingType(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceProvidingType? Create(string value) =>
			value == null ? (IOPowerSourceProvidingType?)null : new IOPowerSourceProvidingType(value);

		public bool Equals(IOPowerSourceProvidingType other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceProvidingType && Equals((IOPowerSourceProvidingType)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceProvidingType left, IOPowerSourceProvidingType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceProvidingType left, IOPowerSourceProvidingType right) =>
			!(left == right);
	}
}

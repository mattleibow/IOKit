using System;

namespace IOKit
{
	public readonly struct IOPowerSourceType : IEquatable<IOPowerSourceType>
	{
		private const string kIOPSInternalBatteryType = "InternalBattery";
		private const string kIOPSUPSType = "UPS";

		private readonly string value;

		public static IOPowerSourceType UPS { get; } = new IOPowerSourceType(kIOPSUPSType);

		public static IOPowerSourceType InternalBattery { get; } = new IOPowerSourceType(kIOPSInternalBatteryType);

		IOPowerSourceType(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceType? Create(string value) =>
			value == null ? (IOPowerSourceType?)null : new IOPowerSourceType(value);

		public bool Equals(IOPowerSourceType other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceType && Equals((IOPowerSourceType)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceType left, IOPowerSourceType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceType left, IOPowerSourceType right) =>
			!(left == right);
	}
}

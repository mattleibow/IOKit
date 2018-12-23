using System;

namespace IOKit
{
	public readonly struct IOPowerSourceTransportType : IEquatable<IOPowerSourceTransportType>
	{
		private const string kIOPSSerialTransportType = "Serial";
		private const string kIOPSUSBTransportType = "USB";
		private const string kIOPSNetworkTransportType = "Ethernet";
		private const string kIOPSInternalType = "Internal";

		private readonly string value;

		public static IOPowerSourceTransportType Serial { get; } = new IOPowerSourceTransportType(kIOPSSerialTransportType);

		public static IOPowerSourceTransportType Usb { get; } = new IOPowerSourceTransportType(kIOPSUSBTransportType);

		public static IOPowerSourceTransportType Ethernet { get; } = new IOPowerSourceTransportType(kIOPSNetworkTransportType);

		public static IOPowerSourceTransportType Internal { get; } = new IOPowerSourceTransportType(kIOPSInternalType);

		IOPowerSourceTransportType(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceTransportType? Create(string value) =>
			value == null ? (IOPowerSourceTransportType?)null : new IOPowerSourceTransportType(value);

		public bool Equals(IOPowerSourceTransportType other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceTransportType && Equals((IOPowerSourceTransportType)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceTransportType left, IOPowerSourceTransportType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceTransportType left, IOPowerSourceTransportType right) =>
			!(left == right);
	}
}

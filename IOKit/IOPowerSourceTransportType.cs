using System;

namespace IOKit
{
	public readonly struct IOPowerSourceTransportType : IEquatable<IOPowerSourceTransportType>
	{
		private const string kIOPSSerialTransportType = "Serial";
		private const string kIOPSUSBTransportType = "USB";
		private const string kIOPSNetworkTransportType = "Ethernet";
		private const string kIOPSInternalType = "Internal";

		private readonly string type;

		public static IOPowerSourceTransportType Serial { get; } = new IOPowerSourceTransportType(kIOPSSerialTransportType);

		public static IOPowerSourceTransportType Usb { get; } = new IOPowerSourceTransportType(kIOPSUSBTransportType);

		public static IOPowerSourceTransportType Ethernet { get; } = new IOPowerSourceTransportType(kIOPSNetworkTransportType);

		public static IOPowerSourceTransportType Internal { get; } = new IOPowerSourceTransportType(kIOPSInternalType);

		IOPowerSourceTransportType(string type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (type.Length == 0)
				throw new ArgumentException(nameof(type));

			this.type = type;
		}

		public static IOPowerSourceTransportType Create(string type) =>
			new IOPowerSourceTransportType(type);

		public bool Equals(IOPowerSourceTransportType other) =>
			Equals(other.type);

		internal bool Equals(string other) =>
			string.Equals(type, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceTransportType && Equals((IOPowerSourceTransportType)obj);

		public override int GetHashCode() =>
			type == null ? 0 : type.GetHashCode();

		public override string ToString() =>
			type ?? string.Empty;

		public static bool operator ==(IOPowerSourceTransportType left, IOPowerSourceTransportType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceTransportType left, IOPowerSourceTransportType right) =>
			!(left == right);
	}
}

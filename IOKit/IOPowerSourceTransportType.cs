using System;

namespace IOKit
{
	public readonly struct IOPowerSourceTransportType : IEquatable<IOPowerSourceTransportType>
	{
		private readonly string type;

		public static IOPowerSourceTransportType Serial { get; } = new IOPowerSourceTransportType("Serial");

		public static IOPowerSourceTransportType Usb { get; } = new IOPowerSourceTransportType("USB");

		public static IOPowerSourceTransportType Ethernet { get; } = new IOPowerSourceTransportType("Ethernet");

		public static IOPowerSourceTransportType Internal { get; } = new IOPowerSourceTransportType("Internal");

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

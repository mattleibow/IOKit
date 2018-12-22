using System;

namespace IOKit
{
	public readonly struct IOPowerSourceProvidingType : IEquatable<IOPowerSourceProvidingType>
	{
		private const string kIOPMUPSPowerKey = "UPS Power";
		private const string kIOPMBatteryPowerKey = "Battery Power";
		private const string kIOPMACPowerKey = "AC Power";

		private readonly string type;

		public static IOPowerSourceProvidingType UPS { get; } = new IOPowerSourceProvidingType(kIOPMUPSPowerKey);

		public static IOPowerSourceProvidingType Battery { get; } = new IOPowerSourceProvidingType(kIOPMBatteryPowerKey);

		public static IOPowerSourceProvidingType AC { get; } = new IOPowerSourceProvidingType(kIOPMACPowerKey);

		IOPowerSourceProvidingType(string type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (type.Length == 0)
				throw new ArgumentException(nameof(type));

			this.type = type;
		}

		public static IOPowerSourceProvidingType Create(string type) =>
		   new IOPowerSourceProvidingType(type);

		public bool Equals(IOPowerSourceProvidingType other) =>
			Equals(other.type);

		internal bool Equals(string other) =>
			string.Equals(type, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceProvidingType && Equals((IOPowerSourceProvidingType)obj);

		public override int GetHashCode() =>
			type == null ? 0 : type.GetHashCode();

		public override string ToString() =>
			type ?? string.Empty;

		public static bool operator ==(IOPowerSourceProvidingType left, IOPowerSourceProvidingType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceProvidingType left, IOPowerSourceProvidingType right) =>
			!(left == right);
	}
}

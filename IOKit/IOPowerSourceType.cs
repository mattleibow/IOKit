using System;

namespace IOKit
{
	public readonly struct IOPowerSourceType : IEquatable<IOPowerSourceType>
	{
		private readonly string type;

		public static IOPowerSourceType UPS { get; } = new IOPowerSourceType("UPS");

		public static IOPowerSourceType InternalBattery { get; } = new IOPowerSourceType("InternalBattery");

		IOPowerSourceType(string type)
		{
			if (type == null)
				throw new ArgumentNullException(nameof(type));

			if (type.Length == 0)
				throw new ArgumentException(nameof(type));

			this.type = type;
		}

		public static IOPowerSourceType Create(string type) =>
			new IOPowerSourceType(type);

		public bool Equals(IOPowerSourceType other) =>
			Equals(other.type);

		internal bool Equals(string other) =>
			string.Equals(type, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceType && Equals((IOPowerSourceType)obj);

		public override int GetHashCode() =>
			type == null ? 0 : type.GetHashCode();

		public override string ToString() =>
			type ?? string.Empty;

		public static bool operator ==(IOPowerSourceType left, IOPowerSourceType right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceType left, IOPowerSourceType right) =>
			!(left == right);
	}
}

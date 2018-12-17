using System;

namespace IOKit
{
	public readonly struct IOPowerSourceBatteryHealth : IEquatable<IOPowerSourceBatteryHealth>
	{
		private readonly string health;

		public static IOPowerSourceBatteryHealth Poor { get; } = new IOPowerSourceBatteryHealth("Poor");

		public static IOPowerSourceBatteryHealth Fair { get; } = new IOPowerSourceBatteryHealth("Fair");

		public static IOPowerSourceBatteryHealth Good { get; } = new IOPowerSourceBatteryHealth("Good");

		IOPowerSourceBatteryHealth(string health)
		{
			if (health == null)
				throw new ArgumentNullException(nameof(health));

			if (health.Length == 0)
				throw new ArgumentException(nameof(health));

			this.health = health;
		}

		public static IOPowerSourceBatteryHealth Create(string health) =>
			new IOPowerSourceBatteryHealth(health);

		public bool Equals(IOPowerSourceBatteryHealth other) =>
			Equals(other.health);

		internal bool Equals(string other) =>
			string.Equals(health, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceBatteryHealth && Equals((IOPowerSourceBatteryHealth)obj);

		public override int GetHashCode() =>
			health == null ? 0 : health.GetHashCode();

		public override string ToString() =>
			health ?? string.Empty;

		public static bool operator ==(IOPowerSourceBatteryHealth left, IOPowerSourceBatteryHealth right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceBatteryHealth left, IOPowerSourceBatteryHealth right) =>
			!(left == right);
	}
}

using System;

namespace IOKit
{
	public readonly struct IOPowerSourceBatteryHealthCondition : IEquatable<IOPowerSourceBatteryHealthCondition>
	{
		private const string kIOPSCheckBatteryValue = "Check Battery";
		private const string kIOPSPermanentFailureValue = "Permanent Battery Failure";

		private readonly string value;

		public static IOPowerSourceBatteryHealthCondition CheckBattery { get; } = new IOPowerSourceBatteryHealthCondition(kIOPSCheckBatteryValue);

		public static IOPowerSourceBatteryHealthCondition PermanentBatteryFailure { get; } = new IOPowerSourceBatteryHealthCondition(kIOPSPermanentFailureValue);

		IOPowerSourceBatteryHealthCondition(string value) =>
			this.value = value ?? throw new ArgumentNullException(nameof(value));

		public static IOPowerSourceBatteryHealthCondition? Create(string value) =>
			value == null ? (IOPowerSourceBatteryHealthCondition?)null : new IOPowerSourceBatteryHealthCondition(value);

		public bool Equals(IOPowerSourceBatteryHealthCondition other) =>
			Equals(other.value);

		internal bool Equals(string other) =>
			string.Equals(value, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceBatteryHealthCondition && Equals((IOPowerSourceBatteryHealthCondition)obj);

		public override int GetHashCode() =>
			value?.GetHashCode() ?? 0;

		public override string ToString() =>
			value ?? string.Empty;

		public static bool operator ==(IOPowerSourceBatteryHealthCondition left, IOPowerSourceBatteryHealthCondition right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceBatteryHealthCondition left, IOPowerSourceBatteryHealthCondition right) =>
			!(left == right);
	}
}

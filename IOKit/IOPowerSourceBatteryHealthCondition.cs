using System;

namespace IOKit
{
	public readonly struct IOPowerSourceBatteryHealthCondition : IEquatable<IOPowerSourceBatteryHealthCondition>
	{
		private readonly string condition;

		public static IOPowerSourceBatteryHealthCondition CheckBattery { get; } = new IOPowerSourceBatteryHealthCondition("Check Battery");

		public static IOPowerSourceBatteryHealthCondition PermanentBatteryFailure { get; } = new IOPowerSourceBatteryHealthCondition("Permanent Battery Failure");

		IOPowerSourceBatteryHealthCondition(string condition)
		{
			if (condition == null)
				throw new ArgumentNullException(nameof(condition));

			if (condition.Length == 0)
				throw new ArgumentException(nameof(condition));

			this.condition = condition;
		}

		public static IOPowerSourceBatteryHealthCondition Create(string condition) =>
			new IOPowerSourceBatteryHealthCondition(condition);

		public bool Equals(IOPowerSourceBatteryHealthCondition other) =>
			Equals(other.condition);

		internal bool Equals(string other) =>
			string.Equals(condition, other, StringComparison.Ordinal);

		public override bool Equals(object obj) =>
			obj is IOPowerSourceBatteryHealthCondition && Equals((IOPowerSourceBatteryHealthCondition)obj);

		public override int GetHashCode() =>
			condition == null ? 0 : condition.GetHashCode();

		public override string ToString() =>
			condition ?? string.Empty;

		public static bool operator ==(IOPowerSourceBatteryHealthCondition left, IOPowerSourceBatteryHealthCondition right) =>
			left.Equals(right);

		public static bool operator !=(IOPowerSourceBatteryHealthCondition left, IOPowerSourceBatteryHealthCondition right) =>
			!(left == right);
	}
}

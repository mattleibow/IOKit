using System.Linq;
using Foundation;
using ObjCRuntime;

namespace IOKit
{
	public class IOPowerSource : DictionaryContainer
	{
		private static readonly NSString kIOPSPowerSourceIDKey = (NSString)"Power Source ID";
		private static readonly NSString kIOPSPowerSourceStateKey = (NSString)"Power Source State";
		private static readonly NSString kIOPSCurrentCapacityKey = (NSString)"Current Capacity";
		private static readonly NSString kIOPSMaxCapacityKey = (NSString)"Max Capacity";
		private static readonly NSString kIOPSDesignCapacityKey = (NSString)"DesignCapacity";
		private static readonly NSString kIOPSNominalCapacityKey = (NSString)"Nominal Capacity";
		private static readonly NSString kIOPSTimeToEmptyKey = (NSString)"Time to Empty";
		private static readonly NSString kIOPSTimeToFullChargeKey = (NSString)"Time to Full Charge";
		private static readonly NSString kIOPSIsChargingKey = (NSString)"Is Charging";
		private static readonly NSString kIOPSInternalFailureKey = (NSString)"Internal Failure";
		private static readonly NSString kIOPSIsPresentKey = (NSString)"Is Present";
		private static readonly NSString kIOPSVoltageKey = (NSString)"Voltage";
		private static readonly NSString kIOPSCurrentKey = (NSString)"Current";
		private static readonly NSString kIOPSTemperatureKey = (NSString)"Temperature";
		private static readonly NSString kIOPSNameKey = (NSString)"Name";
		private static readonly NSString kIOPSTypeKey = (NSString)"Type";
		private static readonly NSString kIOPSTransportTypeKey = (NSString)"Transport Type";
		private static readonly NSString kIOPSVendorIDKey = (NSString)"Vendor ID";
		private static readonly NSString kIOPSProductIDKey = (NSString)"Product ID";
		private static readonly NSString kIOPSVendorDataKey = (NSString)"Vendor Specific Data";
		private static readonly NSString kIOPSBatteryHealthKey = (NSString)"BatteryHealth";
		private static readonly NSString kIOPSBatteryHealthConditionKey = (NSString)"BatteryHealthCondition";
		private static readonly NSString kIOPSBatteryFailureModesKey = (NSString)"BatteryFailureModes";
		private static readonly NSString kIOPSHealthConfidenceKey = (NSString)"HealthConfidence";
		private static readonly NSString kIOPSMaxErrKey = (NSString)"MaxErr";
		private static readonly NSString kIOPSIsChargedKey = (NSString)"Is Charged";
		private static readonly NSString kIOPSIsFinishingChargeKey = (NSString)"Is Finishing Charge";
		private static readonly NSString kIOPSHardwareSerialNumberKey = (NSString)"Hardware Serial Number";

		internal IOPowerSource(NSDictionary dictionary)
			: base(dictionary)
		{
		}

		public int? PowerSourceId => GetInt32Value(kIOPSPowerSourceIDKey);

		public IOPowerSourceState? State => IOPowerSourceState.Create(GetStringValue(kIOPSPowerSourceStateKey));

		public int? CurrentCapacity => GetInt32Value(kIOPSCurrentCapacityKey);

		public int? MaxCapacity => GetInt32Value(kIOPSMaxCapacityKey);

		public int? DesignCapacity => GetInt32Value(kIOPSDesignCapacityKey);

		public int? NominalCapacity => GetInt32Value(kIOPSNominalCapacityKey);

		public int? TimeToEmpty => GetInt32Value(kIOPSTimeToEmptyKey);

		public int? TimeToFullCharge => GetInt32Value(kIOPSTimeToFullChargeKey);

		public bool? IsCharging => GetBoolValue(kIOPSIsChargingKey);

		public bool? HasInternalFailure => GetBoolValue(kIOPSInternalFailureKey);

		public bool? IsPresent => GetBoolValue(kIOPSIsPresentKey);

		public int? Voltage => GetInt32Value(kIOPSVoltageKey);

		public int? Current => GetInt32Value(kIOPSCurrentKey);

		public int? Temperature => GetInt32Value(kIOPSTemperatureKey);

		public string Name => GetStringValue(kIOPSNameKey);

		public IOPowerSourceType? Type => IOPowerSourceType.Create(GetStringValue(kIOPSTypeKey));

		public IOPowerSourceTransportType? TransportType => IOPowerSourceTransportType.Create(GetStringValue(kIOPSTransportTypeKey));

		public int? VendorId => GetInt32Value(kIOPSVendorIDKey);

		public int? ProductId => GetInt32Value(kIOPSProductIDKey);

		public NSDictionary VendorData => GetNSDictionary(kIOPSVendorDataKey);

		public IOPowerSourceBatteryHealth? BatteryHealth => IOPowerSourceBatteryHealth.Create(GetStringValue(kIOPSBatteryHealthKey));

		public IOPowerSourceBatteryHealthCondition? BatteryHealthCondition => IOPowerSourceBatteryHealthCondition.Create(GetStringValue(kIOPSBatteryHealthConditionKey));

		public string[] BatteryFailureModes => GetArray<NSString>(kIOPSBatteryHealthConditionKey)?.Cast<string>()?.ToArray();

		[Deprecated(PlatformName.MacOSX, 10, 6)]
		public string HealthConfidence => GetStringValue(kIOPSHealthConfidenceKey);

		public int? PercentageError => GetInt32Value(kIOPSMaxErrKey);

		public bool? IsCharged => GetBoolValue(kIOPSIsChargedKey);

		public bool? IsFinishingCharge => GetBoolValue(kIOPSIsFinishingChargeKey);

		public string HardwareSerialNumber => GetStringValue(kIOPSHardwareSerialNumberKey);
	}
}

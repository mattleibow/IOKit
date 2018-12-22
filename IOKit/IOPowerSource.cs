using System;
using CoreFoundation;
using ObjCRuntime;

namespace IOKit
{
	public class IOPowerSource
	{
		private const string kIOPSPowerSourceIDKey = "Power Source ID";
		private const string kIOPSPowerSourceStateKey = "Power Source State";
		private const string kIOPSCurrentCapacityKey = "Current Capacity";
		private const string kIOPSMaxCapacityKey = "Max Capacity";
		private const string kIOPSDesignCapacityKey = "DesignCapacity";
		private const string kIOPSNominalCapacityKey = "Nominal Capacity";
		private const string kIOPSTimeToEmptyKey = "Time to Empty";
		private const string kIOPSTimeToFullChargeKey = "Time to Full Charge";
		private const string kIOPSIsChargingKey = "Is Charging";
		private const string kIOPSInternalFailureKey = "Internal Failure";
		private const string kIOPSIsPresentKey = "Is Present";
		private const string kIOPSVoltageKey = "Voltage";
		private const string kIOPSCurrentKey = "Current";
		private const string kIOPSTemperatureKey = "Temperature";
		private const string kIOPSNameKey = "Name";
		private const string kIOPSTypeKey = "Type";
		private const string kIOPSTransportTypeKey = "Transport Type";
		private const string kIOPSVendorIDKey = "Vendor ID";
		private const string kIOPSProductIDKey = "Product ID";
		private const string kIOPSVendorDataKey = "Vendor Specific Data";
		private const string kIOPSBatteryHealthKey = "BatteryHealth";
		private const string kIOPSBatteryHealthConditionKey = "BatteryHealthCondition";
		private const string kIOPSBatteryFailureModesKey = "BatteryFailureModes";
		private const string kIOPSHealthConfidenceKey = "HealthConfidence";
		private const string kIOPSMaxErrKey = "MaxErr";
		private const string kIOPSIsChargedKey = "Is Charged";
		private const string kIOPSIsFinishingChargeKey = "Is Finishing Charge";
		private const string kIOPSHardwareSerialNumberKey = "Hardware Serial Number";

		private readonly CFDictionary dictionary;

		internal IOPowerSource(CFDictionary dictionary)
		{
			this.dictionary = dictionary;
		}

		public int PowerSourceId => dictionary.GetInt32Value(kIOPSPowerSourceIDKey);

		public IOPowerSourceState State => IOPowerSourceState.Create(dictionary.GetStringValue(kIOPSPowerSourceStateKey));

		public int CurrentCapacity => dictionary.GetInt32Value(kIOPSCurrentCapacityKey);

		public int MaxCapacity => dictionary.GetInt32Value(kIOPSMaxCapacityKey);

		public int DesignCapacity => dictionary.GetInt32Value(kIOPSDesignCapacityKey);

		public int NominalCapacity => dictionary.GetInt32Value(kIOPSNominalCapacityKey);

		public int TimeToEmpty => dictionary.GetInt32Value(kIOPSTimeToEmptyKey);

		public int TimeToFullCharge => dictionary.GetInt32Value(kIOPSTimeToFullChargeKey);

		public bool IsCharging => dictionary.GetBooleanValue(kIOPSIsChargingKey);

		public bool HasInternalFailure => dictionary.GetBooleanValue(kIOPSInternalFailureKey);

		public bool IsPresent => dictionary.GetBooleanValue(kIOPSIsPresentKey);

		public int Voltage => dictionary.GetInt32Value(kIOPSVoltageKey);

		public int Current => dictionary.GetInt32Value(kIOPSCurrentKey);

		public int Temperature => dictionary.GetInt32Value(kIOPSTemperatureKey);

		public string Name => dictionary.GetStringValue(kIOPSNameKey);

		public IOPowerSourceType Type => IOPowerSourceType.Create(dictionary.GetStringValue(kIOPSTypeKey));

		public IOPowerSourceTransportType TransportType => IOPowerSourceTransportType.Create(dictionary.GetStringValue(kIOPSTransportTypeKey));

		public int VendorId => dictionary.GetInt32Value(kIOPSVendorIDKey);

		public int ProductId => dictionary.GetInt32Value(kIOPSProductIDKey);

		public IntPtr VendorData => dictionary[kIOPSVendorDataKey];

		public IOPowerSourceBatteryHealth BatteryHealth => IOPowerSourceBatteryHealth.Create(dictionary.GetStringValue(kIOPSBatteryHealthKey));

		public IOPowerSourceBatteryHealthCondition BatteryHealthCondition => IOPowerSourceBatteryHealthCondition.Create(dictionary.GetStringValue(kIOPSBatteryHealthConditionKey));

		public string[] BatteryFailureModes
		{
			get
			{
				var modesHandle = dictionary[kIOPSBatteryHealthConditionKey];
				if (modesHandle == default)
					return null;

				using (var array = new CFArray(modesHandle, false))
				{
					var modes = new string[array.Count];
					for (var i = 0; i < array.Count; i++)
					{
						using (var str = new CFString(array[i]))
						{
							modes[i] = str;
						}
					}
					return modes;
				}
			}
		}

		[Deprecated(PlatformName.MacOSX, 10, 6)]
		public string HealthConfidence => dictionary.GetStringValue(kIOPSHealthConfidenceKey);

		public int PercentageError => dictionary.GetInt32Value(kIOPSMaxErrKey);

		public bool IsCharged => dictionary.GetBooleanValue(kIOPSIsChargedKey);

		public bool IsFinishingCharge => dictionary.GetBooleanValue(kIOPSIsFinishingChargeKey);

		public string HardwareSerialNumber => dictionary.GetStringValue(kIOPSHardwareSerialNumberKey);
	}
}

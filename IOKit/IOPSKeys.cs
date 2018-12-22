namespace IOKit
{
	internal static class IOPSKeys
	{
		// Power Source Commands (UPS)
		public const string kIOPSCommandDelayedRemovePowerKey = "Delayed Remove Power";
		public const string kIOPSCommandEnableAudibleAlarmKey = "Enable Audible Alarm";
		public const string kIOPSCommandStartupDelayKey = "Startup Delay";
		public const string kIOPSCommandSetCurrentLimitKey = "Set Current Limit";
		public const string kIOPSCommandSetRequiredVoltageKey = "Set Required Voltage";
		public const string kIOPSCommandSendCurrentStateOfCharge = "Send Current State of Charge";
		public const string kIOPSCommandSendCurrentTemperature = "Send Current Temperature";

		// Battery Failure Modes
		public const string kIOPSFailureExternalInput = "Externally Indicated Failure";
		public const string kIOPSFailureSafetyOverVoltage = "Safety Over-Voltage";
		public const string kIOPSFailureChargeOverTemp = "Charge Over-Temperature";
		public const string kIOPSFailureDischargeOverTemp = "Discharge Over-Temperature";
		public const string kIOPSFailureCellImbalance = "Cell Imbalance";
		public const string kIOPSFailureChargeFET = "Charge FET";
		public const string kIOPSFailureDischargeFET = "Discharge FET";
		public const string kIOPSFailureDataFlushFault = "Data Flush Fault";
		public const string kIOPSFailurePermanentAFEComms = "Permanent AFE Comms";
		public const string kIOPSFailurePeriodicAFEComms = "Periodic AFE Comms";
		public const string kIOPSFailureChargeOverCurrent = "Charge Over-Current";
		public const string kIOPSFailureDischargeOverCurrent = "Discharge Over-Current";
		public const string kIOPSFailureOpenThermistor = "Open Thermistor";
		public const string kIOPSFailureFuseBlown = "Fuse Blown";
	}
}

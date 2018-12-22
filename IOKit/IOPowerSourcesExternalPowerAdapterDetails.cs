using CoreFoundation;

namespace IOKit
{
	public class IOPowerSourcesExternalPowerAdapterDetails
	{
		public const string kIOPSPowerAdapterIDKey = "AdapterID";
		public const string kIOPSPowerAdapterWattsKey = "Watts";
		public const string kIOPSPowerAdapterRevisionKey = "AdapterRevision";
		public const string kIOPSPowerAdapterSerialNumberKey = "SerialNumber";
		public const string kIOPSPowerAdapterFamilyKey = "FamilyCode";
		public const string kIOPSPowerAdapterCurrentKey = "Current";
		public const string kIOPSPowerAdapterSourceKey = "Source";

		private readonly CFDictionary dictionary;

		internal IOPowerSourcesExternalPowerAdapterDetails(CFDictionary dictionary)
		{
			this.dictionary = dictionary;
		}

		public int PowerAdapterId => dictionary.GetInt32Value(kIOPSPowerAdapterIDKey);

		public int Watts => dictionary.GetInt32Value(kIOPSPowerAdapterWattsKey);

		public int AdapterRevision => dictionary.GetInt32Value(kIOPSPowerAdapterRevisionKey);

		public int SerialNumber => dictionary.GetInt32Value(kIOPSPowerAdapterSerialNumberKey);

		public int Family => dictionary.GetInt32Value(kIOPSPowerAdapterFamilyKey);

		public int Current => dictionary.GetInt32Value(kIOPSPowerAdapterCurrentKey);

		public int Source => dictionary.GetInt32Value(kIOPSPowerAdapterSourceKey);
	}
}

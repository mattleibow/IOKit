using Foundation;

namespace IOKit
{
	public class IOPowerSourcesExternalPowerAdapterDetails : DictionaryContainer
	{
		private static readonly NSString kIOPSPowerAdapterIDKey = (NSString)"AdapterID";
		private static readonly NSString kIOPSPowerAdapterWattsKey = (NSString)"Watts";
		private static readonly NSString kIOPSPowerAdapterRevisionKey = (NSString)"AdapterRevision";
		private static readonly NSString kIOPSPowerAdapterSerialNumberKey = (NSString)"SerialNumber";
		private static readonly NSString kIOPSPowerAdapterFamilyKey = (NSString)"FamilyCode";
		private static readonly NSString kIOPSPowerAdapterCurrentKey = (NSString)"Current";
		private static readonly NSString kIOPSPowerAdapterSourceKey = (NSString)"Source";

		internal IOPowerSourcesExternalPowerAdapterDetails(NSDictionary dictionary)
			: base(dictionary)
		{
		}

		public int? PowerAdapterId => GetInt32Value(kIOPSPowerAdapterIDKey);

		public int? Watts => GetInt32Value(kIOPSPowerAdapterWattsKey);

		public int? AdapterRevision => GetInt32Value(kIOPSPowerAdapterRevisionKey);

		public int? SerialNumber => GetInt32Value(kIOPSPowerAdapterSerialNumberKey);

		public int? Family => GetInt32Value(kIOPSPowerAdapterFamilyKey);

		public int? Current => GetInt32Value(kIOPSPowerAdapterCurrentKey);

		public int? Source => GetInt32Value(kIOPSPowerAdapterSourceKey);
	}
}

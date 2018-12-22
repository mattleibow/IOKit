using System.Collections.Generic;
using IOKit;

namespace IOKitSample
{
	internal class AdaptersPowerSourceItem : PowerSourceItem
	{
		private readonly IOPowerSourcesExternalPowerAdapterDetails details;

		public AdaptersPowerSourceItem(IOPowerSourcesExternalPowerAdapterDetails adapterDetails)
			: base(adapterDetails.SerialNumber.ToString())
		{
			details = adapterDetails;
		}

		public override IEnumerable<(string Name, string Value)> GetDetails()
		{
			yield return ("Static Properties", "");
			foreach (var prop in GetStaticProperties(typeof(IOPowerSourcesExternalPowerAdapterDetails)))
				yield return prop;

			yield return ("", "");

			yield return ("Instance Properties", "");
			foreach (var prop in GetInstanceProperties(details))
				yield return prop;
		}
	}
}

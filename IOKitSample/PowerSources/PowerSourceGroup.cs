using System.Collections.Generic;
using System.Linq;
using IOKit;

namespace IOKitSample
{
	internal class PowerSourceGroup : PowerSourceItem
	{
		public PowerSourceGroup(IOPowerSourcesInfo powerSourcesInfo)
			: base("System")
		{
			if (powerSourcesInfo != null)
			{
				Items = new List<PowerSourceItem>
				{
					new SystemPowerSourceItem(powerSourcesInfo)
				};
			}
		}

		public PowerSourceGroup(IOPowerSourcesExternalPowerAdapterDetails adapterDetails)
			: base("External Adapters")
		{
			if (adapterDetails != null)
			{
				Items = new List<PowerSourceItem>
				{
					new AdaptersPowerSourceItem(adapterDetails)
				};
			}
		}

		public PowerSourceGroup(IEnumerable<IOPowerSource> powerSources)
			: base("Sources")
		{
			Items = new List<PowerSourceItem>(powerSources.Select(x => new SpecificPowerSourceItem(x)));
		}

		public List<PowerSourceItem> Items { get; } = new List<PowerSourceItem>();
	}
}

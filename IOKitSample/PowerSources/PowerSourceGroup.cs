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
			Items = new List<PowerSourceItem>
			{
				new SystemPowerSourceItem (powerSourcesInfo)
			};
		}

		public PowerSourceGroup(IEnumerable<IOPowerSource> powerSources)
			: base("Sources")
		{
			Items = new List<PowerSourceItem>(powerSources.Select(x => new SpecificPowerSourceItem(x)));
		}

		public List<PowerSourceItem> Items { get; } = new List<PowerSourceItem>();
	}
}

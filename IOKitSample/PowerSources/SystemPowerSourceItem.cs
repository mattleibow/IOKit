using System.Collections.Generic;
using IOKit;

namespace IOKitSample
{
	internal class SystemPowerSourceItem : PowerSourceItem
	{
		private readonly IOPowerSourcesInfo info;

		public SystemPowerSourceItem(IOPowerSourcesInfo powerSourcesInfo)
			: base(powerSourcesInfo.ProvidingPowerSourceType.ToString())
		{
			info = powerSourcesInfo;
		}

		public override IEnumerable<(string Name, string Value)> GetDetails()
		{
			yield return ("Static Properties", "");
			foreach (var prop in GetStaticProperties(typeof(IOPowerSources)))
				yield return prop;

			yield return ("", "");

			yield return ("Instance Properties", "");
			foreach (var prop in GetInstanceProperties(info))
				yield return prop;
		}
	}
}

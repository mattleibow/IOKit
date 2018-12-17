using System.Collections.Generic;
using IOKit;

namespace IOKitSample
{
	internal class SpecificPowerSourceItem : PowerSourceItem
	{
		private readonly IOPowerSource source;

		public SpecificPowerSourceItem(IOPowerSource powerSource)
			: base(powerSource.Name)
		{
			source = powerSource;
		}

		public override IEnumerable<(string Name, string Value)> GetDetails()
		{
			yield return ("Static Properties", "");
			foreach (var prop in GetStaticProperties(typeof(IOPowerSource)))
				yield return prop;

			yield return ("", "");

			yield return ("Instance Properties", "");
			foreach (var prop in GetInstanceProperties(source))
				yield return prop;
		}
	}
}

using ObjCRuntime;

namespace IOKit
{
	[Introduced(PlatformName.MacOSX, 10, 6)]
	public enum IOPowerSourceLowBatteryWarningLevel
	{
		None = 1,
		Early = 2,
		Final = 3
	}
}

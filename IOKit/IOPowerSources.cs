using System;
using System.Runtime.InteropServices;
using CoreFoundation;
using ObjCRuntime;
using CFArrayRef = System.IntPtr;
using CFDictionaryRef = System.IntPtr;
using CFStringRef = System.IntPtr;
using CFTimeInterval = System.Double;
using CFTypeRef = System.IntPtr;
using CFRunLoopSourceRef = System.IntPtr;

namespace IOKit
{
	public delegate void IOPowerSourceCallback(IntPtr context);

	[Introduced(PlatformName.MacOSX, 10, 2)]
	public static class IOPowerSources
	{
		public const CFTimeInterval TimeRemainingUnknown = -1.0;
		public const CFTimeInterval TimeRemainingUnlimited = -2.0;

		[Introduced(PlatformName.MacOSX, 10, 6)]
		public static IOPowerSourceLowBatteryWarningLevel BatteryWarningLevel => IOPSGetBatteryWarningLevel();

		[Introduced(PlatformName.MacOSX, 10, 7)]
		public static CFTimeInterval TimeRemainingEstimate => IOPSGetTimeRemainingEstimate();

		[Introduced(PlatformName.MacOSX, 10, 2)]
		public static IOPowerSourcesInfo GetPowerSourcesInfo()
		{
			var blob = IOPSCopyPowerSourcesInfo();

			if (blob == default)
				throw new IOKitException();

			return new IOPowerSourcesInfo(blob, true);
		}

		[Introduced(PlatformName.MacOSX, 10, 2)]
		public static CFRunLoopSource CreatePowerSourceNotification(IOPowerSourceCallback callback) =>
			CreatePowerSourceNotification(callback, IntPtr.Zero);

		[Introduced(PlatformName.MacOSX, 10, 2)]
		public static CFRunLoopSource CreatePowerSourceNotification(IOPowerSourceCallback callback, IntPtr context)
		{
			var sourceRef = IOPSNotificationCreateRunLoopSource(callback, context);

			if (sourceRef == default)
				return null;

			return new CFRunLoopSource(sourceRef, true);
		}

		[Introduced(PlatformName.MacOSX, 10, 9)]
		public static CFRunLoopSource CreateLimitedPowerSourceNotification(IOPowerSourceCallback callback) =>
			CreateLimitedPowerSourceNotification(callback, IntPtr.Zero);

		[Introduced(PlatformName.MacOSX, 10, 9)]
		public static CFRunLoopSource CreateLimitedPowerSourceNotification(IOPowerSourceCallback callback, IntPtr context)
		{
			var sourceRef = IOPSCreateLimitedPowerNotification(callback, context);

			if (sourceRef == default)
				return null;

			return new CFRunLoopSource(sourceRef, true);
		}

		[Introduced(PlatformName.MacOSX, 10, 6)]
		public static IOPowerSourcesExternalPowerAdapterDetails GetExternalPowerAdapterDetails()
		{
			var details = IOPSCopyExternalPowerAdapterDetails();

			if (details == default)
				return null;

			return new IOPowerSourcesExternalPowerAdapterDetails(new CFDictionary(details, true));
		}

		private const string IOKitLibrary = "/System/Library/Frameworks/IOKit.framework/IOKit";

		[DllImport(IOKitLibrary)]
		internal static extern IOPowerSourceLowBatteryWarningLevel IOPSGetBatteryWarningLevel();
		[DllImport(IOKitLibrary)]
		internal static extern CFTimeInterval IOPSGetTimeRemainingEstimate();
		[DllImport(IOKitLibrary)]
		internal static extern CFTypeRef IOPSCopyPowerSourcesInfo();
		[DllImport(IOKitLibrary)]
		internal static extern CFArrayRef IOPSCopyPowerSourcesList(CFTypeRef blob);
		[DllImport(IOKitLibrary)]
		internal static extern CFDictionaryRef IOPSGetPowerSourceDescription(CFTypeRef blob, CFTypeRef ps);
		[DllImport(IOKitLibrary)]
		internal static extern CFStringRef IOPSGetProvidingPowerSourceType(CFTypeRef snapshot);
		[DllImport(IOKitLibrary)]
		internal static extern CFRunLoopSourceRef IOPSNotificationCreateRunLoopSource(IOPowerSourceCallback callback, IntPtr context);
		[DllImport(IOKitLibrary)]
		internal static extern CFRunLoopSourceRef IOPSCreateLimitedPowerNotification(IOPowerSourceCallback callback, IntPtr context);
		[DllImport(IOKitLibrary)]
		internal static extern CFDictionaryRef IOPSCopyExternalPowerAdapterDetails();
	}
}

using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using CFArrayRef = System.IntPtr;
using CFDictionaryRef = System.IntPtr;
using CFStringRef = System.IntPtr;
using CFTimeInterval = System.Double;
using CFTypeRef = System.IntPtr;

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

		///*! @function   IOPSNotificationCreateRunLoopSource
		// *  
		// *  @abstract   Returns a CFRunLoopSourceRef that notifies the caller when power source
		// *              information changes.
		// *
		// *  @discussion Returns a CFRunLoopSourceRef for scheduling with your CFRunLoop. 
		// *              If your project does not use a CFRunLoop, you can alternatively
		// *              receive notifications via mach port, dispatch, or signal, via <code>notify.h</code>
		// *              using the name <code>@link kIOPSTimeRemainingNotificationKey @/link</code>.
		// *
		// *              IOKit delivers this notification when percent remaining or time remaining changes.
		// *              Thus it fires fairly frequently while discharging or charging the battery; 
		// *              please consider using:
		// *              <code>@link IOPSCreateLimitedPowerNotification @/link</code> if you only require
		// *              notifications when the power source type changes from limited to unlimited.
		// *
		// *  @param      callback A function to be called whenever any power source is added, removed, or changes.
		// *
		// *  @param      context Any user-defined pointer, passed to the IOPowerSource callback.
		// *
		// *  @result     Returns NULL if an error was encountered, otherwise a CFRunLoopSource. Caller must
		// *              release the CFRunLoopSource.
		// */
		//CFRunLoopSourceRef IOPSNotificationCreateRunLoopSource(IOPowerSourceCallbackType callback, void *context);

		///*! @function   IOPSCreateLimitedPowerNotification
		// *
		// *  @abstract   Returns a CFRunLoopSourceRef that notifies the caller when power source
		// *              changes from an unlimited power source (like attached to wall, car, or airplane power), to a limited
		// *              power source (like a battery or UPS).
		// *
		// *  @discussion Returns a CFRunLoopSourceRef for scheduling with your CFRunLoop.
		// *              If your project does not use a CFRunLoop, you can alternatively
		// *              receive this notification via <code>notify.h</code>
		// *              using the name <code>@link kIOPSNotifyPowerSource @/link</code>
		// *
		// *  @param      callback A function to be called whenever the power source changes from AC to DC..
		// *
		// *  @param      context Any user-defined pointer, passed to the IOPowerSource callback.
		// *
		// *  @result     Returns NULL if an error was encountered, otherwise a CFRunLoopSource. Caller must
		// *              release the CFRunLoopSource.
		// */
		//CFRunLoopSourceRef IOPSCreateLimitedPowerNotification(IOPowerSourceCallbackType callback, void *context) __OSX_AVAILABLE_STARTING(__MAC_10_9, __IPHONE_7_0);

		///*! @function   IOPSCopyExternalPowerAdapterDetails
		// *
		// *  @abstract   Returns a CFDictionary that describes the attached (AC) external
		// *              power adapter (if any external power adapter is attached.
		// *
		// *  @discussion Use the kIOPSPowerAdapter... keys described in IOPSKeys.h
		// *              to interpret the returned CFDictionary.
		// *
		// *  @result     Returns a CFDictionary on success. Caller must release the returned
		// *              dictionary. If no adapter is attached, or if there's an error,  returns NULL.
		// */
		//CFDictionaryRef IOPSCopyExternalPowerAdapterDetails(void);

		private const string IOKitLibrary = "/System/Library/Frameworks/IOKit.framework/IOKit";

		[DllImport(IOKitLibrary)]
		internal extern static IOPowerSourceLowBatteryWarningLevel IOPSGetBatteryWarningLevel();
		[DllImport(IOKitLibrary)]
		internal extern static CFTimeInterval IOPSGetTimeRemainingEstimate();
		[DllImport(IOKitLibrary)]
		internal extern static CFTypeRef IOPSCopyPowerSourcesInfo();
		[DllImport(IOKitLibrary)]
		internal static extern CFArrayRef IOPSCopyPowerSourcesList(CFTypeRef blob);
		[DllImport(IOKitLibrary)]
		internal static extern CFDictionaryRef IOPSGetPowerSourceDescription(CFTypeRef blob, CFTypeRef ps);
		[DllImport(IOKitLibrary)]
		internal static extern CFStringRef IOPSGetProvidingPowerSourceType(CFTypeRef snapshot);
	}
}

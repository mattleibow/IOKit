using System;
using System.Collections.Generic;
using System.Linq;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using CFTypeRef = System.IntPtr;

namespace IOKit
{
	[Introduced(PlatformName.MacOSX, 10, 2)]
	public class IOPowerSourcesInfo : INativeObject, IDisposable
	{
		private IOPowerSource[] sources;

		internal IOPowerSourcesInfo(CFTypeRef handle)
			: this(handle, false)
		{
		}

		internal IOPowerSourcesInfo(CFTypeRef handle, bool owns)
		{
			if (handle == default)
				throw new ArgumentNullException(nameof(handle));

			Handle = handle;

			if (!owns)
				CFBase.CFRetain(handle);
		}

		~IOPowerSourcesInfo()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (Handle != default)
			{
				CFBase.CFRelease(Handle);
				Handle = default;
			}
		}

		public CFTypeRef Handle { get; private set; }

		public IOPowerSource[] PowerSources => sources ?? (sources = GetPowerSources().ToArray());

		public IOPowerSourceProvidingType ProvidingPowerSourceType
		{
			get
			{
				var strRef = IOPowerSources.IOPSGetProvidingPowerSourceType(Handle);
				using (var str = new CFString(strRef))
				{
					return IOPowerSourceProvidingType.Create(str).Value;
				}
			}
		}

		private IEnumerable<IOPowerSource> GetPowerSources()
		{
			var sourcesRef = IOPowerSources.IOPSCopyPowerSourcesList(Handle);
			if (sourcesRef == default)
				throw new IOKitException();

			var sourcesArray = NSArray.ArrayFromHandle<NSObject>(sourcesRef);
			foreach (var sourceRef in sourcesArray)
			{
				var dicRef = IOPowerSources.IOPSGetPowerSourceDescription(Handle, sourceRef.Handle);
				if (dicRef == default)
					throw new IOKitException();

				yield return new IOPowerSource(Runtime.GetNSObject<NSDictionary>(dicRef, false));
			}
		}
	}
}

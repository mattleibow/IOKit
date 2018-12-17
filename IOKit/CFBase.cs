using System.Runtime.InteropServices;
using ObjCRuntime;
using CFTypeRef = System.IntPtr;

namespace CoreFoundation
{
	internal static class CFBase
	{
		[DllImport(Constants.CoreFoundationLibrary)]
		public extern static void CFRelease(CFTypeRef obj);
		[DllImport(Constants.CoreFoundationLibrary)]
		public extern static CFTypeRef CFRetain(CFTypeRef obj);
	}
}

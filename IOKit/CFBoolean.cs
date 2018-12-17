using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace CoreFoundation
{
	internal static class CFBoolean
	{
		public static bool GetValue(IntPtr boolean) => CFBooleanGetValue(boolean);

		[DllImport(Constants.CoreFoundationLibrary)]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool CFBooleanGetValue(IntPtr boolean);
	}
}

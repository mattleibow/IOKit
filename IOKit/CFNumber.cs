using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using CFNumberRef = System.IntPtr;

namespace CoreFoundation
{
	internal static class CFNumberType
	{
		// Fixed-width types
		public const int SInt8 = 1;
		public const int SInt16 = 2;
		public const int SInt32 = 3;
		public const int SInt64 = 4;
		public const int Float32 = 5;
		public const int Float64 = 6; // 64-bit IEEE 754

		// Basic C types
		public const int Char = 7;
		public const int Short = 8;
		public const int Int = 9;
		public const int Long = 10;
		public const int LongLong = 11;
		public const int Float = 12;
		public const int Double = 13;

		// Other
		public const int CFIndex = 14;
		public const int NSInteger = 15;
		public const int CGFloat = 16;
		public const int Max = 16;
	}

	internal static class CFNumber
	{
		public static bool AsInt32(CFNumberRef number, out int value) =>
			CFNumberGetValue(number, CFNumberType.SInt32, out value);

		public static bool AsInt64(CFNumberRef number, out long value) =>
			CFNumberGetValue(number, CFNumberType.SInt64, out value);

		[DllImport(Constants.CoreFoundationLibrary)]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool CFNumberGetValue(CFNumberRef number, nint theType, out int value);
		[DllImport(Constants.CoreFoundationLibrary)]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool CFNumberGetValue(CFNumberRef number, nint theType, out long value);
	}
}

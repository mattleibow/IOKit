using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ObjCRuntime;
using CFArrayRef = System.IntPtr;
using CFIndex = System.nint;

namespace CoreFoundation
{
	internal class CFArray : INativeObject, IDisposable, IReadOnlyList<IntPtr>
	{
		public CFArray(CFArrayRef handle)
			: this(handle, false)
		{
		}

		public CFArray(CFArrayRef handle, bool owns)
		{
			if (handle == default)
				throw new ArgumentNullException(nameof(handle));

			Handle = handle;

			if (!owns)
				CFBase.CFRetain(handle);
		}

		~CFArray()
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

		public CFArrayRef Handle { get; private set; }

		public CFIndex Count => CFArrayGetCount(Handle);

		public IntPtr this[nint index] => CFArrayGetValueAtIndex(Handle, index);

		public IEnumerator<IntPtr> GetEnumerator()
		{
			var count = Count;
			for (int i = 0; i < count; i++)
			{
				yield return this[i];
			}
		}

		int IReadOnlyCollection<IntPtr>.Count => (int)Count;

		IntPtr IReadOnlyList<IntPtr>.this[int index] => this[index];

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static IntPtr CFArrayGetValueAtIndex(CFArrayRef theArray, CFIndex idx);
		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static CFIndex CFArrayGetCount(CFArrayRef theArray);
	}
}

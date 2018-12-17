using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ObjCRuntime;
using CFDictionaryRef = System.IntPtr;
using CFIndex = System.nint;

namespace CoreFoundation
{
	internal class CFDictionary : INativeObject, IDisposable, IReadOnlyDictionary<IntPtr, IntPtr>
	{
		public CFDictionary(CFDictionaryRef handle)
			: this(handle, false)
		{
		}

		public CFDictionary(CFDictionaryRef handle, bool owns)
		{
			if (handle == default)
				throw new ArgumentNullException(nameof(handle));

			Handle = handle;

			if (!owns)
				CFBase.CFRetain(handle);
		}

		~CFDictionary()
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

		public CFDictionaryRef Handle { get; private set; }

		public CFIndex Count => CFDictionaryGetCount(Handle);

		public IEnumerable<IntPtr> Keys
		{
			get
			{
				var count = Count;
				var keys = new IntPtr[count];
				if (count > 0)
					CFDictionaryGetKeysAndValues(Handle, keys, IntPtr.Zero);
				return keys;
			}
		}

		public IEnumerable<IntPtr> Values
		{
			get
			{
				var count = Count;
				var values = new IntPtr[count];
				if (count > 0)
					CFDictionaryGetKeysAndValues(Handle, IntPtr.Zero, values);
				return values;
			}
		}

		public IntPtr this[IntPtr key] => CFDictionaryGetValue(Handle, key);

		public IntPtr this[string key]
		{
			get
			{
				using (var str = new CFString(key))
				{
					return CFDictionaryGetValue(Handle, str.Handle);
				}
			}
		}

		public int GetInt32Value(string key)
		{
			var number = this[key];
			if (number == IntPtr.Zero || !CFNumber.AsInt32(number, out var value))
				throw new KeyNotFoundException($"Key '{key}' not found.");
			return value;
		}

		public long GetInt64Value(string key)
		{
			var number = this[key];
			if (number == IntPtr.Zero || !CFNumber.AsInt64(number, out var value))
				throw new KeyNotFoundException($"Key '{key}' not found.");
			return value;
		}

		public bool GetBooleanValue(string key)
		{
			var value = this[key];
			if (value == IntPtr.Zero)
				throw new KeyNotFoundException($"Key '{key}' not found.");
			return CFBoolean.GetValue(value);
		}

		public string GetStringValue(string key)
		{
			var value = this[key];
			if (value == IntPtr.Zero)
				throw new KeyNotFoundException($"Key '{key}' not found.");
			using (var str = new CFString(value))
			{
				return str;
			}
		}

		public bool ContainsKey(IntPtr key) => CFDictionaryContainsKey(Handle, key);

		public bool ContainsKey(string key)
		{
			using (var str = new CFString(key))
			{
				return CFDictionaryContainsKey(Handle, str.Handle);
			}
		}

		public bool TryGetValue(IntPtr key, out IntPtr value) => CFDictionaryGetValueIfPresent(Handle, key, out value);

		public IEnumerator<KeyValuePair<CFDictionaryRef, CFDictionaryRef>> GetEnumerator()
		{
			var keys = Keys;
			foreach (var key in keys)
			{
				yield return new KeyValuePair<CFDictionaryRef, CFDictionaryRef>(key, this[key]);
			}
		}

		int IReadOnlyCollection<KeyValuePair<CFDictionaryRef, CFDictionaryRef>>.Count => (int)Count;

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static CFIndex CFDictionaryGetCount(CFDictionaryRef theDict);
		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static IntPtr CFDictionaryGetValue(CFDictionaryRef theDict, IntPtr key);
		[DllImport(Constants.CoreFoundationLibrary)]
		[return: MarshalAs(UnmanagedType.I1)]
		private extern static bool CFDictionaryContainsKey(CFDictionaryRef theDict, IntPtr key);
		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static void CFDictionaryGetKeysAndValues(CFDictionaryRef theDict, IntPtr[] keys, IntPtr[] values);
		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static void CFDictionaryGetKeysAndValues(CFDictionaryRef theDict, IntPtr[] keys, IntPtr values);
		[DllImport(Constants.CoreFoundationLibrary)]
		private extern static void CFDictionaryGetKeysAndValues(CFDictionaryRef theDict, IntPtr keys, IntPtr[] values);
		[DllImport(Constants.CoreFoundationLibrary)]
		[return: MarshalAs(UnmanagedType.I1)]
		private extern static bool CFDictionaryGetValueIfPresent(CFDictionaryRef theDict, IntPtr key, out IntPtr value);
	}
}

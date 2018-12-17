using System;
using System.Runtime.Serialization;

namespace IOKit
{
	public class IOKitException : Exception
	{
		public IOKitException()
		{
		}

		public IOKitException(string message)
			: base(message)
		{
		}

		public IOKitException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected IOKitException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}

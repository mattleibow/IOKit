using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Foundation;

namespace IOKitSample
{
	internal abstract class PowerSourceItem : NSObject
	{
		protected PowerSourceItem(string name)
		{
			Name = name;
		}

		public string Name { get; }

		public virtual IEnumerable<(string Name, string Value)> GetDetails() => null;

		protected IEnumerable<(string Name, string Value)> GetStaticProperties(Type type)
		{
			var props = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
			foreach (var prop in props.Where(p => p.CanRead))
			{
				yield return (prop.Name, GetValue(null, prop));
			}
		}

		protected IEnumerable<(string Name, string Value)> GetInstanceProperties(object instance)
		{
			var type = instance.GetType();
			var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
			foreach (var prop in props.Where(p => p.CanRead))
			{
				yield return (Name: prop.Name, GetValue(instance, prop));
			}
		}

		private static string GetValue(object instance, PropertyInfo prop)
		{
			try
			{
				var value = prop.GetValue(instance);
				if (value is string str)
					return str;
				if (value is IEnumerable enumerable)
					return "[" + string.Join(", ", enumerable.Cast<object>()) + "]";
				return value?.ToString() ?? " ";
			}
			catch (Exception ex) when (ex is KeyNotFoundException || ex.InnerException is KeyNotFoundException)
			{
				return " ";
			}
			catch (Exception ex)
			{
				return $"(error: {(ex.InnerException ?? ex).Message})";
			}
		}
	}
}

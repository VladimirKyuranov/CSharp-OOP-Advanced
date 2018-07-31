using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public class Tracker
{
	public static void PrintMethodsByAuthor()
	{
		Type type = typeof(StartUp);
		MethodInfo[] methods = type.GetMethods(BindingFlags.Public |
			BindingFlags.Static | BindingFlags.Instance);

		foreach (var method in methods)
		{
			var attributes = method.GetCustomAttributes<SoftUniAttribute>();

			foreach (var attribute in attributes)
			{
				Console.WriteLine(attribute.Name);
			}
		}
	}
}
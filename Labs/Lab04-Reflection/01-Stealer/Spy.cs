using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
	public string StealFieldInfo(string className, params string[] fields)
	{
		StringBuilder builder = new StringBuilder();

		Type classType = Type.GetType(className);
		FieldInfo[] classFields = classType.GetFields(
			BindingFlags.Instance | BindingFlags.Static |
			BindingFlags.NonPublic | BindingFlags.Public);

		Object classInstance = Activator.CreateInstance(classType, new object[] { });

		builder.AppendLine($"Class under investigation: {className}");

		foreach (var field in classFields.Where(f => fields.Contains(f.Name)))
		{
			builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
		}


		string result = builder.ToString().TrimEnd();
		return result;
	}
}

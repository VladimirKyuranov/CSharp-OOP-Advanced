using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
	public string CollectGettersAndSetters(string className)
	{
		StringBuilder builder = new StringBuilder();

		Type classType = Type.GetType(className);

		MethodInfo[] classMethods = classType.GetMethods(
			BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

		foreach (var getter in classMethods.Where(g => g.Name.StartsWith("get")))
		{
			builder.AppendLine($"{getter.Name} will return {getter.ReturnType}");
		}

		foreach (var setter in classMethods.Where(s => s.Name.StartsWith("set")))
		{
			builder.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
		}

		string result = builder.ToString().TrimEnd();
		return result;
	}

	public string RevealPrivateMethods(string className)
	{
		StringBuilder builder = new StringBuilder();
		Type classType = Type.GetType(className);

		builder.AppendLine($"All Private Methods of Class: {className}")
			.AppendLine($"Base Class: {classType.BaseType.Name}");

		MethodInfo[] classPrivateMethods = classType.GetMethods(
			BindingFlags.NonPublic | BindingFlags.Instance);

		foreach (var method in classPrivateMethods)
		{
			builder.AppendLine(method.Name);
		}

		string result = builder.ToString().TrimEnd();
		return result;
	}

	public string AnalyzeAcessModifiers(string className)
	{
		StringBuilder builder = new StringBuilder();

		Type classType = Type.GetType(className);
		FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

		MethodInfo[] classPublicMethods = classType.GetMethods(
			BindingFlags.Instance | BindingFlags.Public);
		MethodInfo[] classNonPublicMethods = classType.GetMethods(
			BindingFlags.Instance | BindingFlags.NonPublic);

		foreach (var field in classFields)
		{
			builder.AppendLine($"{field.Name} must be private!");
		}

		foreach (var getter in classNonPublicMethods.Where(g => g.Name.StartsWith("get")))
		{
			builder.AppendLine($"{getter.Name} have to be public!");
		}

		foreach (var setter in classPublicMethods.Where(s => s.Name.StartsWith("set")))
		{
			builder.AppendLine($"{setter.Name} have to be private!");
		}

		string result = builder.ToString().TrimEnd();
		return result;
	}

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

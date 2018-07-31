namespace P02_BlackBoxInteger
{
	using System;
	using System.Reflection;

	public class BlackBoxIntegerTests
	{
		public static void Main()
		{
			Type type = typeof(BlackBoxInteger);
			FieldInfo value = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
			var blackBox = Activator.CreateInstance(type, true);

			string input;

			while ((input = Console.ReadLine()) != "END")
			{
				string[] commandArgs = input.Split('_');
				string command = commandArgs[0];
				int number = int.Parse(commandArgs[1]);

				MethodInfo method = type.GetMethod(command, BindingFlags.NonPublic | BindingFlags.Instance);
				method.Invoke(blackBox, new object[] { number });

				Console.WriteLine(value.GetValue(blackBox));
			}
		}
	}
}

using System;
using System.Linq;
using System.Reflection;

class Engine : IRunnable
{
	private ICommandInterpreter commandInterpreter;

	public Engine(ICommandInterpreter commandInterpreter)
	{
		this.commandInterpreter = commandInterpreter;
	}

	public void Run()
	{
		while (true)
		{
			try
			{
				string input = Console.ReadLine();
				string[] dataArgs = input.Split(';');
				string commandName = dataArgs[0];
				string[] data = dataArgs.Skip(1).ToArray();
				IExecutable command = commandInterpreter.InterpretCommand(data, commandName);

				MethodInfo method = typeof(IExecutable).GetMethods().First();

				try
				{
					method.Invoke(command, null);
				}
				catch (TargetInvocationException e)
				{
					throw e.InnerException;
				}
			}
			catch (Exception e)
			{
				//Console.WriteLine(e.Message);
			}
		}
	}
}
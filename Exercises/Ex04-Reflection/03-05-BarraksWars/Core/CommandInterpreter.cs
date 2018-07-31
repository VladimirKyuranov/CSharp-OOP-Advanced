namespace _03BarraksFactory.Core
{
	using System;
	using System.Linq;
	using System.Reflection;
	using _03BarracksFactory.Contracts;
	using _03BarracksFactory.Core.Commands;

	public class CommandInterpreter : ICommandInterpreter
    {
		private IServiceProvider serviceProvider;

		public CommandInterpreter(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public IExecutable InterpretCommand(string[] data, string commandName)
		{
			Assembly assembly = Assembly.GetCallingAssembly();
			Type commandType = assembly.GetTypes().FirstOrDefault(c => c.Name.ToLower() == commandName + "command");

			if (commandType == null)
			{
				throw new ArgumentException("Invalid Command!");
			}

			if (typeof(IExecutable).IsAssignableFrom(commandType) == false)
			{
				throw new ArgumentException($"{commandName} Is Not A Command");
			}

			FieldInfo[] fieldsToInject = commandType
				.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.Where(f => f.CustomAttributes.Any(ca => ca.AttributeType == typeof(InjectAttribute)))
				.ToArray();

			object[] injectArgs = fieldsToInject
				.Select(f => this.serviceProvider.GetService(f.FieldType))
				.ToArray();

			object[] constrArgs = new object[] { data }
				.Concat(injectArgs)
				.ToArray();

			IExecutable command = (IExecutable)Activator.CreateInstance(commandType, constrArgs);

			return command;
		}
	}
}

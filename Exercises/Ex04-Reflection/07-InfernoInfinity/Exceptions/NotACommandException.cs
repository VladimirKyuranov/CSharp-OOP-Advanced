using System;
public class NotACommandException : ArgumentException
{
	private string commandName;
	public NotACommandException(string commandName)
	{
		this.commandName = commandName;
	}

	public override string Message => $"{this.commandName} Is Not A Command";
}
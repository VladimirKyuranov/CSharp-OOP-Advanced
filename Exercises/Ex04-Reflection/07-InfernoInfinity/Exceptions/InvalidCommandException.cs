using System;
public class InvalidCommandException : ArgumentException
{
	public override string Message => "Invalid Command";
}
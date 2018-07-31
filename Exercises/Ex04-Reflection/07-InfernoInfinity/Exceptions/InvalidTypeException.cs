using System;

public class InvalidTypeException : ArgumentException
{
	private string typeToCkeck;
	public InvalidTypeException(string typeToCheck)
	{
		this.typeToCkeck = typeToCheck;
	}
	public override string Message => $"Invalid {typeToCkeck} Type!";
}
using System;
public class WrongTypeException : ArgumentException
{
	private string typeToCheck;
	private string baseType;

	public WrongTypeException(string typeToCheck, string baseType)
	{
		this.typeToCheck = typeToCheck;
		this.baseType = baseType;
	}

	public override string Message => $"{this.typeToCheck} is not a {baseType} type";
}
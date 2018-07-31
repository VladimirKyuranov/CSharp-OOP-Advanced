using System;
public class InvalidSocketException : ArgumentException
{
	public override string Message => "Invalid Socket!";
}
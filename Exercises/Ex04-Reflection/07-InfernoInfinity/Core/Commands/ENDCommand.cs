using System;
using System.Collections.Generic;
using System.Text;

public class ENDCommand : Command
{
	public ENDCommand(string[] data) 
		: base(data)
	{
	}

	public override void Execute()
	{
		Environment.Exit(0);
	}
}
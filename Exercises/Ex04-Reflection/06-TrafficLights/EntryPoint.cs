using System;
using System.Collections.Generic;

class EntryPoint
{
	static void Main(string[] args)
	{
		IRunable engine = new Engine();
		engine.Run();
	}
}
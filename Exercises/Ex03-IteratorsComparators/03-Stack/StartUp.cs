using System;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		Stack<string> stack = new Stack<string>();
		string input;

		while((input = Console.ReadLine()) != "END")
		{
			string[] commandArgs = input.Split();
			string command = commandArgs[0];

			switch (command)
			{
				case "Push":
					string[] collection = input
						.Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
						.Skip(1)
						.ToArray();

					stack.Push(collection);
					break;
				case "Pop":
					try
					{
						stack.Pop();
					}
					catch (ArgumentException argEx)
					{
						Console.WriteLine(argEx.Message);
					}
					break;
			}
		}

		if (stack.Count > 0)
		{
			Console.WriteLine(string.Join(Environment.NewLine, stack));
			Console.WriteLine(string.Join(Environment.NewLine, stack));
		}
	}
}
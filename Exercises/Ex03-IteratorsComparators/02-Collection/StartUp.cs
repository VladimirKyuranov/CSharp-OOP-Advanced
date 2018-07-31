using System;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		string[] create = Console.ReadLine().Split();
		string[] parameters = create.Skip(1).ToArray();

		var list = new ListyIterator<string>(parameters);

		string command;

		while ((command = Console.ReadLine()) != "END")
		{
			switch (command)
			{
				case "Move":
					Console.WriteLine(list.Move());
					break;
				case "Print":
					try
					{
						list.Print();
					}
					catch (ArgumentException argEx)
					{
						Console.WriteLine(argEx.Message);
					}
					break;
				case "HasNext":
					Console.WriteLine(list.HasNext());
					break;
				case "PrintAll":
					Console.WriteLine(string.Join(" ", list));
					break;
			}
		}
	}
}
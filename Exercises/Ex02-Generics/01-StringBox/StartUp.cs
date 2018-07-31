using System;

class StartUp
{
	static void Main(string[] args)
	{
		int itemsCount = int.Parse(Console.ReadLine());

		for (int counter = 0; counter < itemsCount; counter++)
		{
			string item = Console.ReadLine();
			Box<string> box = new Box<string>(item);

			Console.WriteLine(box);
		}
	}
}
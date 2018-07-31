using System;

class StartUp
{
	static void Main(string[] args)
	{
		int itemsCount = int.Parse(Console.ReadLine());

		for (int counter = 0; counter < itemsCount; counter++)
		{
			int item = int.Parse(Console.ReadLine());
			Box<int> box = new Box<int>(item);

			Console.WriteLine(box);
		}
	}
}
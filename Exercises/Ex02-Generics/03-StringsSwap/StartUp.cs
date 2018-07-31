using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		int itemsCount = int.Parse(Console.ReadLine());
		List<Box<string>> boxes = new List<Box<string>>();

		for (int counter = 0; counter < itemsCount; counter++)
		{
			string item = Console.ReadLine();
			Box<string> box = new Box<string>(item);
			boxes.Add(box);
		}

		int[] indexes = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();

		Swap(indexes[0], indexes[1], boxes);

		string result = string.Join(Environment.NewLine, boxes);
		Console.WriteLine(result);
	}

	static void Swap<T>(int firstIndex, int secondIndex, List<T> boxes)
	{
		T tempItem = boxes[firstIndex];
		boxes[firstIndex] = boxes[secondIndex];
		boxes[secondIndex] = tempItem;
	}
}
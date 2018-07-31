using System;
using System.Collections.Generic;

class StartUp
{
	static void Main(string[] args)
	{
		int itemsCount = int.Parse(Console.ReadLine());
		List<double> strings = new List<double>();

		for (int counter = 0; counter < itemsCount; counter++)
		{
			double item = double.Parse(Console.ReadLine());
			strings.Add(item);
		}

		double testItem = double.Parse(Console.ReadLine());

		int result = CountItems<double>(strings, testItem);
		Console.WriteLine(result);
	}

	static int CountItems<T>(List<T> items, T item)
		where T : IComparable
	{
		int result = 0;

		for (int index = 0; index < items.Count; index++)
		{
			if (items[index].CompareTo(item) == 1)
			{
				result++;
			}
		}

		return result;
	}
}
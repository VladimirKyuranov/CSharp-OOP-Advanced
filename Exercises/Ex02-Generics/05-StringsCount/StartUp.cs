using System;
using System.Collections.Generic;

class StartUp
{
	static void Main(string[] args)
	{
		int itemsCount = int.Parse(Console.ReadLine());
		List<string> strings = new List<string>();

		for (int counter = 0; counter < itemsCount; counter++)
		{
			string item = Console.ReadLine();
			strings.Add(item);
		}

		string testItem = Console.ReadLine();
		
		int result = CountItems<string>(strings, testItem);
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
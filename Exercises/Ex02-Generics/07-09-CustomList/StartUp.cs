using System;

class StartUp
{
	static void Main(string[] args)
	{
		CustomList<string> list = new CustomList<string>();

		string input;

		while ((input = Console.ReadLine()) != "END")
		{
			string[] commandArgs = input.Split();
			string command = commandArgs[0];

			switch (command)
			{
				case "Add":
					string element = commandArgs[1];
					list.Add(element);
					break;
				case "Remove":
					int removeIndex = int.Parse(commandArgs[1]);
					list.Remove(removeIndex);
					break;
				case "Contains":
					element = commandArgs[1];
					bool contains = list.Contains(element);
					Console.WriteLine(contains);
					break;
				case "Swap":
					int firstIndex = int.Parse(commandArgs[1]);
					int secondIndex = int.Parse(commandArgs[2]);
					list.Swap(firstIndex, secondIndex);
					break;
				case "Greater":
					element = commandArgs[1];
					int count = list.CountGreaterThan(element);
					Console.WriteLine(count);
					break;
				case "Max":
					string max = list.Max();
					Console.WriteLine(max);
					break;
				case "Min":
					string min = list.Min();
					Console.WriteLine(min);
					break;
				case "Print":
					for (int index = 0; index < list.Count; index++)
					{
						Console.WriteLine(list[index]);
					}
					break;
				case "Sort":
					list.Sort();
					break;
			}
		}
	}
}
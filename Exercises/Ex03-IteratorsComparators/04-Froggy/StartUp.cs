using System;
using System.Linq;

class StartUp
{
	static void Main(string[] args)
	{
		int[] stones = Console.ReadLine()
			.Split(", ")
			.Select(int.Parse)
			.ToArray();

		var lake = new Lake(stones);
		string result = string.Join(", ", lake);

		Console.WriteLine(result);
	}
}
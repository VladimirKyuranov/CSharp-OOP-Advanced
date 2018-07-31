using System;

class StartUp
{
	static void Main(string[] args)
	{
		string[] firstInput = Console.ReadLine().Split();

		string fullName = $"{firstInput[0]} {firstInput[1]}";
		string address = firstInput[2];
		Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, address);

		string[] secondInput = Console.ReadLine().Split();
		string name = secondInput[0];
		int littersOfBeer = int.Parse(secondInput[1]);
		Tuple<string, int> secondTuple = new Tuple<string, int>(name, littersOfBeer);

		string[] thirdInput = Console.ReadLine().Split();
		int myInt = int.Parse(thirdInput[0]);
		double myDouble = double.Parse(thirdInput[1]);
		Tuple<int, double> thirdTuple = new Tuple<int, double>(myInt, myDouble);

		Console.WriteLine(firstTuple.Value());
		Console.WriteLine(secondTuple.Value());
		Console.WriteLine(thirdTuple.Value());
	}
}
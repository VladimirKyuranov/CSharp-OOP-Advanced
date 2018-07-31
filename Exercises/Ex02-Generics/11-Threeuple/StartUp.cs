using System;

class StartUp
{
	static void Main(string[] args)
	{
		string[] firstInput = Console.ReadLine().Split();

		string fullName = $"{firstInput[0]} {firstInput[1]}";
		string address = firstInput[2];
		string town = firstInput[3];
		Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullName, address, town);

		string[] secondInput = Console.ReadLine().Split();
		string name = secondInput[0];
		int littersOfBeer = int.Parse(secondInput[1]);
		bool drunk = secondInput[2] == "drunk" ? true : false;
		Threeuple<string, int, bool> secondTuple = new  Threeuple<string, int, bool>(name, littersOfBeer, drunk);

		string[] thirdInput = Console.ReadLine().Split();
		string personName = thirdInput[0];
		double balance = double.Parse(thirdInput[1]);
		string bankName = thirdInput[2];
		Threeuple<string, double, string> thirdTuple = new Threeuple<string, double, string>(personName, balance, bankName);

		Console.WriteLine(firstTuple.Value());
		Console.WriteLine(secondTuple.Value());
		Console.WriteLine(thirdTuple.Value());
	}
}
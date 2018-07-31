using System;
using System.Collections.Generic;

class StartUp
{
	static void Main(string[] args)
	{
		SortedSet<Person> sortedPeople = new SortedSet<Person>();
		HashSet<Person> hashedPeople = new HashSet<Person>();

		int peopleCount = int.Parse(Console.ReadLine());

		for (int counter = 0; counter < peopleCount; counter++)
		{
			string[] personArgs = Console.ReadLine().Split();

			string name = personArgs[0];
			int age = int.Parse(personArgs[1]);

			Person person = new Person(name, age);

			sortedPeople.Add(person);
			hashedPeople.Add(person);
		}

		Console.WriteLine(sortedPeople.Count);
		Console.WriteLine(hashedPeople.Count);
	}
}
using System;
using System.Collections.Generic;

class StartUp
{
	static void Main(string[] args)
	{
		SortedSet<Person> nameSortedPeople = new SortedSet<Person>(new NameComparator());
		SortedSet<Person> ageSortedPeople = new SortedSet<Person>(new AgeComparator());

		int peopleCount = int.Parse(Console.ReadLine());

		for (int counter = 0; counter < peopleCount; counter++)
		{
			string[] personArgs = Console.ReadLine().Split();

			string name = personArgs[0];
			int age = int.Parse(personArgs[1]);

			Person person = new Person(name, age);

			nameSortedPeople.Add(person);
			ageSortedPeople.Add(person);
		}

		Console.WriteLine(string.Join(Environment.NewLine, nameSortedPeople));
		Console.WriteLine(string.Join(Environment.NewLine, ageSortedPeople));
	}
}
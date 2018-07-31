using System;
using System.Collections.Generic;

class StartUp
{
	static void Main(string[] args)
	{
		List<Person> people = new List<Person>();
		int count = 0;
		string input;

		while ((input = Console.ReadLine()) != "END")
		{
			string[] personArgs = input.Split();

			string name = personArgs[0];
			int age = int.Parse(personArgs[1]);
			string town = personArgs[2];

			Person person = new Person(name, age, town);

			people.Add(person);
		}

		int personNumber = int.Parse(Console.ReadLine());

		Person thePerson = people[personNumber - 1];

		foreach (Person person in people)
		{
			if (person.CompareTo(thePerson) == 0)
			{
				count++;
			}
		}

		string result;

		if (count < 2)
		{
			result = "No matches";
		}
		else
		{
			int samePeople = count;
			int differentPeople = people.Count - count;
			int allPeople = people.Count;

			result = $"{samePeople} {differentPeople} {allPeople}";
		}

		Console.WriteLine(result);
	}
}
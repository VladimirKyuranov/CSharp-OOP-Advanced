using System;

public class Person : IComparable<Person>
{
	private string name;
	private int age;
	private string town;

	public Person(string name, int age, string town)
	{
		this.name = name;
		this.age = age;
		this.town = town;
	}
	public int CompareTo(Person person)
	{
		int result = this.name.CompareTo(person.name);

		if (result == 0)
		{
			result = this.age.CompareTo(person.age);

			if (result == 0)
			{
				result = this.town.CompareTo(person.town);
			}
		}

		return result;
	}
}
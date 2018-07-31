using System;

public class Person : IComparable<Person>
{
	public Person(string name, int age)
	{
		this.Name = name;
		this.Age = age;
	}

	public string Name { get; }

	public int Age { get; }

	public int CompareTo(Person person)
	{
		int result = this.Name.CompareTo(person.Name);

		if (result == 0)
		{
			result = this.Age.CompareTo(person.Age);
		}

		return result;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
			return false;

		if (this.GetType() != obj.GetType())
			return false;

		Person person = (Person)obj;

		if (this.Name != person.Name)
			return false;

		return this.Age == person.Age;
	}

	public override int GetHashCode()
	{
		int intName = 0;

		foreach (char letter in this.Name)
		{
			intName += (int)letter;
		}

		return intName ^ this.Age;
	}

	public override string ToString()
	{
		return $"{this.Name} {this.Age}";
	}
}
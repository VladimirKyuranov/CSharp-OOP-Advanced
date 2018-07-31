using System;
using System.Linq;
using System.Text;

public class Clinic
{
	private Pet[] pets;
	private int rooms;
	public Clinic(string name, int rooms)
	{
		this.Name = name;
		this.Rooms = rooms;
		this.pets = new Pet[rooms];
	}

	public string Name { get; }

	public bool HasEmptyRooms => this.pets.Any(p => p == null);

	public int CenterIndex => this.pets.Length / 2;

	public int Rooms
	{
		get { return this.rooms; }
		private set
		{
			if (value % 2 == 0)
			{
				throw new InvalidOperationException("Invalid Operation!");
			}

			this.rooms = value;
		}
	}

	public bool Add(Pet pet)
	{
		int currentIndex = this.CenterIndex;

		for (int index = 0; index < this.pets.Length; index++)
		{
			if (index % 2 == 0)
			{
				currentIndex += index;
			}
			else
			{
				currentIndex -= index;
			}

			if (this.pets[currentIndex] == null)
			{
				this.pets[currentIndex] = pet;
				return true;
			}
		}

		return false;
	}

	public bool Release()
	{
		for (int index = this.CenterIndex; index < this.pets.Length; index++)
		{
			if (this.pets[index] != null)
			{
				this.pets[index] = null;
				return true;
			}
		}

		for (int index = 0; index < this.CenterIndex; index++)
		{
			if (this.pets[index] != null)
			{
				this.pets[index] = null;
				return true;
			}
		}

		return false;
	}

	public string Print()
	{
		StringBuilder builder = new StringBuilder();

		for (int index = 1; index <= this.pets.Length; index++)
		{
			builder.AppendLine(this.Print(index));
		}

		string result = builder.ToString().TrimEnd();

		return result;
	}

	public string Print(int roomNumber)
	{
		return this.pets[roomNumber - 1]?.ToString() ?? "Room empty";
	}
}
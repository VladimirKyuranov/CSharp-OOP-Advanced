using System;
using System.Collections;
using System.Collections.Generic;

public class CustomList<T> : IEnumerable<T>
	where T : IComparable
{
	private T[] data;
	private int capacity;

	public CustomList()
	{
		this.data = new T[4];
		this.capacity = 4;
		this.Count = 0;
	}

	public int Count { get; private set; }

	public T this[int index]
	{
		get
		{
			return this.data[index];
		}
		set
		{
			this.data[index] = value;
		}
	}

	public void Add(T element)
	{
		this.Count++;

		if (this.Count > this.capacity)
		{
			this.capacity *= 2;
			T[] newData = new T[this.capacity];
			Array.Copy(this.data, newData, this.Count - 1);
			this.data = newData;
		}

		this.data[this.Count - 1] = element;
	}

	public T Remove(int index)
	{
		this.Count--;

		T element = this.data[index];

		for (int currentIndex = index; currentIndex < this.Count; currentIndex++)
		{
			this.data[currentIndex] = this.data[currentIndex + 1];
		}

		this.data[this.Count] = default(T);
		return element;
	}

	public bool Contains(T element)
	{
		for (int index = 0; index < this.Count; index++)
		{
			if (element.Equals(this.data[index]))
			{
				return true;
			}
		}

		return false;
	}

	public void Swap(int firstIndex, int secondIndex)
	{
		T tempItem = this.data[firstIndex];
		this.data[firstIndex] = this.data[secondIndex];
		this.data[secondIndex] = tempItem;
	}

	public int CountGreaterThan(T element)
	{
		int result = 0;

		for (int index = 0; index < this.Count; index++)
		{
			if (this.data[index].CompareTo(element) > 0)
			{
				result++;
			}
		}

		return result;
	}

	public T Min()
	{
		T min = this.data[0];

		for (int index = 0; index < this.Count; index++)
		{
			if (min.CompareTo(this.data[index]) > 0)
			{
				min = this.data[index];
			}
		}

		return min;
	}

	public T Max()
	{
		T max = this.data[0];

		for (int index = 0; index < this.Count; index++)
		{
			if (max.CompareTo(this.data[index]) < 0)
			{
				max = this.data[index];
			}
		}

		return max;
	}

	public void Sort()
	{
		Array.Sort(this.data, 0, this.Count);
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ((IEnumerable<T>)this.data).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
}
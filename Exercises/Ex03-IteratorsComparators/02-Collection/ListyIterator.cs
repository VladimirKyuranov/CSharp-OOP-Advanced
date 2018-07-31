using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
	private List<T> list;
	private int index;

	public ListyIterator(params T[] list)
	{
		this.list = new List<T>(list);
		this.index = 0;
	}

	public bool Move()
	{
		bool hasNext = this.HasNext();
		if (hasNext)
		{
			index++;
		}

		return hasNext;
	}

	public bool HasNext()
	{
		if (this.index + 1 < this.list.Count)
		{
			return true;
		}

		return false;
	}

	public void Print()
	{
		if (list.Count == 0)
		{
			throw new ArgumentException("InvalidOperation");
		}

		Console.WriteLine(this.list[this.index]);
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int index = 0; index < this.list.Count; index++)
		{
			yield return list[index];
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
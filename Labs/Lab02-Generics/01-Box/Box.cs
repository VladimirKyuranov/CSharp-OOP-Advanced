using System;
using System.Collections.Generic;
using System.Text;

public class Box<T>
{
	private List<T> box;

	public Box()
	{
		this.box = new List<T>();
	}

	public void Add(T element)
	{
		this.box.Add(element);
	}

	public T Remove()
	{
		int lastIndex = this.box.Count - 1;
		T element = this.box[lastIndex];
		this.box.RemoveAt(lastIndex);
		return element;
	}

	public int Count => this.box.Count;
}
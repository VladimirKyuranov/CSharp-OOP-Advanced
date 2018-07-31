using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Stack<T> : IEnumerable<T>
{
	private List<T> stack;

	public Stack()
	{
		this.stack = new List<T>();
	}

	public int Count => this.stack.Count;

	public void Push(ICollection<T> collection)
	{
		this.stack.AddRange(collection);
	}

	public T Pop()
	{
		if (this.stack.Count == 0)
		{
			throw new ArgumentException("No elements");
		}

		int lastIndex = this.stack.Count - 1;
		T element = this.stack[lastIndex];
		this.stack.RemoveAt(lastIndex);

		return element;
	}

	public IEnumerator<T> GetEnumerator()
	{
		for (int index = this.stack.Count - 1; index >= 0; index--)
		{
			yield return this.stack[index];
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
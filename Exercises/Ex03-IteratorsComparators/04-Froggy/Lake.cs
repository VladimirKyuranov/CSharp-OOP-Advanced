using System;
using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
	private List<int> stones;

	public Lake(ICollection<int> stones)
	{
		this.stones = new List<int>(stones);
	}
	public IEnumerator<int> GetEnumerator()
	{
		for (int index = 0; index < this.stones.Count; index++)
		{
			if (index % 2 == 0)
			{
				yield return this.stones[index];
			}
		}

		for (int index = this.stones.Count - 1; index > 0; index--)
		{
			if (index % 2 != 0)
			{
				yield return this.stones[index];
			}
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
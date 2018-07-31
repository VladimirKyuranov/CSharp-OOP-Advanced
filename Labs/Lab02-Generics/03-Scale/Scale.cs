using System;

public class Scale<T>
	where T : IComparable<T>
{
	private T left;
	private T right;

	public Scale(T left, T right)
	{
		this.left = left;
		this.right = right;
	}

	public T GetHeavier()
	{
		int result = this.left.CompareTo(this.right);

		switch (result)
		{
			case 1:
				return this.left;
			case -1:
				return this.right;
			default:
				return default(T);
		}
	}
}

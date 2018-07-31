public class Box<T>
{
	private T item;

	public Box(T item)
	{
		this.item = item;
	}

	public override string ToString()
	{
		string result = $"{this.item.GetType().FullName}: {this.item}";
		return result;
	}
}
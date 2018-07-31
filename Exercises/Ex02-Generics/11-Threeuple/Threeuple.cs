using System;
using System.Collections.Generic;
using System.Text;

public class Threeuple<T1, T2, T3> : Tuple<T1, T2>
{
	private T3 item3;
	public Threeuple(T1 item1, T2 item2, T3 item3) 
		: base(item1, item2)
	{
		this.item3 = item3;
	}

	public override string Value()
	{
		string result = $"{base.Value()} -> {item3}";
		return result;
	}
}
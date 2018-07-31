using System;
using System.Collections.Generic;
using System.Text;

public class PrintCommand : Command
{
	[Inject]
	private IArmory armory;

	public PrintCommand(string[] data, IArmory armory)
		: base(data)
	{
		this.Armory = armory;
	}

	public IArmory Armory
	{
		get { return armory; }
		set { armory = value; }
	}

	public override void Execute()
	{
		string weaponName = this.Data[0];
		IWeapon weapon = this.Armory.GetWeapon(weaponName);
		string result = weapon.ToString();
		Console.WriteLine(result);
	}
}
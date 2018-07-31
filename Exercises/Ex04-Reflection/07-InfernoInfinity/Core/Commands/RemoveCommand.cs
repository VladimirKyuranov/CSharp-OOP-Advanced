public class RemoveCommand : Command
{
	[Inject]
	private IArmory armory;

	public RemoveCommand(string[] data, IArmory armory)
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
		int gemSlot = int.Parse(this.Data[1]);
		weapon.RemoveGem(gemSlot);
	}
}
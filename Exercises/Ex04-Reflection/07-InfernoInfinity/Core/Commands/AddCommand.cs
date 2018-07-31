using System.Linq;

public class AddCommand : Command
{
	[Inject]
	private IArmory armory;
	[Inject]
	private IGemFactory gemFactory;
	
	public AddCommand(string[] data, IArmory armory, IGemFactory gemFactory) 
		: base(data)
	{
		this.Armory = armory;
		this.GemFactory = gemFactory;
	}

	public IArmory Armory
	{
		get { return armory; }
		set { armory = value; }
	}

	public IGemFactory GemFactory
	{
		get { return gemFactory; }
		set { gemFactory = value; }
	}

	public override void Execute()
	{
		string weaponName = this.Data[0];
		IWeapon weapon = this.Armory.GetWeapon(weaponName);
		string[] gemArgs = this.Data.Last().Split().ToArray();
		IGem gem = this.GemFactory.CreateGem(gemArgs);
		int gemSlot = int.Parse(this.Data[1]);
		weapon.AddGem(gem, gemSlot);
	}
}
public class CreateCommand : Command
{
	[Inject]
	private IArmory armory;
	[Inject]
	private IWeaponFactory weaponFactory;

	public CreateCommand(string[] data, IArmory armory, IWeaponFactory weaponFactory)
		: base(data)
	{
		this.Armory = armory;
		this.WeaponFactory = weaponFactory;
	}

	public IArmory Armory
	{
		get { return this.armory; }
		set { this.armory = value; }
	}
	public IWeaponFactory WeaponFactory
	{
		get { return this.weaponFactory; }
		set { this.weaponFactory = value; }
	}

	public override void Execute()
	{
		string[] weaponArgs = this.Data;
		IWeapon weapon = this.WeaponFactory.CreateWeapon(weaponArgs);
		this.Armory.Add(weapon);
	}
}
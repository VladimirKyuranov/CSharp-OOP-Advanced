public class Axe : Weapon
{
	private const int InitialMinDamage = 5;
	private const int InitialMaxDamage = 10;

	public Axe(string rarity, string name)
		: base(rarity, name)
	{
		this.Sockets = new IGem[SocketCount];
	}

	public override int MinDamage => InitialMinDamage * (int)this.Rarity + base.MinDamage;

	public override int MaxDamage => InitialMaxDamage * (int)this.Rarity + base.MaxDamage;

	public override int SocketCount => 4;

	public override IGem[] Sockets { get; }
}
public class Knife : Weapon
{
	private const int InitialMinDamage = 3;
	private const int InitialMaxDamage = 4;

	public Knife(string rarity, string name)
		: base(rarity, name)
	{
		this.Sockets = new IGem[SocketCount];
	}

	public override int MinDamage => InitialMinDamage * (int)this.Rarity + base.MinDamage;

	public override int MaxDamage => InitialMaxDamage * (int)this.Rarity + base.MaxDamage;

	public override int SocketCount => 2;

	public override IGem[] Sockets { get; }
}
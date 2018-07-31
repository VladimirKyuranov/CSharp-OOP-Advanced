public class Sword : Weapon
{
	private const int InitialMinDamage = 4;
	private const int InitialMaxDamage = 6;

	public Sword(string rarity, string name)
		: base(rarity, name)
	{
		this.Sockets = new IGem[SocketCount];
	}

	public override int MinDamage => InitialMinDamage * (int)this.Rarity + base.MinDamage;

	public override int MaxDamage => InitialMaxDamage * (int)this.Rarity + base.MaxDamage;

	public override int SocketCount => 3;

	public override IGem[] Sockets { get; }
}
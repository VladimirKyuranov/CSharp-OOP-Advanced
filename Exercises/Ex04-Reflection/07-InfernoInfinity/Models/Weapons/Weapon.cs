using System;
using System.Linq;

public abstract class Weapon : IWeapon
{
	private Rarity rarity;
	public Weapon(string rarity, string name)
	{
		this.Rarity = Enum.Parse<Rarity>(rarity);
		this.Name = name;
	}

	public string Name { get; }

	public virtual int MinDamage => this.Strength* 2 + this.Agility;

	public virtual int MaxDamage => this.Strength * 3 + this.Agility * 4;

	public Rarity Rarity
	{
		get
		{
			return this.rarity;
		}
		protected set
		{
			Rarity rarity = Validator.ValidateRarity(value.ToString());
			this.rarity = rarity;
		}
	}
	public abstract int SocketCount { get; }

	public abstract IGem[] Sockets { get; }

	public int Strength => this.Sockets.Where(s => s != null).Sum(s => s.Strength);

	public int Agility => this.Sockets.Where(s => s != null).Sum(s => s.Agility);

	public int Vitality => this.Sockets.Where(s => s != null).Sum(s => s.Vitality);

	public void AddGem(IGem gem, int index)
	{
		Validator.ValidateSocket(index, this.Sockets);

		this.Sockets[index] = gem;
	}

	public void RemoveGem(int index)
	{
		Validator.ValidateSocket(index, this.Sockets);

		this.Sockets[index] = null;
	}

	public override string ToString()
	{
		string result = $"{this.Name}: {this.MinDamage}-{this.MaxDamage} Damage, " +
			$"+{this.Strength} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
		return result;
	}
}

using System;

public abstract class Gem : IGem
{
	private Clarity clarity;

	public Gem(string clarity)
	{
		this.Clarity = Enum.Parse<Clarity>(clarity);
	}
	public Clarity Clarity
	{
		get
		{
			return this.clarity;
		}
		protected set
		{
			Clarity clarity = Validator.ValidateClarity(value.ToString());
			this.clarity = clarity;
		}
	}

	public abstract int Strength { get; }

	public abstract int Agility { get;}

	public abstract int Vitality { get; }
}
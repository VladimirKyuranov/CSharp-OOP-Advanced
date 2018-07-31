public class Ruby : Gem
{
	private const int InitialStrength = 7;
	private const int InitialAgility = 2;
	private const int InitialVitality = 5;

	public Ruby(string clarity)
		: base(clarity)
	{
	}

	public override int Strength => InitialStrength + (int)this.Clarity;
	public override int Agility => InitialAgility + (int)this.Clarity;
	public override int Vitality => InitialVitality + (int)this.Clarity;
}
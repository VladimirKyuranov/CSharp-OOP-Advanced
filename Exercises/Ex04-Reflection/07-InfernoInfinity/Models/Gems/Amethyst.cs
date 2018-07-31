public class Amethyst : Gem
{
	private const int initialStrength = 2;
	private const int initialAgility = 8;
	private const int initialVitality = 4;

	public Amethyst(string clarity)
		: base(clarity)
	{
	}

	public override int Strength => initialStrength + (int)this.Clarity;
	public override int Agility => initialAgility + (int)this.Clarity;
	public override int Vitality => initialVitality + (int)this.Clarity;
}
public class Emerald : Gem
{
	private const int initialStrength = 1;
	private const int initialAgility = 4;
	private const int initialVitality = 9;

	public Emerald(string clarity)
		: base(clarity)
	{
	}

	public override int Strength => initialStrength + (int)this.Clarity;
	public override int Agility => initialAgility + (int)this.Clarity;
	public override int Vitality => initialVitality + (int)this.Clarity;
}
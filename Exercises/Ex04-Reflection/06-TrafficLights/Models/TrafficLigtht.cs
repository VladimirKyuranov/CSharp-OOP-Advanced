public class TrafficLigtht : IChangeable
{
	private LightColor state;

	public TrafficLigtht(LightColor state)
	{
		this.state = state;
	}
	public void ChangeState()
	{
		switch (state)
		{
			case LightColor.Red:
				state = LightColor.Green;
				break;
			case LightColor.Green:
				state = LightColor.Yellow;
				break;
			case LightColor.Yellow:
				state = LightColor.Red;
				break;
		}
	}

	public override string ToString()
	{
		return this.state.ToString();
	}
}
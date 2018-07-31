public class TrafficLightFactory
{
	public IChangeable CreateTrafficLight(LightColor state)
	{
		IChangeable trafficLight = new TrafficLigtht(state);
		return trafficLight;
	}
}
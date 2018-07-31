using System;
using System.Collections.Generic;

public class Engine : IRunable
{
	public void Run()
	{
		TrafficLightFactory trafficLightFactory = new TrafficLightFactory();
		List<IChangeable> trafficLights = new List<IChangeable>();
		string[] trafficStates = Console.ReadLine().Split();
		int changesCount = int.Parse(Console.ReadLine());

		for (int index = 0; index < trafficStates.Length; index++)
		{
			LightColor state = (LightColor)Enum.Parse(typeof(LightColor), trafficStates[index]);
			IChangeable trafficLight = trafficLightFactory.CreateTrafficLight(state);
			trafficLights.Add(trafficLight);
		}
		for (int counter = 0; counter < changesCount; counter++)
		{
			trafficLights.ForEach(tl => tl.ChangeState());

			string result = string.Join(" ", trafficLights);
			Console.WriteLine(result);
		}
	}
}
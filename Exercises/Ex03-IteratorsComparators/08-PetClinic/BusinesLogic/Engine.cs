using System;
using System.Linq;
public class Engine
{
	public void Run()
	{
		ClinicsManager clinicsManager = new ClinicsManager();
		int commandsCount = int.Parse(Console.ReadLine());

		for (int counter = 0; counter < commandsCount; counter++)
		{
			string[] commandArgs = Console.ReadLine().Split();

			string command = commandArgs[0];
			string[] parameters = commandArgs.Skip(1).ToArray();

			switch (command)
			{
				case "Create":
					string type = commandArgs[1];
					parameters = commandArgs.Skip(2).ToArray();

					if (type == "Pet")
					{
						clinicsManager.CreatePet(parameters);
					}
					else
					{
						clinicsManager.CreateClinic(parameters);
					}
					break;
				case "Add":
					clinicsManager.AddPet(parameters);
					break;
				case "Release":
					clinicsManager.ReleasePet(parameters);
					break;
				case "HasEmptyRooms":
					clinicsManager.HasEmptyRooms(parameters);
					break;
				case "Print":
					clinicsManager.Print(parameters);
					break;
			}
		}
	}
}
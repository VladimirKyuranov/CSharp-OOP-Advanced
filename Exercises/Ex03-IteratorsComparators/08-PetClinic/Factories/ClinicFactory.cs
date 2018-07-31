public class ClinicFactory
{
	public Clinic CreateClinic(string[] parameters)
	{
		string name = parameters[0];
		int rooms = int.Parse(parameters[1]);

		return new Clinic(name, rooms);
	}
}
public class PetFactory
{
	public Pet CreatePet(string[] parameters)
	{
		string name = parameters[0];
		int age = int.Parse(parameters[1]);
		string kind = parameters[2];

		return new Pet(name, age, kind);
	}
}
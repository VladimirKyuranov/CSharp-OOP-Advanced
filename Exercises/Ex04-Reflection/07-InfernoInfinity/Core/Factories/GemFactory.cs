using System;
using System.Linq;
using System.Reflection;

public class GemFactory : IGemFactory
{
	public IGem CreateGem(params string[] parameters)
	{
		string gemClarity = parameters[0];
		string gemType = parameters[1];

		Assembly assembly = Assembly.GetCallingAssembly();
		Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == gemType);
		Validator.ValidateType(model, typeof(IGem));

		IGem gem = (IGem)Activator.CreateInstance(model, gemClarity);
		return gem;
	}
}
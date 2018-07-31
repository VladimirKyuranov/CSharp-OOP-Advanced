using System;
using System.Linq;
using System.Reflection;

public class WeaponFactory : IWeaponFactory
{
	public IWeapon CreateWeapon(params string[] parameters)
	{
		string[] weaponArgs = parameters[0].Split();
		string weaponRarity = weaponArgs[0];
		string weaponType = weaponArgs[1];
		string weaponName = parameters[1];

		Assembly assembly = Assembly.GetCallingAssembly();
		Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);
		Validator.ValidateType(model, typeof(IWeapon));

		IWeapon weapon = (IWeapon)Activator.CreateInstance(model, weaponRarity, weaponName);
		return weapon;
	}
}
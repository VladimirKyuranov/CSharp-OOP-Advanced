using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Armory : IArmory
{
	private List<IWeapon> weapons;

	public Armory()
	{
		this.weapons = new List<IWeapon>();
	}

	public void Add(IWeapon weapon)
	{
		this.weapons.Add(weapon);
	}

	public IWeapon GetWeapon(string weaponName)
	{
		IWeapon weapon = this.weapons.FirstOrDefault(w => w.Name == weaponName);

		return weapon;
	}

	public string Print(string weaponName)
	{
		IWeapon weapon = this.GetWeapon(weaponName);

		string result = weapon.ToString();
		return result;
	}
}
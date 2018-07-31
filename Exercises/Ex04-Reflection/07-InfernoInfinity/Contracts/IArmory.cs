using System;
using System.Collections.Generic;
using System.Text;

public interface IArmory
{
	void Add(IWeapon weapon);

	IWeapon GetWeapon(string weaponName);

	string Print(string weaponName);
}
using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicsManager
{
	List<Pet> pets = new List<Pet>();
	List<Clinic> clinics = new List<Clinic>();
	PetFactory petFactory = new PetFactory();
	ClinicFactory clinicFactory = new ClinicFactory();
	public void CreatePet(string[] parameters)
	{
		Pet pet = petFactory.CreatePet(parameters);
		pets.Add(pet);
	}

	public void CreateClinic(string[] parameters)
	{
		try
		{
			Clinic clinic = clinicFactory.CreateClinic(parameters);
			clinics.Add(clinic);
		}
		catch (InvalidOperationException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public void AddPet(string[] parameters)
	{
		string petName = parameters[0];
		string clinicName = parameters[1];

		Pet pet = pets.FirstOrDefault(p => p.Name == petName);
		Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

		Console.WriteLine(clinic.Add(pet));
	}

	public void ReleasePet(string[] parameters)
	{
		string clinicName = parameters[0];

		Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
		Console.WriteLine(clinic.Release());
	}

	public void HasEmptyRooms(string[] parameters)
	{
		string clinicName = parameters[0];

		Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);
		Console.WriteLine(clinic.HasEmptyRooms);
	}

	public void Print(string[] parameters)
	{
		string clinicName = parameters[0];

		Clinic clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

		if (parameters.Length == 2)
		{
			int roomNumber = int.Parse(parameters[1]);
			Console.WriteLine(clinic.Print(roomNumber));
		}
		else
		{
			Console.WriteLine(clinic.Print());
		}
	}
}
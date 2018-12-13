namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using System.Linq;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (model == null)
            {
                throw new InvalidOperationException("Invalid airplane type!");
            }

            IAirplane airplane = (IAirplane)Activator.CreateInstance(model);
            return airplane;
		}
	}
}
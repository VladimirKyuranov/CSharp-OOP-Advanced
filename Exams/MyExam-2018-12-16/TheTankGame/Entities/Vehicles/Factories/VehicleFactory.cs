using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Miscellaneous;
using TheTankGame.Entities.Miscellaneous.Contracts;
using TheTankGame.Entities.Vehicles.Contracts;
using TheTankGame.Entities.Vehicles.Factories.Contracts;

namespace TheTankGame.Entities.Vehicles.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string vehicleType, string model, double weight, decimal price, int attack, int defense, int hitPoints)
        {
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == vehicleType);
            IAssembler assembler = new VehicleAssembler();

            if (type == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            IVehicle part = (IVehicle)Activator.CreateInstance(type, model, weight, price, attack, defense, hitPoints, assembler);
            return part;
        }
    }
}

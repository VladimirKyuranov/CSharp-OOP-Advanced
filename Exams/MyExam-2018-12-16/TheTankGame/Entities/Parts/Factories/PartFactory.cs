using System;
using System.Linq;
using System.Reflection;
using TheTankGame.Entities.Parts.Contracts;
using TheTankGame.Entities.Parts.Factories.Contracts;

namespace TheTankGame.Entities.Parts.Factories
{
    public class PartFactory : IPartFactory

    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            partType += "Part";
            Assembly assembly = Assembly.GetCallingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == partType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid part type!");
            }

            IPart part = (IPart)Activator.CreateInstance(type, model, weight, price, additionalParameter);
            return part;
        }
    }
}

namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
	{
		public IInstrument CreateInstrument(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (model == null)
            {
                throw new InvalidOperationException("Invalid instrument type!");
            }

            IInstrument instrument = (IInstrument)Activator.CreateInstance(model);
            return instrument;
		}
	}
}
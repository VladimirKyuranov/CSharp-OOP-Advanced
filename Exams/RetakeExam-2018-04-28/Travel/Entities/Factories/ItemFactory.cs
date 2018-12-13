namespace Travel.Entities.Factories
{
    using Contracts;
    using Items.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class ItemFactory : IItemFactory
	{
		public IItem CreateItem(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == type);

            if (model == null)
            {
                throw new InvalidOperationException("Invalid airplane type!");
            }

            IItem item = (IItem)Activator.CreateInstance(model);
            return item;
        }
	}
}

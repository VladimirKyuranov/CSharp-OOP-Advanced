﻿namespace _03BarracksFactory
{
	using _03BarraksFactory.Core;
	using Contracts;
    using Core;
    using Core.Factories;
    using Data;
	using Microsoft.Extensions.DependencyInjection;
	using System;

	class AppEntryPoint
    {
        static void Main(string[] args)
        {
			IServiceProvider serviceProvider = ConfigureServices();
			ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

		private static IServiceProvider ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddTransient<IUnitFactory, UnitFactory>();
			services.AddSingleton<IRepository, UnitRepository>();

			IServiceProvider serviceProvider = services.BuildServiceProvider();
			return serviceProvider;
		}
	}
}

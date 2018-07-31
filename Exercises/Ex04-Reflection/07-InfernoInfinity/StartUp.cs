using System;
using Microsoft.Extensions.DependencyInjection;

class StartUp
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

		services.AddTransient<IWeaponFactory, WeaponFactory>();
		services.AddTransient<IGemFactory, GemFactory>();
		services.AddSingleton<IArmory, Armory>();

		IServiceProvider serviceProvider = services.BuildServiceProvider();
		return serviceProvider;
	}
}
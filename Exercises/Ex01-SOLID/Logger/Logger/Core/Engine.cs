namespace Solid.Logger.Core
{
    using Contracts;
    using System;

    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int counter = 0; counter < commandsCount; counter++)
            {
                string[] inputArgs = Console.ReadLine()
                    .Split();

                this.commandInterpreter.AddAppender(inputArgs);
            }

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split('|');

                this.commandInterpreter.AddMessage(inputArgs);
            }

            this.commandInterpreter.PrintInfo();
        }
    }
}

namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IFestivalController festivalCоntroller;
        private readonly ISetController setCоntroller;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.festivalCоntroller = festivalController;
            this.setCоntroller = setController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "END")
            {
                string commandResult;

                try
                {
                    commandResult = this.ProcessCommand(input);
                }
                catch (TargetInvocationException ex)
                {
                    commandResult = "ERROR: " + ex.InnerException.Message;
                }
                catch (Exception ex)
                {
                    commandResult = "ERROR: " + ex.Message;
                }

                this.writer.WriteLine(commandResult);
            }

            string reportResult = this.festivalCоntroller.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(reportResult);
        }

        public string ProcessCommand(string input)
        {
            string[] inputArgs = input.Split();

            string commandName = inputArgs[0];
            string[] args = inputArgs
                .Skip(1)
                .ToArray();

            string result;

            if (commandName == "LetsRock")
            {
                result = this.setCоntroller.PerformSets();
            }
            else
            {
                MethodInfo command = this.festivalCоntroller
                    .GetType()
                    .GetMethods()
                    .FirstOrDefault(x => x.Name == commandName);

                result = (string)command.Invoke(this.festivalCоntroller, new object[] { args });
            }

            return result;
        }
    }
}
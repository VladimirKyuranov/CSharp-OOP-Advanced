namespace TheTankGame.Core
{
    using Contracts;
    using IO.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

        }

        public void Run()
        {
            string input;

            while ((input = this.reader.ReadLine()) != "Terminate")
            {
                IList<string> commandArgs = input.Split().ToList();
                string result = this.commandInterpreter.ProcessInput(commandArgs);
                this.writer.WriteLine(result);
            }

            string terminateResult = this.commandInterpreter.ProcessInput(new List<string> { "Terminate" });
            this.writer.WriteLine(terminateResult);
        }
    }
}
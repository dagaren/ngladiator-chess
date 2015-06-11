using System;

namespace Gladiator
{
    class Program
    {
        static void Main(string[] args)
        {
            IController controller = GetController();

            controller.Run();
        }

        private static IController GetController()
        {
            ICommandReader commandReader = new ConsoleCommandReader();
            ICommandWriter commandWriter = new ConsoleCommandWriter();
            return new Controller(commandReader, commandWriter);
        }
    }
}

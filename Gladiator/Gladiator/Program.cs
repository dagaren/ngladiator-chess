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
            return new Controller();
        }
    }
}

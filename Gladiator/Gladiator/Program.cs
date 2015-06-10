using System;

namespace Gladiator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "xboard":
                        Console.WriteLine("> xboard command received!");
                        break;
                    case "quit":
                        exit = true;
                        break;
                }
            }

            Console.WriteLine("Normal termination of the program");
        }
    }
}

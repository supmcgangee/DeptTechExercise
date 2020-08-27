using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise
{
    public class Writer
    {
        private Server server;

        public Writer()
        {
            server = Server.Instance();
            Console.WriteLine("Welcome My AQ app that does AQ things\n\n");
        }

        public void Display()
        {
            DisplayOptions();

            RegisterInput();
        }

        public void DisplayOptions()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("t : Test Response");
            Console.WriteLine("q : Quit");
            Console.WriteLine();
        }

        public void RegisterInput()
        {
            var input = Console.ReadKey();

            switch(input.KeyChar)
            {
                case 'q':
                    server.CloseApp();
                    break;
                case 't':
                    Console.WriteLine("\n Response:" + server.TestResponse());
                    break;
                default:
                    Console.WriteLine("\nInvalid Char");
                    break;
            }
        }
    }

}

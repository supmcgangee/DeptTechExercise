using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise
{
    public class Writer
    {
        public Writer()
        {
            Console.WriteLine("Welcome My AQ app that does AQ things\n\n");
        }

        public void Display()
        {
            DisplayOptions();

            RegisterInput();
        }

        public void DisplayOptions()
        {
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("Close app: \ty - n?");
        }

        public void RegisterInput()
        {
            var server = Server.Instance();
            var input = Console.ReadKey();

            switch(input.KeyChar)
            {
                case 'y':
                    server.CloseApp();
                    break;
                case 'n':
                    break;
                default:
                    Console.WriteLine("Invalid Char");
                    break;
            }
        }
    }

}

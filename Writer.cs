using DeptTechExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private void DisplayOptions()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("What do you want to do?\n");
            Console.WriteLine("t : Test Response");
            Console.WriteLine("b : Lets Check Burgenland");
            Console.WriteLine("q : Quit");
            Console.WriteLine();
        }

        private void RegisterInput()
        {
            var input = Console.ReadKey();

            switch(input.KeyChar)
            {
                case 't':
                    Console.WriteLine("\n Response:" + server.TestResponse());
                    break;
                case 'b':
                    DisplayResponseForCity();
                    break;
                case 'q':
                    server.CloseApp();
                    break;
                default:
                    Console.WriteLine("\nInvalid Char");
                    break;
            }
        }

        private void DisplayResponseForCity()
        {
            // Set as param
            var city = "Burgenland";
            var data = server.GetMeasurementsForCity(city);

            
            Console.WriteLine();
            Console.WriteLine("\nMeasurements");

            // vvv - This block can be better. I dont want to spend to much time on it, This is fine. 
            var allMeasuremnts = new List<MeasurementModel>();
            data.results.Select(x => x.measurements)
                        .ToList()
                        .ForEach(list =>
                        {
                            list.ForEach(m => allMeasuremnts.Add(m));
                        });

            foreach(var mment in allMeasuremnts)
            {
                Console.WriteLine("\n  Type: " + mment.parameter);
                Console.WriteLine($"\n  Amount: {mment.value} {mment.unit}");
                Console.WriteLine("\n  Source: " + mment.sourceName);
                Console.WriteLine("\n  Last Updated: " + mment.lastUpdated);
                Console.WriteLine();
            }
        }
    }

}

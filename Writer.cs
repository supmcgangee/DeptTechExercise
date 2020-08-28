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
            Console.WriteLine("Please enter a city name. (Case Sensitive)\n");
            Console.WriteLine("\t'Test' to test connection to the API");
            Console.WriteLine("\t'q' to close the app.");
            Console.WriteLine();
        }

        private void RegisterInput()
        {
            var input = Console.ReadLine();

            switch(input.ToLower())
            {
                case "test":
                    Console.WriteLine("\n Response:" + server.TestResponse());
                    break;
                case "q":
                    server.CloseApp();
                    break;
                default:
                    SearchForCity(input);
                    break;
            }
        }

        private void SearchForCity(string input)
        {
            var queryData = server.GetMeasurementsForCity(input);
            if (queryData.meta.found != 0)
                DisplayResponseForCity(queryData);
            else
                Console.WriteLine("\n* No data found for searched City *");
        }

        private void DisplayResponseForCity(QueryResponseModel queryData)
        {
            Console.WriteLine();
            Console.WriteLine("\nMeasurements");

            // vvv - This block can be better. I dont want to spend to much time on it, This is fine. 
            var allMeasuremnts = new List<MeasurementModel>();
            queryData.results.Select(x => x.measurements)
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

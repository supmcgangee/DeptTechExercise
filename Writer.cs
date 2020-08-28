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
            // I dont clean the input here. Please be nice to their server.

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
                DisplayFilterSettingsForCity(queryData);
            else
                Console.WriteLine("\n* No data found for searched City *");
        }

        private void DisplayFilterSettingsForCity(QueryResponseModel queryData)
        {
            Console.WriteLine();
            Console.WriteLine("\nMeasurements");

            // vvv - This block can be better. I dont want to spend to much time on it, This is fine.
            var refiningSearch = true;
            while (refiningSearch)
            {
                PromptForFilterOptions();
                var input = Console.ReadKey();
                var measurements = queryData.GetAllMeasurements();

                switch (input.KeyChar)
                {
                    case '1':
                        DisplayAllMeasurements(measurements);
                        break;
                    case '2':
                        refiningSearch = SortDataByDate(measurements);
                        break;
                    case '3':
                        refiningSearch = SortByType(measurements);
                        break;
                    default:
                        Console.WriteLine("\n*** Input not recognised ***");
                        break;

                }
            }
        }

        private void DisplayAllMeasurements(List<MeasurementModel> dataList)
        {
            foreach (var measurement in dataList)
            {
                DisplayMeasurement(measurement);
            }
        }

        private bool SortDataByDate(List<MeasurementModel> dataList)
        {
            Console.WriteLine("Please select which time group!\n");
            var queryComplete = false;
            var searchAgain = false;

            var allTimes = dataList.GroupBy(x => x.lastUpdated)
                .Select(x => x.Key).ToList();

            while(!queryComplete)
            { 
                var validEntries = DisplayAllFilterOptions(allTimes);

                var option = Console.ReadLine();

                if (option == "back")
                {
                    queryComplete = true;
                    searchAgain = true;
                }
                else if (option == "quit")
                {
                    queryComplete = true;
                }
                else if (!validEntries.Contains(option))
                {
                    Console.WriteLine("\n*** Input not recognised ***");
                }
                else
                {
                    var selectedTime = allTimes[Int32.Parse(option)];
                    var selectedData = dataList.Where(x => x.lastUpdated == selectedTime).ToList();
                    foreach (var measurement in selectedData)
                    {
                        DisplayMeasurement(measurement);
                    }
                }
            }

            return queryComplete;
        }

        private bool SortByType(List<MeasurementModel> dataList)
        {
            Console.WriteLine("Please select which type!\n");
            var queryComplete = false;
            var searchAgain = false;

            var allTypes = dataList.GroupBy(x => x.parameter)
                .Select(x => x.Key).ToList();

            while (!queryComplete)
            { //I copied and pasted this from above method, I know, bad me.
                    // Future me: It didnt work. I deserve this.
                var validEntries = DisplayAllFilterOptions(allTypes);

                var option = Console.ReadLine();

                if (option == "back")
                {
                    queryComplete = true;
                    searchAgain = true;
                }
                else if (option == "quit")
                {
                    queryComplete = true;
                }
                else if (!validEntries.Contains(option))
                {
                    Console.WriteLine("\n*** Input not recognised ***");
                }
                else
                {
                    var selectedType = allTypes[Int32.Parse(option)];
                    var selectedData = dataList.Where(x => x.parameter == selectedType).ToList();
                    foreach (var measurement in selectedData)
                    {
                        DisplayMeasurement(measurement);
                    }
                }
            }

            return queryComplete;
        }

        private List<string> DisplayAllFilterOptions(List<string> filterOptions)
        {
            var validEntries = new List<string>();
            for (int i = 0; i < filterOptions.Count(); i++)
            {
                Console.WriteLine($"'{i}': {filterOptions[i]}\n");
                validEntries.Add(i.ToString());
            }
            Console.WriteLine("\t* 'back' to sort by another type.'\n");
            Console.WriteLine("\t* 'quit' to search again.'\n");

            return validEntries;
        }

        private void DisplayMeasurement(MeasurementModel measurement)
        {
            Console.WriteLine("\n  Type: " + measurement.parameter);
            Console.WriteLine($"\n  Amount: {measurement.value} {measurement.unit}");
            Console.WriteLine("\n  Source: " + measurement.sourceName);
            Console.WriteLine("\n  Last Updated: " + measurement.lastUpdated);
            Console.WriteLine();
        }

        private void PromptForFilterOptions()
        {
            Console.WriteLine("How would you like to view the data?");
            Console.WriteLine("1 : I want all of it.");
            Console.WriteLine("2 : Sort it by date please.");
            Console.WriteLine("3 : I only care about X");
        }
    }

}

using DeptTechExercise.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DeptTechExercise
{
    public class APIHandler
    {
        public string TestResponse()
        {
            var response = APIRequester.TestResponseAsync();

            if(response.Result.IsSuccessStatusCode)
                return "Success code: " + response.Result.StatusCode.ToString();
            else
                return "Uh oh: " + response.Result.StatusCode.ToString();
        }

        public QueryResponseModel GetMeasurementsForCity(string city)
        {
            var response = APIRequester.GetMeasurementsAsync(city);
            response.Wait();
            Console.WriteLine($"\n***{response.Result.StatusCode.ToString()}***\n");
            //No error checking here. Oh well ¯\_(ツ)_/¯

            var data = response.Result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<QueryResponseModel>(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeptTechExercise
{
    public static class APIRequester
    {
        private static HttpClient client;

        static APIRequester()
        {
            client = InitClient();
        }

        private static HttpClient InitClient()
        {
            var client = new HttpClient();
            return client;
        }

        public static async Task<HttpResponseMessage> TestResponseAsync()
        {
            var address = "https://api.openaq.org/v1/cities";
            var response = await client.GetAsync(address);
            return response;
        }

        public static async Task<HttpResponseMessage> GetMeasurementsAsync(string city)
        {
            var address = $"https://api.openaq.org/v1/latest?city={city}";
            var response = await client.GetAsync(address);
            return response;
        }
    }
}

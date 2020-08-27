using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeptTechExercise
{
    public class APIRequester
    {
        private HttpClient client;

        public APIRequester()
        {
            client = InitClient();
        }

        private HttpClient InitClient()
        {
            var client = new HttpClient();
            return client;
        }

        public async Task<HttpResponseMessage> TestResponseAsync()
        {
            var address = "https://api.openaq.org/beta/averages";
            var response = await client.GetAsync(address);
            return response;
        }
    }
}

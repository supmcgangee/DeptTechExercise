using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise
{
    public class APIHandler
    {
        private APIRequester requester;
        public APIHandler()
        {
            requester = new APIRequester();
        }

        public string TestResponse()
        {
            var response = requester.TestResponseAsync();

            if(response.Result.IsSuccessStatusCode)
                return "Success: + " + response.Result.StatusCode.ToString();
            else
                return "Uh oh: + " + response.Result.StatusCode.ToString();
        }
    }
}

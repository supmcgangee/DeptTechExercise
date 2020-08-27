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
                return "Success code: + " + response.Result.StatusCode.ToString();
            else
                return "Uh oh coed: + " + response.Result.StatusCode.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DeptTechExercise
{
    public class APIRequester
    {
        private HttpClient client;

        public APIRequester()
        {
            client = new HttpClient();
        }
    }
}

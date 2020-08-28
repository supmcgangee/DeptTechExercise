using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise.Models
{
    public class QueryResponseModel
    {
        public MetadataModel meta = new MetadataModel();
        public List<CityResponseModel> results = new List<CityResponseModel>();
    }
}

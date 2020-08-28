using System;
using System.Collections.Generic;
using System.Text;

namespace DeptTechExercise.Models
{
    public class CityResponseModel
    {
        public string locationId;
        public string cityName;
        public string country;
        public List<MeasurementModel> measurements = new List<MeasurementModel>();
    }
}

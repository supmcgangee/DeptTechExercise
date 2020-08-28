using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeptTechExercise.Models
{
    public class QueryResponseModel
    {
        public MetadataModel meta = new MetadataModel();
        public List<CityResponseModel> results = new List<CityResponseModel>();
    
        public List<MeasurementModel> GetAllMeasurements()
        {
            var allMeasuremnts = new List<MeasurementModel>();
            this.results.Select(x => x.measurements)
                        .ToList()
                        .ForEach(list =>
                        {
                            list.ForEach(m => allMeasuremnts.Add(m));
                        });

            return allMeasuremnts;
        }
    }
}

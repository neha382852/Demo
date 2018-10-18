using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Translater
{
    public static class TranslateDataOfOutsideAirport
    {
        public static List<AllDataModel> TransalateAllData(this JArray results)
        {
            List<AllDataModel> AllDataDetails = new List<AllDataModel>();
            for (var index = 0; index < results.Count; index++)
            {
                AllDataModel allData = new AllDataModel();
                var resultObject = (JObject)results[index];

                allData.Name = resultObject["name"].Value<string>();
                allData.Address = resultObject["formatted_address"].Value<string>();

                try
                {
                    allData.Ratings = resultObject["rating"].Value<string>();
                }
                catch
                {
                    allData.Ratings = "Not Available";
                }

                try
                {
                    var openingStatus = resultObject["opening_hours"].Value<JObject>();
                    allData.OpenNowStatus = openingStatus["open_now"].Value<string>();
                }
                catch
                {
                    allData.OpenNowStatus = "Not Available";
                }

                allData.PlaceId = resultObject["place_id"].Value<string>();

                AllDataDetails.Add(allData);
            }
            return AllDataDetails;

        }
    }
}

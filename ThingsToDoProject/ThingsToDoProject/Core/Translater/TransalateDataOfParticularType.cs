using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;

namespace ThingsToDoProject.Core.Translater
{
    public static class TransalateDataOfParticularType
    {
        public static List<DataAttributes> TransalateData(this JArray results)
        {
            List<DataAttributes> StoreDetails = new List<DataAttributes>();
            for (var index = 0; index < results.Count; index++)
            {
                DataAttributes store = new DataAttributes();

                var resultObject = (JObject)results[index];
                store.Name = resultObject["name"].Value<string>();
                try
                {
                    var openingStatus = resultObject["opening_hours"].Value<JObject>();
                    store.OpenClosedStatus = openingStatus["open_now"].Value<string>();
                }
                catch
                {
                    store.OpenClosedStatus = "Status Not Available";
                }
                //var photos = resultObject["photos"].Value<JArray>();
                //store.PhotoReference = photos["photo_reference"].Value<Int32>().ToString();
                store.PlaceID = resultObject["place_id"].Value<string>();
                try
                {
                    store.Rating = Convert.ToInt32(resultObject["rating"].Value<string>());
                }
                catch
                {
                    store.Rating = -1;
                }
                //store.Type = resultObject["types"].Value<string>();
                store.Vicinity = resultObject["vicinity"].Value<string>();
                var geometry = resultObject["geometry"].Value<JObject>();
                var location = geometry["location"].Value<JObject>();
                store.Longitute = location["lat"].Value<string>();
                store.Latitude = location["lng"].Value<string>();
                StoreDetails.Add(store);
            }
            return StoreDetails;
            //return null;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using ThingsToDoProject.Model;
using ThingsToDoProject.Core.Provider;
using ThingsToDoProject.Core.Translater;

namespace ThingsToDoProject.Core.Provider
{
    public class GetDataOfParticularType : IGetData
    {
        private readonly IHttpClientFactory _httpClientFactory;
        IConfiguration _iconfiguration;

        public GetDataOfParticularType(IHttpClientFactory httpClientFactory , IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _iconfiguration = configuration;
        }
        public async Task<List<DataAttributes>> GetData(Location Position, string TypeValue)
        {
            try
            {
                //using (HttpClient client = new HttpClient())
                //{
                    var client = _httpClientFactory.CreateClient("GoogleClient");
                    Uri endpoint = client.BaseAddress; // Returns GoogleApi
                    var Key = _iconfiguration["GoogleAPI"];
                    var Url = endpoint.ToString() + "maps/api/place/nearbysearch/json?location=18.579343,73.9089168&radius=1000&type=" + TypeValue + "&key=" + Key;
                    //var Url = endpoint.ToString() + "maps/api/place/nearbysearch/json?location=" + Position.LatitudePosition + "," + Position.LongitudePosition + "&radius=1000&type=" + TypeValue + "&key=" + Key;
                    var client1 = _httpClientFactory.CreateClient();
                    var response = await client1.GetAsync(Url);

                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ////var finalObject = JsonConvert.DeserializeObject<>(responseBody);
                    var data = (JObject)JsonConvert.DeserializeObject(responseBody);
                    var results = data["results"].Value<JArray>();
                   // List<DataAttributes> Data = _translater.TransalateData(results);
                    List<DataAttributes> Data = results.TransalateData();



                return Data;
            }
            catch(Exception e)
            {

            }
            return null;
        }
    }
    
    //public static class Translator
    //{
    //    public static List<DataAttributes> GetTranslatedData(this JArray result)
    //    {
    //        return null;
    //    }
    //}
}

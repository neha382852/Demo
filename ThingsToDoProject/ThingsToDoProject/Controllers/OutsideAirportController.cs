using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThingsToDoProject.Core.Interface;

namespace ThingsToDoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutsideAirportController : ControllerBase
    {
        // GET: api/OutsideAirport

            private readonly IGetOutsideData _getAllData;
            public OutsideAirportController(IGetOutsideData getAllData)
            {
                _getAllData = getAllData;
            }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            //GetLatitudeLongitude PositionObject = new GetLatitudeLongitude();

            var Data = await _getAllData.GetAllData();
            if (Data != null)
                return Ok(Data);
            else
                return BadRequest("Data Not Found");
        }

        //// GET: api/OutsideAirport/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/OutsideAirport
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/OutsideAirport/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

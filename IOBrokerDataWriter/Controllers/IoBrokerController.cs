using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using JusiBase;
//Update-Package

namespace IOBrokerDataWriter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoBrokerController : ControllerBase
    {
        // GET: api/IoBroker
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/IoBroker/zwave2.0.Node_031.Binary_Switch.targetValue?zielwert=true
        //http://iobrokerdatawriter.prod-system.192.168.2.114.xip.io/api/IoBroker/zwave2.0.Node_031.Binary_Switch.targetValue?zielwert=true
        [HttpGet("{id}", Name = "Get")]    
        public ActionResult Get(string id, string zielwert)
        //public string Get(string id)
        {
            bool zielwertBool = false;
            if (zielwert == "true")
            {
                zielwertBool = true;
            }

            Console.WriteLine("get string");
            Console.WriteLine(id);

            IOBrokerWebConnector ioSet = new IOBrokerWebConnector();

            return Content(JsonConvert.SerializeObject(ioSet.SetIOBrokerValue(id,zielwertBool)), "application/json");
            //return "value " + intColl.getIntValue(id);
        }

        // POST: api/IoBroker
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/IoBroker/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

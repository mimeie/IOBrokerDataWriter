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
        //http://iobrokerdatawriter.prod.j1/api/IoBroker/zwave2.0.Node_031.Binary_Switch.targetValue?zielwert=true
        //http://jportal1.mei.local:8087/set/zwave2.0.Node_034.Multilevel_Switch.targetValue?value=false
        [HttpGet("{id}", Name = "Get")]    
        public ActionResult Get(string id, string zielwert)      
        {
            //datentyp herausfinden
            bool isZielwertBool = true;
            bool zielwertBool = false;
            int zielwertInt=0;
            if (zielwert == "true")
            {
                zielwertBool = true;
            }
            else if (zielwert == "false")
            {
                zielwertBool = false;
            }
            else
            {
                isZielwertBool = false;
                zielwertInt =  Int32.Parse(zielwert);
            }

            Console.WriteLine("get string: {0}, zielwert= {1}", id, zielwert);
           
            IOBrokerWebConnector ioSet = new IOBrokerWebConnector();
            IOBrokerJSONSet result;
            if (isZielwertBool == true)
            {
                result = ioSet.SetIOBrokerValue(id, zielwertBool);
            }
            else
            {
                result = ioSet.SetIOBrokerValue(id, zielwertInt);
            }
            if (result != null)
            {
                Console.WriteLine("content zurück erhalten");
                return Content(JsonConvert.SerializeObject(result), "application/json");               
            }
            else
            {
                Console.WriteLine("content null, ohne error");
                return null;
            }

            
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

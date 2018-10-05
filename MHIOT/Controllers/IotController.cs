using MHIOT.Database;
using MHIOT.Models;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MHIOT.Controllers
{
    public class IotController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetTemperature()
        {
            var dao = new TemperatureDAO();
           
            return Ok(dao.GetAll());
        }

        [HttpPost]
        public IHttpActionResult PostTemperature(TemperatureData data)
        {       
            if (data == null || data.Temperature == null || data.Humidity == null)
            {
                return InternalServerError(new System.Exception("Null parameters"));
            }

            var dao = new TemperatureDAO();
            dao.Insert(data);

            return Ok();
        }     
    }
}

using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class CarversionController : ApiController
    {
        CarversionModel carversionModel = new CarversionModel();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = carversionModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(CarversionModel objCarversion)
        {
            string result = carversionModel.Insertdata(objCarversion);
            return result;
        }

        [HttpPut]
        public string Put(CarversionModel objCarversion)
        {
            string result = carversionModel.Updatedata(objCarversion);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = carversionModel.DeleteData(ID);
            return result;
        }

        [Route("OldCar/Carversion/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = carversionModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
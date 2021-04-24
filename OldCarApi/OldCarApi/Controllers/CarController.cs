using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class CarController : ApiController
    {
        CarModel carModel = new CarModel();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = carModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(CarModel objModel)
        {
            string result = carModel.Insertdata(objModel);
            return result;
        }

        [HttpPut]
        public string Put(CarModel objModel)
        {
            string result = carModel.Updatedata(objModel);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = carModel.DeleteData(ID);
            return result;
        }

        [Route("OldCar/Car/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = carModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("OldCar/Car/GetNameById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetNameById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = carModel.SelectNameById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
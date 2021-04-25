using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
namespace OldCarApi.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerModel customerModel = new CustomerModel();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = customerModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(CustomerModel objAccount)
        {
            string result = customerModel.Insertdata(objAccount);
            return result;
        }

        [HttpPut]
        public string Put(CustomerModel objAccount)
        {
            string result = customerModel.Updatedata(objAccount);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = customerModel.DeleteData(ID);
            return result;
        }

        [Route("api/Customer/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = customerModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
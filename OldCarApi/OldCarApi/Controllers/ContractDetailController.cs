using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class ContractDetailController : ApiController
    {
        ContractDetailModel contractdetailModel = new ContractDetailModel();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = contractdetailModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(ContractDetailModel objDetailModel)
        {
            string result = contractdetailModel.Insertdata(objDetailModel);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string[] splittedId = ID.Split('-'); 
            string result = contractdetailModel.DeleteData(splittedId[0], splittedId[1]);
            return result;
        }

        [Route("OldCar/ContractDetail/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                string[] splittedId = ID.Split('-');
                DataTable dt = new DataTable();
                dt = contractdetailModel.SelectDataById(splittedId[0], splittedId[1]);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
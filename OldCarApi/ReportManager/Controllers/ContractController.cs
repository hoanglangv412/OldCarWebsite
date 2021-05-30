using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class ContractController : ApiController
    {
        ContractModel contractModel = new ContractModel();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = contractModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(ContractModel objContract)
        {
            string result = contractModel.Insertdata(objContract);
            return result;
        }

        [HttpPut]
        public string Put(ContractModel objContract)
        {
            string result = contractModel.Updatedata(objContract);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = contractModel.DeleteData(ID);
            return result;
        }

        [Route("api/Contract/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = contractModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("api/Contract/selectsellerData/{ID}")]
        [HttpGet]
        public IHttpActionResult selectsellerData(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = contractModel.selectsellerData(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
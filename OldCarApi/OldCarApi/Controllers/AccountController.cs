using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class AccountController : ApiController
    {
        AccountModel accountModel = new AccountModel();

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public string Post(AccountModel objAccount)
        {
            string result = accountModel.Insertdata(objAccount);
            return result;
        }

        [HttpPut]
        public string Put(AccountModel objAccount)
        {
            string result = accountModel.Updatedata(objAccount);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = accountModel.DeleteData(ID);
            return result;
        }

        [Route("OldCar/Account/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("OldCar/Account/GetDataByName/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataByName(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.SearchDataByName(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
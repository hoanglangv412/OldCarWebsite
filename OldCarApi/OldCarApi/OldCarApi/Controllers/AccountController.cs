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
        public HttpResponseMessage Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.Selectalldata();

                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
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
        public HttpResponseMessage GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.SelectDataById(ID);

                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("OldCar/Account/GetDataByName/{ID}")]
        [HttpGet]
        public HttpResponseMessage GetDataByName(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = accountModel.SearchDataByName(ID);

                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
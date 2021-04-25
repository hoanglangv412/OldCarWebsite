using OldCarApi.Models;
using System.Security.Claims;
using System.Web.Http;

namespace OldCarApi.Controllers
{
    public class LoginController : ApiController
    {
        CustomerModel customerModel = new CustomerModel();
        #region Get User Info

        /// <summary>
        /// Get User Info
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("api/user")]
        public IHttpActionResult GetUserInfo()
        {
            var identity = (ClaimsIdentity)User.Identity;
            //DataTable dt = new DataTable();
            //dt = customerModel.SelectDataById(identity.Name);
            //Dictionary<string, string> childRow = new Dictionary<string, string>();
            //Dictionary<string, string> respose = new Dictionary<string, string>();

            ////CustomerModel returnModel = new CustomerModel();
            ////returnModel.Customer_id = (int)dt.Rows[0]["Customer_id"];
            ////returnModel.Customer_avatar = .ToString();
            ////returnModel.Customer_name = dt.Rows[0]["Customer_name"].ToString();
            ////returnModel.Customer_birth = (DateTime)dt.Rows[0]["Customer_birth"];
            ////returnModel.Customer_email = dt.Rows[0]["Customer_email"].ToString();
            ////returnModel.Customer_address = dt.Rows[0]["Customer_address"].ToString();
            ////returnModel.Customer_phone = dt.Rows[0]["Customer_phone"].ToString();
            ////returnModel.Customer_begindate = (DateTime)dt.Rows[0]["Customer_begindate"];
            ////returnModel.Account_name = dt.Rows[0]["Account_name"].ToString();
            ////returnModel.Account_password = dt.Rows[0]["Account_password"].ToString();
            ////returnModel.Account_role = (byte)dt.Rows[0]["Account_role"];
            ////returnModel.Account_lastLogin = (DateTime)dt.Rows[0]["Account_lastLogin"];
            //childRow.Add("Customer_id", dt.Rows[0]["Customer_id"].ToString());
            //childRow.Add("Customer_avatar", dt.Rows[0]["Customer_avatar"].ToString());
            //childRow.Add("Customer_name", dt.Rows[0]["Customer_name"].ToString());
            //childRow.Add("Customer_birth", dt.Rows[0]["Customer_birth"].ToString());
            //childRow.Add("Customer_email", dt.Rows[0]["Customer_email"].ToString());
            //childRow.Add("Customer_phone", dt.Rows[0]["Customer_phone"].ToString());
            //childRow.Add("Customer_begindate", dt.Rows[0]["Customer_begindate"].ToString());
            //childRow.Add("Account_name", dt.Rows[0]["Account_name"].ToString());
            //childRow.Add("Account_password", dt.Rows[0]["Account_password"].ToString());
            //childRow.Add("Account_role", dt.Rows[0]["Account_role"].ToString());
            //childRow.Add("Account_lastLogin", dt.Rows[0]["Account_lastLogin"].ToString());

            return Ok(identity.Name);
        }

        #endregion Get User Info
    }
}
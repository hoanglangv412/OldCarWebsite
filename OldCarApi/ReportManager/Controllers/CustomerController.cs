using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Mail;
using System.Text;

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

        [Route("api/Customer/CheckExist/{ID}")]
        [HttpPost]
        public bool CheckExist(string ID)
        {
            string username = ID.Split(',')[0];
            string password = ID.Split(',')[1];
            CustomerModel customerObj = new CustomerModel();
            customerObj = customerModel.checkExist(username, password);
            if (customerObj.Account_name == null)
            {
                return false;
            }
            return true;
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

        [Route("api/Customer/GetDataByEmail/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataByEmail(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = customerModel.SelectDataByEmail(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("api/Customer/GetDataByPhone/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataByPhone(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = customerModel.SelectDataByNumber(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }


        #region SavePhoto
        [Route("api/Customer/SaveFile")]
        public IHttpActionResult SavePhoto()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                string folder_from_config = ConfigurationManager.AppSettings["FileUploadFolder"].ToString();
                var postedPhoto = httpRequest.Files[0];
                postedPhoto.SaveAs(folder_from_config + "avatar" + "\\" + postedPhoto.FileName);
                return Ok("1-Lưu thành công");
            }
            catch (Exception ex)
            {

                return BadRequest("2-Lưu ảnh thất bại");
            }
        }
        #endregion
        #region SendEmail
        [Route("api/Customer/SendEmail")]
        public IHttpActionResult SendEmail()
        {
            var httpRequest = HttpContext.Current.Request;
            MailMessage message = new MailMessage(httpRequest.Params["FromUser"], httpRequest.Params["ToUser"]);
            string mailbody = httpRequest.Params["EmailContent"];
            message.Subject = httpRequest.Params["EmailSubject"];
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("kieungothekieu@gmail.com", "Anhkieu18");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                return Ok("1-Gửi thành công");
            }

            catch (Exception ex)
            {
                return BadRequest("2-Thất bại");
            }
        }
        #endregion
    }
}
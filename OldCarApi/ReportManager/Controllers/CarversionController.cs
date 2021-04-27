using OldCarApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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

        [Route("api/Carversion/GetDataById/{ID}")]
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


        #region SavePhoto
        [Route("api/Carversion/SaveFile")]
        public IHttpActionResult SavePhoto()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                string folder_from_config = ConfigurationManager.AppSettings["FileUploadFolder"].ToString();
                //var pathFolder = HttpContext.Current.Server.MapPath("D:/kieu/myself-project/Blog-VueJS/OldCarWebsite/OldCarUI/assets/logo");
                //bool IsExist = System.IO.Directory.Exists(pathFolder);
                //if (!IsExist)
                //{
                //    System.IO.Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Blog-VueJS/OldCarWebsite/OldCarUI/assets/logo"));
                //}
                var postedPhoto = httpRequest.Files[0];
                postedPhoto.SaveAs(folder_from_config + "\\" + postedPhoto.FileName);

                return Ok("1-Lưu thành công");
            }
            catch (Exception ex)
            {

                return BadRequest("2-Lưu ảnh thất bại");
            }
        }
        #endregion
    }
}
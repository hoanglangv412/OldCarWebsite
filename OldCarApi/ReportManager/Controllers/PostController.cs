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
    public class PostController : ApiController
    {
        PostModel postModel = new PostModel();
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.Selectalldata();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("api/Post/GetwithoutTOP/")]
        [HttpGet]
        public IHttpActionResult GetwithoutTOP()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.SelectalldatawithoutTOP();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost]
        public string Post(PostModel objPost)
        {
            string result = postModel.Insertdata(objPost);
            return result;
        }

        [HttpPut]
        public string Put(PostModel objPost)
        {
            string result = postModel.Updatedata(objPost);
            return result;
        }

        [HttpDelete]
        public string Delete(string ID)
        {
            string result = postModel.DeleteData(ID);
            return result;
        }


        [Route("api/Post/Selectalldatasortbydate")]
        [HttpGet]
        public IHttpActionResult Selectalldatasortbydate()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.Selectalldatasortbydate();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("api/Post/GetDataById/{ID}")]
        [HttpGet]
        public IHttpActionResult GetDataById(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.SelectDataById(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [Route("api/Post/SelectDataByCustomerId/{ID}")]
        [HttpGet]
        public IHttpActionResult SelectDataByCustomerId(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.SelectDataByCustomerId(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        #region SavePhoto
        [Route("api/Post/SaveMultipleFile")]
        public IHttpActionResult SavePhoto()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                string folder_from_config = ConfigurationManager.AppSettings["FileUploadFolder"].ToString();
                string folderName = folder_from_config + "OldCarPhoto/" + httpRequest.Params["FilePath"];
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                var postedPhoto = httpRequest.Files[0];
                postedPhoto.SaveAs(folderName + "\\" + postedPhoto.FileName);
                return Ok("1-Lưu thành công");
            }
            catch (Exception ex)
            {

                return BadRequest("2-Lưu ảnh thất bại");
            }
        }
        #endregion

        #region SavePhoto
        [Route("api/Post/SelectSoldCount/{ID}")]
        [HttpGet]
        public IHttpActionResult SelectSoldCount(string ID)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.SelectSoldCount(ID);

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        #endregion

        #region SavePhoto
        [Route("api/Post/SelectMostLike/")]
        [HttpGet]
        public IHttpActionResult SelectMostLike()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = postModel.SelectMostLike();

                return Ok(dt);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        #endregion
    }
}
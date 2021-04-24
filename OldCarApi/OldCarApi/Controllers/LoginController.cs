using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace ReportManager.Controllers
{
    public class LoginController : ApiController
    {
        #region Get User Info

        /// <summary>
        /// Get User Info
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OldCar/Login/user")]
        public IHttpActionResult GetUserInfo()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok(identity.Name);
        }

        #endregion Get User Info
    }
}
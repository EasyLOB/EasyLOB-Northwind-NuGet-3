using EasyLOB.WebApi;
using System;
using System.Web.Http;

namespace EasyLOB
{
    [RoutePrefix("api/WebAPI")]
    public class WebAPIController : BaseApi
    {
        #region Methods

        public WebAPIController()
        {
        }

        // api/WebAPI/Echo/VALUE
        [HttpGet]
        [Route("Echo/{value}")]
        public string Echo(string value)
        {
            return String.Format("{0} {1}", value, DateTime.Now);
        }

        // api/WebAPI/EchoAuthorize
        [Authorize]
        [HttpGet]
        [Route("EchoAuthorize/{value}")]
        public string EchoAuthorize(string value)
        {
            return String.Format("{0} {1}", value, DateTime.Now);
        }

        #endregion Methods
    }
}

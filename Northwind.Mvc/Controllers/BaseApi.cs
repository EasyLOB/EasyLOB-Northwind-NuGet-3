using EasyLOB.Environment;
using System.Web.Http;

namespace EasyLOB.WebApi
{
    public class BaseApi : ApiController
    {
        #region Methods ZActionResultApi

        protected ZActionResultApi ActionResultOperationResult(ZOperationResult operationResult)
        {
            AppHelper.Log(operationResult, Request.RequestUri.PathAndQuery);

            return new ZActionResultApi(Request, operationResult);
        }

        #endregion Methods ZActionResultApi
    }
}
using EasyLOB.Environment;
using System.Net;
using System.Web.Mvc;

namespace EasyLOB.Mvc
{
    [Authorize]
    [EasyLOBProfile]
    [NorthwindProfile]
    public class BaseMvc : Controller
    {
        #region Methods

        public BaseMvc()
        {
            IAuthenticationManager AuthenticationManager =
                DependencyResolver.Current.GetService<IAuthenticationManager>();
            ViewBag.Menu = MenuHelper.Menu(AuthenticationManager); // !?!
        }

        protected virtual bool IsValid(ZOperationResult operationResult, string entity)
        {
            ModelState.AddOperationResults(operationResult, entity);

            return ModelState.IsValid;
        }

        #endregion Methods

        #region Methods Controller

        //protected override JsonResult Json(object data)
        //{
        //    return new ZJsonResultMvc
        //    {
        //        Data = data
        //    };
        //}

        //protected override JsonResult Json(object data, JsonRequestBehavior behavior)
        //{
        //    return new ZJsonResultMvc
        //    {
        //        Data = data,
        //        JsonRequestBehavior = behavior
        //    };
        //}

        //protected override JsonResult Json(object data, string contentType)
        //{
        //    return new ZJsonResultMvc
        //    {
        //        Data = data,
        //        ContentType = contentType
        //    };
        //}

        //protected override JsonResult Json(object data, string contentType, JsonRequestBehavior behavior)
        //{
        //    return new ZJsonResultMvc
        //    {
        //        Data = data,
        //        ContentType = contentType,
        //        JsonRequestBehavior = behavior
        //    };
        //}

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding)
        {
            return new ZJsonResultMvc
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding
            };
        }

        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new ZJsonResultMvc
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        #endregion Methods Controller

        #region Methods ZJsonResultMvc

        // Failure

        protected JsonResult JsonResultFailure(ZOperationResult operationResult)
        {
            AppHelper.Log(operationResult, Request.Url.OriginalString);

            return JsonResultFailure(new {
                OperationResult = operationResult
            });
        }

        protected JsonResult JsonResultFailure(ZOperationResult operationResult, string url)
        {
            AppHelper.Log(operationResult, Request.Url.OriginalString);

            return JsonResultFailure(new
            {
                OperationResult = operationResult,
                Url = url
            });
        }

        private JsonResult JsonResultFailure(object data = null)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            if (data != null)
            {
                //return new JsonResult()
                return new ZJsonResultMvc()
                {
                    Data = data,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                //return new JsonResult()
                return new ZJsonResultMvc()
                {
                    Data = false, // ???
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        // Success

        protected JsonResult JsonResultSuccess(ZOperationResult operationResult, string url)
        {
            return JsonResultSuccess(new
            {
                OperationResult = operationResult,
                Url = url
            });
        }

        protected JsonResult JsonResultSuccess(ZOperationResult operationResult, object data = null)
        {
            if (data != null)
            {
                return JsonResultSuccess(data);
            }
            else
            {
                return JsonResultSuccess(new
                {
                    OperationResult = operationResult,
                    Controller = ControllerContext.RouteData.Values["controller"].ToString()
                });
            }
        }

        private JsonResult JsonResultSuccess(object data = null)
        {
            Response.StatusCode = (int)HttpStatusCode.OK;

            if (data != null)
            {
                //return new JsonResult()
                return new ZJsonResultMvc()
                {
                    Data = data,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                //return new JsonResult()
                return new ZJsonResultMvc()
                {
                    Data = true, // ???
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        // ZOperationResult

        protected JsonResult JsonResultOperationResult(ZOperationResult operationResult, object data = null)
        {
            if (operationResult.Ok)
            {
                if (data != null)
                {
                    return JsonResultSuccess(data);
                }
                else
                {
                    return JsonResultSuccess(new { OperationResult = operationResult });
                }
            }
            else
            {
                return JsonResultFailure(operationResult);
            }
        }

        #endregion Methods ZJsonResultMvc

        #region Methods ZView

        // CollectionModel

        protected ViewResult ZView(CollectionModel collectionModel)
        {
            AppHelper.Log(collectionModel.OperationResult, Request.Url.OriginalString);

            return View(collectionModel);
        }

        protected ViewResult ZView(string view, CollectionModel collectionModel)
        {
            AppHelper.Log(collectionModel.OperationResult, Request.Url.OriginalString);

            return View(view, collectionModel);
        }

        protected PartialViewResult ZPartialView(CollectionModel collectionModel)
        {
            AppHelper.Log(collectionModel.OperationResult, Request.Url.OriginalString);

            return PartialView(collectionModel);
        }

        protected PartialViewResult ZPartialView(string partialView, CollectionModel collectionModel)
        {
            AppHelper.Log(collectionModel.OperationResult, Request.Url.OriginalString);

            return PartialView(partialView, collectionModel);
        }

        // ItemModel

        protected ViewResult ZView(ItemModel itemModel)
        {
            AppHelper.Log(itemModel.OperationResult, Request.Url.OriginalString);

            return View(itemModel);
        }

        protected ViewResult ZView(string view, ItemModel itemModel)
        {
            AppHelper.Log(itemModel.OperationResult, Request.Url.OriginalString);

            return View(view, itemModel);
        }

        protected PartialViewResult ZPartialView(ItemModel itemModel)
        {
            AppHelper.Log(itemModel.OperationResult, Request.Url.OriginalString);

            return PartialView(itemModel);
        }

        protected PartialViewResult ZPartialView(string partialView, ItemModel itemModel)
        {
            AppHelper.Log(itemModel.OperationResult, Request.Url.OriginalString);

            return PartialView(partialView, itemModel);
        }

        // LookupModel

        protected PartialViewResult ZPartialView(string partialView, LookupModel lookupModel)
        {
            AppHelper.Log(lookupModel.OperationResult, Request.Url.OriginalString);

            return PartialView(partialView, lookupModel);
        }

        // ReportModelRDL

        protected ViewResult ZView(string view, ReportModelRDL reportModelRDL)
        {
            AppHelper.Log(reportModelRDL.OperationResult, Request.Url.OriginalString);

            return View(view, reportModelRDL);
        }

        // ReportModelRDLC

        protected ViewResult ZView(string view, ReportModelRDLC reportModelRDLC)
        {
            AppHelper.Log(reportModelRDLC.OperationResult, Request.Url.OriginalString);

            return View(view, reportModelRDLC);
        }

        // TaskViewModel

        protected ViewResult ZView(TaskViewModel taskViewModel)
        {
            AppHelper.Log(taskViewModel.OperationResult, Request.Url.OriginalString);

            return View(taskViewModel);
        }

        protected ViewResult ZView(string view, TaskViewModel taskViewModel)
        {
            AppHelper.Log(taskViewModel.OperationResult, Request.Url.OriginalString);

            return View(view, taskViewModel);
        }

        // OperationResult

        protected ViewResult ZViewOperationResult(ZOperationResult operationResult)
        {
            AppHelper.Log(operationResult, Request.Url.OriginalString);

            return View("OperationResult", new OperationResultModel(operationResult));
        }

        #endregion Methods ZView
    }
}
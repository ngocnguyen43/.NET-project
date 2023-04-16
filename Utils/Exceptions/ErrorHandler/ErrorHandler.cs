using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI.Utils.Exceptions;
using WebAPI.Models.Message;
using Newtonsoft.Json;
using WebAPI.Services.interfaces;
using Microsoft.AspNetCore.Mvc.Controllers;
using CoreApiResponse;
using System.Runtime.CompilerServices;
using System.Net;

namespace WebAPI.Utils.Exceptions.ErrorHandler
{
    public class ErrorHandler:BaseController
    {

        public static string Handle(HttpResponse resp, Func<Response> callback)
        {
            Response res;
            try
            {
                res = callback();
                resp.StatusCode = res.meta.GetStatusCode();
            }
            catch (ExceptionBase ex)
            {
                resp.StatusCode = ex.GetStatusCode();
                Meta meta = new Meta.Builder(ex.GetMessage())
                    .WithStatusCode(ex.GetStatusCode())
                    .WithErrorCode(ex.GetErrorCode())
                    .Build();
                res = new Response.Builder(meta).Build();
            }
            //return new ErrorHandler().CustomResult(res.meta.message, res.body.data, (HttpStatusCode)res.meta.GetStatusCode());
            return Newtonsoft.Json.JsonConvert.SerializeObject(res,
                                Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                            });
        }

    }
}

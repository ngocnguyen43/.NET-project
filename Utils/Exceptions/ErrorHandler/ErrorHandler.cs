using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPI.Utils.Exceptions;
using WebAPI.Models.Message;
using Newtonsoft.Json;
using WebAPI.Services.interfaces;

namespace WebAPI.Utils.Exceptions.ErrorHandler
{
    public class ErrorHandler
    {
        public static string Handle(HttpResponse resp, Func<Response> callback)
        {
            Response res;
            try
            {
                res = callback();
                resp.StatusCode = res.GetMeta().GetStatusCode();
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
            return Newtonsoft.Json.JsonConvert.SerializeObject(res,
                                Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore,
                            });
        }
    }
}

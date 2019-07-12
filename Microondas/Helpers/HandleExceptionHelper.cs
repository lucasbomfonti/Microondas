using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Microondas.Helpers
{
    public class HandleExceptionHelper
    {
        private readonly RequestDelegate _next;

        public HandleExceptionHelper(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            HttpStatusCode code;
            object response = new InternalServerErrorResponseModel(exception.Message);

            switch (exception)
            {
                case EntityValidationException _:
                    code = HttpStatusCode.BadRequest;
                    break;

                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response,
                new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
                    Formatting = Formatting.Indented
                }));
        }
    }

    public class InternalServerErrorResponseModel
    {
        public InternalServerErrorResponseModel()
        {
            Message = "An error has occurred, try again later or contact technical support.";
        }

        public InternalServerErrorResponseModel(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
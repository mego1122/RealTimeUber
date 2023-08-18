using AutoMapper;
using Azure;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealTimeUber.GenericResponse;
using RealTimeUber.Models;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace RealTimeUber.GenericResponse
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        ILoggerManager _logger;

        public ResponseMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var currentBody = context.Response.Body;
                using (var memoryStream = new MemoryStream())
                {
                    if (context.Response.StatusCode != 204)
                    {
                        //set the current response to the memorystream.
                        context.Response.Body = memoryStream;
                        await _next(context);
                        //reset the body 
                        context.Response.Body = currentBody;
                        memoryStream.Seek(0, SeekOrigin.Begin);

                        var readToEnd = new StreamReader(memoryStream).ReadToEnd();
                        var objResult = JsonConvert.DeserializeObject(readToEnd);
                        var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult, null);
                        _logger.LogInfo("____The response___****_" + JsonConvert.SerializeObject(result));
                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    }
                }
            }
            catch (Exception error)
            {
                //var response = context.Response;
                //response.ContentType = "application/json";
                    //switch (error)
                    //{

                    //    case ValidationException:
                    //        // log exception
                    //        response.StatusCode = 400;
                    //        break;

                    //    case KeyNotFoundException:
                    //        // log exception  
                    //        response.StatusCode = 404;
                    //        break;

                    //    default:
                    //        // log exception
                    //        response.StatusCode = 500;
                    //        break;
                    //}

                var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, null, error.Message);

                _logger.LogError("____The Error____****_" + JsonConvert.SerializeObject(result));
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }

        } 
    }

        public static class ResponseMiddlewareExtensions
        {
            public static IApplicationBuilder UseResponseWrapper(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ResponseMiddleware>();
            }
        }


        public class CommonApiResponse
        {
            public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null, string errorMessage = null)
            {
                return new CommonApiResponse(statusCode, result, errorMessage);
            }

            public string Version => "1.2.3";

            public int StatusCode { get; set; }
            public string RequestId { get; }

            public string ErrorMessage { get; set; }

            public object Result { get; set; }

            protected CommonApiResponse(HttpStatusCode statusCode, object result = null, string errorMessage = null)
            {
                RequestId = Guid.NewGuid().ToString();
                StatusCode = (int)statusCode;
                Result = result;
                ErrorMessage = errorMessage;
            }
        }
    }


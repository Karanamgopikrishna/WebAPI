using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace EmployeeServices
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ////Mediatype Formatter with accept headers as only JSON but not XML
            //config.Formatters.Remove(config.Formatters.XmlFormatter);


            ////Mediatype Formatter with accept headers as only JSON but not XML
           // config.Formatters.Remove(config.Formatters.JsonFormatter);


            ////Mediatype Formatter with accept headers as only html i.e text/html
           // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));


            ///Register Custom Formatter
           // config.Formatters.Add(new CustomJsonFormatter());


            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }

    public class CustomJsonFormatter : JsonMediaTypeFormatter
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }



}

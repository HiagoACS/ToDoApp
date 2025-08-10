using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Backend
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Configuração do CORS para permitir requisições de qualquer origem
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Filtros globais
            config.Filters.Add(new GlobalExceptionFilter());

            // Rotas de API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AgenciaViagemMVCCsharp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "PessoasSalvar",
                "Pessoas/Savar",
                new { controller = "Pessoas", action = "Salvar"}
                );

            routes.MapRoute(
                "PessoasExcluir",
                "Pessoas/Excluir/:id",
                new { controller = "Pessoas", action = "Excluir", id = 0 }
                );

            routes.MapRoute(
                "PessoasAlterar",
                "Pessoas/Alterar/:id",
                new { controller = "Pessoas", action = "Alterar", id = 0 }
                );

            routes.MapRoute(
                "PessoasAdicionar",
                "Pessoas/Adicionar",
                new { controller = "Pessoas", action = "Adicionar" }
                );




            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

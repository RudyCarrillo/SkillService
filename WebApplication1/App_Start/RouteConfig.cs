using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "routeOne",
               url: "routesDemo/One",
               defaults: new { controller = "RoutesDemo", action = "One" });

            routes.MapRoute(
                name: "routeTwo",
                url: "routesDemo/Two/{donuts}",
                defaults: new { controller = "RoutesDemo", action = "Two", donuts = UrlParameter.Optional });

            routes.MapRoute(
                name: "routeThree",
                url: "routesDemo/Three",
                defaults: new { controller = "RoutesDemo", action = "Three" });

            routes.MapRoute(
                name: "routeFour",
                url: "routesDemo/Four",
                defaults: new { controller = "RoutesDemo", action = "Four" });

            routes.MapRoute(
                name: "login",
                url: "Account/Login",
                defaults: new { controller = "Account", action = "Login" });

            routes.MapRoute(
                name: "register",
                url: "Account/Register",
                defaults: new { controller = "Account", action = "Register" });

            routes.MapRoute(
                name: "createProject",
                url: "routesDemo/CreateProject",
                defaults: new { controller = "RoutesDemo", action = "CreateProject" });

            routes.MapRoute(
                name: "projectResult",
                url: "routesDemo/ProjectResult",
                defaults: new { controller = "RoutesDemo", action = "ProjectResult" });

            routes.MapRoute(
                name: "createEmployee",
                url: "RoutesDemo/CreateEmployee",
                defaults: new { controller = "RoutesDemo", action = "CreateEmployee" });

            routes.MapRoute(
                name: "employeeResult",
                url: "routesDemo/EmployeeResult",
                defaults: new { controller = "RoutesDemo", action = "EmployeeResult" });

            routes.MapRoute(
                name: "createSkill",
                url: "RoutesDemo/CreateSkill",
                defaults: new { controller = "RoutesDemo", action = "CreateSkill" });

            routes.MapRoute(
                name: "skillResult",
                url: "routesDemo/SkillResult",
                defaults: new { controller = "RoutesDemo", action = "SkillResult" });

            routes.MapRoute(
                name: "read",
                url: "routesDemo/Read",
                defaults: new { controller = "RoutesDemo", action = "Read" });

            routes.MapRoute(
                name: "readResult",
                url: "routesDemo/ReadResult/{name}",
                defaults: new { controller = "RoutesDemo", action = "ReadResult", name = UrlParameter.Optional });

            routes.MapRoute(
                name: "update",
                url: "routesDemo/Update",
                defaults: new { controller = "RoutesDemo", action = "Update" });

            routes.MapRoute(
                name: "updateResult",
                url: "routesDemo/UpdateResult",
                defaults: new { controller = "RoutesDemo", action = "UpdateResult" });

            routes.MapRoute(
                name: "delete",
                url: "routesDemo/Delete",
                defaults: new { controller = "RoutesDemo", action = "Delete" });

            routes.MapRoute(
                name: "deleteResult",
                url: "routesDemo/DeleteResult/{name}",
                defaults: new { controller = "RoutesDemo", action = "DeleteResult", name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Home", action = "Index" });
        }
    }
}

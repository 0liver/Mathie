﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Mathie {
	public class RouteConfig {
		public static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute("", "tt/{name}-{id}", new { controller = "Equation", action = "Test", id = UrlParameter.Optional });

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Equation", action = "Index", id = UrlParameter.Optional }
				);
		}
	}
}
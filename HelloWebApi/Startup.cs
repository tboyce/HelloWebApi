﻿using System.Web.Http;
using HelloWebApi.Configuration;
using Owin;

namespace HelloWebApi
{
    /// <summary>
    /// This is the OWIN startup class (located by convention).
    /// </summary>
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            // create a configuration for Web API
            var configuration = new HttpConfiguration();

            // configure routes for Web API
            configuration.MapHttpAttributeRoutes();

            // configure Unity
            UnityConfig.RegisterComponents(configuration);

            // register Web API with OWIN
            appBuilder.UseWebApi(configuration);
        }
    }
}
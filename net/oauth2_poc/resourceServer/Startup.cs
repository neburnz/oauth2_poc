using IdentityServer3.AccessTokenValidation;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace resourceServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                ValidationMode = ValidationMode.ValidationEndpoint,
                RequiredScopes = new[] { "api1" }
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new AuthorizeAttribute());

            app.UseWebApi(config);
        }
    }
}
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authorizationServer
{
    static class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "clientOnly",
                    ClientName = "API1 - Client Only",
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Reference,
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("34E2E487-2954-4CFA-AC52-B6D048AA645D".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "api1"
                    }
                }
            };
        }
    }
}

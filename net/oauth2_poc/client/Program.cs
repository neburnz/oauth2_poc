using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenResponse = GetClientToken();
            CallApi(tokenResponse);
            Console.ReadLine();
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                "http://localhost:5000/connect/token",
                "resourceOwnerPasswordCredentials",
                "095244F8-8125-4F8A-B7D3-5697BB2672FC"
                );

            return client.RequestResourceOwnerPasswordAsync("bob","secret","api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);
            Console.WriteLine(client.GetStringAsync("http://localhost:5863/test").Result);
        }
    }
}

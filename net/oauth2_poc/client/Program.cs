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
                "clientOnly",
                "34E2E487-2954-4CFA-AC52-B6D048AA645D"
                );

            return client.RequestClientCredentialsAsync("api1").Result;
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);
            Console.WriteLine(client.GetStringAsync("http://localhost:5863/test").Result);
        }
    }
}

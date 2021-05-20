using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using IdentityServer4.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace CleanApp.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ApiController
    {
        [HttpGet]
        public async Task<TokenResponse> RequestTokenAsync()
        {
            using var httpClient = new HttpClient();
            var discoveryDoc = httpClient.GetDiscoveryDocumentAsync("https://localhost:44304/.well-known/openid-configuration").Result;

            var tokenResponse = await httpClient.RequestTokenAsync(new TokenRequest
            {
                Address = discoveryDoc.TokenEndpoint,

                ClientId = "cleanapp-api-client",
                ClientSecret = "secret",
                GrantType = GrantType.AuthorizationCode
            });

            return tokenResponse;
        }
    }
}

using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Dashboard.IdentityServer
{
    public static class Config
    {
        public static List<Client> Clients = new List<Client>
        {
            new Client
            {
                ClientId = "vue-client",
                ClientName = "Vue Client",
                AllowedGrantTypes = new List<string> { GrantType.AuthorizationCode },
                ClientSecrets =
                {
                    new Secret("secret")
                },
                Claims = new List<ClientClaim>
                {
                    new ClientClaim("companyName", "John Doe LTD")
                    //more custom claims depending on the logic of the api
                },
                RequirePkce = true,
                RequireClientSecret = false,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,

                //todo: to be added when the js app is ready
                RedirectUris =           { "http://localhost:8080" },
                PostLogoutRedirectUris = { "http://localhost:8080" },
                AllowedCorsOrigins =     { "http://localhost:8080" },

                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "dashboard-api", "write", "read"
                }
            }
        };

        public static List<ApiResource> ApiResources = new List<ApiResource>
        {
            new ApiResource
            {
                Name = "Dashboard.API",
                ApiSecrets = new List<Secret> {new Secret("secret".Sha256())},
                DisplayName = "Dashboard Api",
                Scopes = new List<string>
                {
                    "write",
                    "read",
                    "dashboard-api"
                }
            }
        };

        public static List<IdentityResource> IdentityResources = new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string> { "user", "admin" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes = new List<ApiScope>
        {
            new ApiScope("read"),
            new ApiScope("write"),
            new ApiScope("dashboard-api")
        };
    }
}

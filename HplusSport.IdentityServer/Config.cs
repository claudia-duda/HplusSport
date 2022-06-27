
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace HplusSport.IdentityServer
{
    public class Config
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                     SubjectId = "1144",
                     Username = "macoratti",
                     Password = "numsey",
                     Claims =
                     {
                        new Claim(JwtClaimTypes.Name, "Macoratti Net"),
                        new Claim(JwtClaimTypes.GivenName, "Macoratti"),
                        new Claim(JwtClaimTypes.FamilyName, "Net"),
                        new Claim(JwtClaimTypes.WebSite, "http://macoratti.net"),
                     }
              }
        };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
               new IdentityResources.OpenId(),
               new IdentityResources.Profile(),
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("myApi.read"),
                new ApiScope("myApi.write"),
            };

        public static IEnumerable<ApiResource> Apis
        {
            get
            {
                return new List<ApiResource>
                {
                new ApiResource("hps-api", "H+ Sport API")
                };
            }
        }
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                       ClientId = "client",
                        AllowedScopes = { "hps-api" },

                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("H+ Sport".Sha256())
                        }
                },
            };
        public static IEnumerable<ApiScope> Scopes
        {
            get
            {
                return new List<ApiScope>
                {
                    new ApiScope("hps-api")
                };
            }
        }
    }
}

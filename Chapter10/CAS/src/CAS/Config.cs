using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CAS
{
    public class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
            return new List<Scope>
            {

                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Roles,
                StandardScopes.Email,
                StandardScopes.OfflineAccess,
                new Scope {
                    Name = "vendorManagementAPI",
                    DisplayName = "Vendor API",
                    Description = "Vendor API scope",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim> {
                        new ScopeClaim(JwtClaimTypes.Role)
                    },
                    //ScopeSecrets =  new List<Secret> {
                    //    new Secret("secret".Sha256())
                    //}
                }

            };
        }

        
        public static List<InMemoryUser> GetUsers()
        {
           
            return new List<InMemoryUser>
            {
                new InMemoryUser
                {
                    Subject = "00001",
                    Username = "scott",
                    Password = "password",
                    Claims = new List<Claim>
                    { 
                        new Claim("name", "scott"),
                        new Claim("given_name","scott edward"),
                        new Claim("family_khan", "edward"),
                        new Claim("website", "www.scottdeveloper.com"),
                        new Claim("email", "scott@mailxyz.com"),
                        new Claim("role","admin"),

                    },
                },
                new InMemoryUser
                {
                    Subject = "2",
                    Username = "richard",
                    Password = "password",
                    Claims = new List<Claim> {
                        new Claim("role","user")
                    }

                }
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    ClientName ="MVC Client",
                    //AllowedGrantTypes= GrantTypes.Implicit,
                    AllowedGrantTypes= GrantTypes.Implicit,
                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris= {"http://localhost:5002"},
                    Enabled=true,
                    AccessTokenType=  AccessTokenType.Jwt,
                    AllowedScopes =new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.Email.Name,
                        StandardScopes.OfflineAccess.Name,
                        "role"
                    },
                    AllowAccessToAllScopes=true
                },
                //},
               
                new Client
                {
                    ClientId = "clientApi",
                    ClientName ="Web API Client",
                    ClientSecrets= { new Secret("secretkey".Sha256())},
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    RedirectUris = { "http://localhost:5003/signin-oidc" },
                    PostLogoutRedirectUris= {"http://localhost:5003"},
                    Enabled=true,
                    AccessTokenType=  AccessTokenType.Jwt,
                    AllowedScopes =new List<string>
                    {
                        StandardScopes.OpenId.Name,
                        StandardScopes.Profile.Name,
                        StandardScopes.OfflineAccess.Name,
                        "vendorManagementAPI"
                    }
                }
            };
        }
    }
}


using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4Identity.Core
{
    public class Config
    {
        public static IEnumerable<Scope> GetScopes()
        {
           return new List<Scope>
           {
                new Scope
                {
                    Name = "MVCApp",
                    Description = "MVC Web Application"
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

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    // secret for authentication
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = new List<string>
                    {
                        "MVCApp"
                    }
                }
            };
        }
    }
}

using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TripCompany.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "tripgalleryclientcredentials",
                    ClientName = "Trip Gallery (Client Credentials)",
                    Flow = Flows.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret(TripGallery.Constants.TripGalleryClientSecret.Sha256())
                    },                    
                    AllowAccessToAllScopes = true //Permitindo acesso para todos os scopos
                    //Isso pode ser útil quando você tem vários clientes e você só quer permitir
                    //que um conjunto específico de escopos seja liberado para um cliente específico.

                }
            };
        }


    }
}
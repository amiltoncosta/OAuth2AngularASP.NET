using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TripGallery.MVCClient.Helpers
{
    public static class TripGalleryHttpClient
    {

        public static HttpClient GetClient()
        { 
            HttpClient client = new HttpClient();

            //Client Credendials FLOW
            var accessToken = RequestAccessTokenClientCredentials();
            client.SetBearerToken(accessToken);
           
            client.BaseAddress = new Uri(Constants.TripGalleryAPI);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private static string RequestAccessTokenClientCredentials()
        {
            //Criar um Token Cliente
            var tokenClient = new TokenClient(
                TripGallery.Constants.TripGallerySTSTokenEndpoint,
                "tripgalleryclientcredentials",
                TripGallery.Constants.TripGalleryClientSecret);


            //ask for a token, containing the galleymanagement scope
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("gallerymanagement").Result;

            //decode & write out the token, so we can see what's is iten
            TokenHelper.DecodeAndWrite(tokenResponse.AccessToken);


            //We save the token in a cookie for use later on
            HttpContext.Current.Response.Cookies["TripGalleryCookie"]["acccess_token"] = tokenResponse.AccessToken;


            return tokenResponse.AccessToken;


        }
 
    }
}
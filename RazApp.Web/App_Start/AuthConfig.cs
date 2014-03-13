using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using RazApp.Web.Models;

namespace RazApp.Web
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "481810dc-b86d-4416-8764-fd5d2a4426a5",
                clientSecret: "i7FjTXGVgojTlljo8JIWbysgUuLMQcXZvqD0U3IQ8O0=");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "bWNTanGaIQHc44NS96d9UA",
                consumerSecret: "CcdAjieoOT8ANQUIwl6cAu5eUKLk5nTnsPZ3YWrg");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "",
            //    appSecret: "");

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}

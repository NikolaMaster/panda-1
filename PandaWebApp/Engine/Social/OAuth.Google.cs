using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using PandaDataAccessLayer.Helpers;

namespace PandaWebApp.Engine.Social
{
    public partial class OAuth
    {
        public class Google
        {
            public class AuthModel
            {
                public string ClientId { get; set; }
                public string ClientSecret { get; set; }
                public string RedirectUrl { get; set; }
                public string Code { get; set; }
            }

            public class AccessToken
            {
                [JsonProperty("id_token")]
                public string Id { get; set; }

                [JsonProperty("access_token")]
                public string Token { get; set; }

                [JsonProperty("token_type")]
                public string TokenType { get; set; }

                [JsonProperty("expires_in")]
                public int ExpiresIn { get; set; }
            }

            public class UserInfo
            {
                [JsonProperty("id")]
                public string UserId { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("given_name")]
                public string FirstName { get; set; }

                [JsonProperty("family_name")]
                public string LastName { get; set; }

                [JsonProperty("picture")]
                public string Photo { get; set; }

                [JsonProperty("gender")]
                public string Sex { get; set; }
            }

            public static AuthModel AuthCodesBase
            {
                get
                {
                    return new AuthModel
                    {
                        ClientId = "415265661423.apps.googleusercontent.com",
                        ClientSecret = "MbpPhFMxK9oVl0O3ZLgrVvfS",
                        RedirectUrl = "http://localhost:9630/google-auth"
                    };
                }
            }

            public static string AuthLink()
            {
                var urlBase = "https://accounts.google.com/o/oauth2/auth?";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                    {"scope", "https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile"},
                    {"response_type", "code"},
                };
                return BaseGetLink(urlBase, parameters);
            }

            public static AccessToken GetAccessToken(string code)
            {
                var urlBase = "https://accounts.google.com/o/oauth2/token";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"client_secret", AuthCodesBase.ClientSecret},
                    {"grant_type", "authorization_code"},
                    {"code", code},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                };
                return BasePostJson<AccessToken>(urlBase, parameters);
            }

            public static UserInfo GetAuthUserInfo(string accessToken)
            {
                var urlBase = "https://www.googleapis.com/oauth2/v1/userinfo?";
                var parameters = new Dictionary<string, object>
                {
                    {"access_token", accessToken}
                };
                return BaseGetJson<UserInfo>(urlBase, parameters);
            }
        }
    }
}
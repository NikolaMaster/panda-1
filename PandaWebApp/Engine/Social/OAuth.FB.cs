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
        public class FB
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
                [JsonProperty("access_token")]
                public string Token { get; set; }

                [JsonProperty("expires")]
                public int ExpiresIn { get; set; }
            }

            public class UserInfo
            {
                [JsonProperty("id")]
                public string UserId { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("first_name")]
                public string FirstName { get; set; }

                [JsonProperty("last_name")]
                public string LastName { get; set; }

                [JsonProperty("birthday")]
                public string BirthDate { get; set; }
            }

            public static AuthModel AuthCodesBase
            {
                get
                {
                    return new AuthModel
                    {
                        ClientId = "1444845899074234",
                        ClientSecret = "cfc435f0fb5ba385325de317dcfb8cab",
                        RedirectUrl = "http://localhost:9630/fb-auth"
                    };
                }
            }

            public static string AuthLink()
            {
                var urlBase = "https://www.facebook.com/dialog/oauth?";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                    {"response_type", "code"},
                    {"scope", "email,user_birthday"}
                };
                return BaseGetLink(urlBase, parameters);
            }

            public static AccessToken GetAccessToken(string code)
            {
                var urlBase = "https://graph.facebook.com/oauth/access_token?";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"client_secret", AuthCodesBase.ClientSecret},
                    {"code", code},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                };
                var res = BaseGetLink(urlBase, parameters).HttpGet();
                var terms = res.Split(new []{ '&', '=' });
                return new AccessToken
                {
                    Token = terms[1],
                    ExpiresIn = int.Parse(terms[3])
                };
            }

            public static UserInfo GetAuthUserInfo(string accessToken)
            {
                var urlBase = "https://graph.facebook.com/me?";
                var parameters = new Dictionary<string, object>
                {
                    {"access_token", accessToken}
                };
                return BaseGetJson<UserInfo>(urlBase, parameters);
            }
        }
    }
}
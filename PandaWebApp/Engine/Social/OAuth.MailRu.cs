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
        public class MailRu
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
                [JsonProperty("refresh_token")]
                public string RefreshToken { get; set; }

                [JsonProperty("access_token")]
                public string Token { get; set; }

                [JsonProperty("token_type")]
                public string TokenType { get; set; }

                [JsonProperty("x_mailru_vid")]
                public string XMailRuVid { get; set; }

                [JsonProperty("expires_in")]
                public int ExpiresIn { get; set; }

                [JsonProperty("user_id")]
                public int UserId { get; set; }
            }

            public class UserInfo
            {
                [JsonProperty("uid")]
                public string UserId { get; set; }

                [JsonProperty("email")]
                public string Email { get; set; }

                [JsonProperty("first_name")]
                public string FirstName { get; set; }

                [JsonProperty("last_name")]
                public string LastName { get; set; }

                [JsonProperty("birthday")]
                public string BirthDate { get; set; }

                [JsonProperty("pic_big")]
                public string Photo { get; set; }

                [JsonProperty("sex")]
                public int Sex { get; set; }
            }

            public static AuthModel AuthCodesBase
            {
                get
                {
                    return new AuthModel
                    {
                        ClientId = "710825",
                        ClientSecret = "02c4847d1f872899e1ea29c51a37b43d",
                        RedirectUrl = "http://localhost:9630/mailru-auth"
                    };
                }
            }

            public static string AuthLink()
            {
                var urlBase = "https://connect.mail.ru/oauth/authorize?";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                    {"response_type", "code"},
                };
                return BaseGetLink(urlBase, parameters);
            }

            public static AccessToken GetAccessToken(string code)
            {
                var urlBase = "https://connect.mail.ru/oauth/token";
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
                var urlBase = "http://www.appsmail.ru/platform/api?";
                var parameters = new Dictionary<string, object>
                {
                    {"app_id", AuthCodesBase.ClientId},
                    {"method", "users.getInfo"},
                    {"secure", "1"},
                    {"session_key", accessToken}
                };
                var sign = ParamsString(parameters).Replace("&", "") + AuthCodesBase.ClientSecret;
                sign = Crypt.GetMD5Hash(sign);
                parameters.Add("sig", sign);
                BaseGetJson<UserInfo[]>(urlBase, parameters).First();
                return BaseGetJson<UserInfo[]>(urlBase, parameters).First();
            }
        }
    }
}
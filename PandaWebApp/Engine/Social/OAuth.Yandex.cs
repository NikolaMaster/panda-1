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
        public class Yandex
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

                [JsonProperty("token_type")]
                public string TokenType { get; set; }
            }

            public class UserInfo
            {
                [JsonProperty("id")]
                public int UserId { get; set; }

                [JsonProperty("default_email")]
                public string Email { get; set; }

                [JsonProperty("real_name")]
                public string LastName { get; set; }

                [JsonProperty("birthday")]
                public string BirthDate { get; set; }

                [JsonProperty("sex")]
                public string Sex { get; set; }
            }

            public static AuthModel AuthCodesBase
            {
                get
                {
                    return new AuthModel
                    {
                        ClientId = "8fcaf245f46d4e64b3e7c68c904ea01e",
                        ClientSecret = "35ab96e95bd243a7b2c7aaaaa3b00a90",
                        RedirectUrl = "http://localhost:9630/yandex-auth"
                    };
                }
            }

            public static string AuthLink()
            {
                var urlBase = "https://oauth.yandex.ru/authorize?";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"display", "popup"},
                    {"response_type", "code"},
                };
                return BaseGetLink(urlBase, parameters);
            }

            public static AccessToken GetAccessToken(string code)
            {
                var urlBase = "https://oauth.yandex.ru/token";
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"client_secret", AuthCodesBase.ClientSecret},
                    {"grant_type", "authorization_code"},
                    {"code", code}
                };
                return BasePostJson<AccessToken>(urlBase, parameters);
            }

            public static UserInfo GetAuthUserInfo(string accessToken)
            {
                var urlBase = "https://login.yandex.ru/info?";
                var parameters = new Dictionary<string, object>
                {
                    {"format", "json"},
                    {"oauth_token", accessToken},
                };
                return BaseGetJson<UserInfo>(urlBase, parameters);
            }
        }
    }
}
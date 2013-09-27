using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PandaWebApp.Engine.Social
{
    public partial class OAuth
    {
        public class Vk
        {
            public const string AuthUrlPrefix = "https://oauth.vk.com/";
            public const string ApiUrlPrefix = "https://api.vk.com/method/";
            public const string AuthAction = "authorize?";
            public const string GetAccessTokenAction = "access_token?";

            public struct AuthModel
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

                [JsonProperty("expires_in")]
                public int ExpiresIn { get; set; }

                [JsonProperty("user_id")]
                public int UserId { get; set; }
            }

            public class UserInfo
            {
                public class Response
                {
                    [JsonProperty("uid")]
                    public int UserId { get; set; }

                    [JsonProperty("first_name")]
                    public string FirstName { get; set; }

                    [JsonProperty("last_name")]
                    public string LastName { get; set; }

                    [JsonProperty("screen_name")]
                    public string ScreenName { get; set; }

                    [JsonProperty("bdate")]
                    public string BirthDate { get; set; }

                    [JsonProperty("photo_big")]
                    public string Photo { get; set; }

                    [JsonProperty("sex")]
                    public int Sex { get; set; }
                }

                [JsonProperty("response")]
                public Response[] Info { get; set; }
            }

            public static AuthModel AuthCodesBase
            {
                get
                {
                    return new AuthModel
                    {
                        ClientId = "3900443",
                        ClientSecret = "ymj7NcIctrk1HmIVDA5s",
                        RedirectUrl = "http://localhost:9630/vk-auth"
                    };
                }
            }

            public static string AuthLink()
            {
                var urlBase = AuthUrlPrefix + AuthAction;
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
                var urlBase = AuthUrlPrefix + GetAccessTokenAction;
                var parameters = new Dictionary<string, object>
                {
                    {"client_id", AuthCodesBase.ClientId},
                    {"client_secret", AuthCodesBase.ClientSecret},
                    {"code", code},
                    {"redirect_uri", AuthCodesBase.RedirectUrl},
                };
                return BaseGetJson<AccessToken>(urlBase, parameters);
            }

            public static UserInfo GetAuthUserInfo(int userId, string accessToken)
            {
                var urlBase = ApiUrlPrefix + "users.get?";
                var parameters = new Dictionary<string, object>
                {
                    {"uids", userId},
                    {"fields", "uid,first_name,last_name,screen_name,sex,bdate,photo_big"},
                    {"access_token", accessToken}
                };
                return BaseGetJson<UserInfo>(urlBase, parameters);
            }
        }
    }
}
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Helpers;
using PandaWebApp.Engine.Binders;
using PandaWebApp.Engine.Social;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine
{
    public class AuthorizationCore
    {

        public AuthorizationCore()
        {
        }

        private const string SessionKey = "PandaAuthorizationCoreSessionKey";

        public Guid SessionId
        {
            get
            {
                var obj = HttpContext.Current.Session[SessionKey];
                return obj is Guid ? (Guid)obj : Guid.Empty;
            }
            set
            {
                HttpContext.Current.Session[SessionKey] = value;
            }
        }

        private UserBase _mCachedUser;
        private Session _mCachedSession;

        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string City { get; set; }

        public UserBase User 
        { 
            get 
            {
                if (_mCachedUser == null)
                {
                    if (SessionId == Guid.Empty)
                    {
                        //TODO - Guest
                        _mCachedUser = new PromouterUser();
                        _mCachedUser.Id = Guid.Empty;
                    }
                    else
                    {
                        using (var dal = new DataAccessLayer())
                        {
                            _mCachedSession = dal.GetById<Session>(SessionId);
                            if (_mCachedSession == null)
                            {
                                throw new Exception("Bad session");
                            }
                            //set current user
                            _mCachedUser = _mCachedSession.User;

                            UserName = dal.GetUserName(_mCachedUser);

                            var cityAttr = dal.GetAttributeValue(_mCachedUser.MainChecklist.Id, Constants.CityCode);
                            City = cityAttr.Value ?? string.Empty;

                            var firstNameAttr = dal.GetAttributeValue(_mCachedUser.MainChecklist.Id, Constants.FirstNameCode);
                            FirstName = firstNameAttr.Value ?? string.Empty;

                            var lastNameAttr = dal.GetAttributeValue(_mCachedUser.MainChecklist.Id, Constants.LastNameCode);
                            LastName = lastNameAttr.Value ?? string.Empty;
                            //update last hit field
                            dal.UpdateById<Session>(_mCachedSession.Id, x => x.LastHit = DateTime.UtcNow);
                            dal.DbContext.SaveChanges();
                        }
                    }
                }
                return _mCachedUser;
            } 
        }
        public Session Session
        {
            get
            {
                if (_mCachedSession == null)
                {
                    using (var dal = new DataAccessLayer())
                    {
                        _mCachedSession = dal.GetById<Session>(SessionId);
                    }
                }
                return _mCachedSession;
            }
        }
        public bool IsAdmin
        {
            get
            {
                return !IsGuest && User.IsAdmin;
            }
        }
        public bool IsGuest
        {
            get
            {
                return User.Id == Guid.Empty;
            }
        }

        public bool IsPromouter
        {
            get
            {
                return User is PromouterUser;
            }
        }

        public bool IsEmployer
        {
            get
            {
                return User is EmployerUser;
            }
        }

        public string UserController
        {
            get
            {
                return User.ControllerNameByUser();
            }
        }

        public int FavoritesCount
        {
            get
            {
                using (var dal = new DataAccessLayer())
                {
                    return dal.GetUserFavorites(User.Id).Count();
                }
            }
        }

        public int BrowsingValuesCount
        {
            get
            {
                using (var dal = new DataAccessLayer())
                {
                    return dal.GetAllBrowsingValuesCount(User.Id);
                }
            }
        }

        public bool Login(string email, string password)
        {
            using (var dal = new DataAccessLayer())
            {
                var users = dal.Get<UserBase>(x => x.Email == email);//.DefaultIfEmpty();

                var userBases = users as UserBase[] ?? users.ToArray();
                if (!userBases.Any())
                {
                    return false;
                }

                UserBase user = null;
                foreach (var iter in userBases)
                {
                    var passw = Password.MakePassword(password, iter.CreationDate);

                    if (Equals(iter.Email, email) && Equals(iter.Password, passw))
                    {
                        user = iter;
                        break;
                    }
                }
                

                if (user == null)
                {
                    return false;
                }

                Auth(user, dal);
            }
            return true;
        }

        private void Auth(UserBase user, DataAccessLayer dal)
        {
            _mCachedUser = user;
            _mCachedSession = dal.Create(new Session {User = _mCachedUser, LastHit = DateTime.UtcNow});
            var pulse = dal.Create(new Pulse
            {
                Operation = dal.Get<DictValue>(Constants.Login),
                UserId = _mCachedUser.Id,
            });
            _mCachedUser.Pulse = new List<Pulse> {pulse};
            dal.DbContext.SaveChanges();

            //remember session id
            SessionId = _mCachedSession.Id;
        }

        #region Social logins [TODO make it more abstract]

        public void LoginVk(OAuth.Vk.UserInfo userInfo)
        {
            var mainInfo = userInfo.Info.First();
            //check if user exists
            using (var dal = new DataAccessLayer())
            {
                UserBase user = dal.Get<UserBase>(x => x.VkId == mainInfo.UserId).FirstOrDefault();

                if (user == null)
                {
                    user = RegisterPromouter(new PromouterRegister(), dal);
                    user.VkId = mainInfo.UserId;
                    var mainAlbum = user.Albums.First();
                    var avatar = dal.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = ImageCreator.SavePhoto(mainInfo.Photo)
                    });
                    user.Avatar = avatar;

                    DateTime birthday;

                    dal.Update(user.MainChecklist, new List<AttribValue>
                    {
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.LastNameCode),
                            Value = mainInfo.LastName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.FirstNameCode),
                            Value = mainInfo.FirstName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.DateOfBirthCode),
                            Value = DateTime.TryParse(mainInfo.BirthDate, out birthday) ? birthday.ToPandaString() : null
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.GenderCode),
                            Value = mainInfo.Sex == 2 ? Constants.MaleCode :
                                    mainInfo.Sex == 1 ? Constants.FemaleCode : null
                        },
                    });
                    dal.DbContext.SaveChanges();
                    //TODO photo and info
                }
                Auth(user, dal);
            }
        }

        public void LoginFb(OAuth.FB.UserInfo userInfo)
        {
            var mainInfo = userInfo;
            //check if user exists
            using (var dal = new DataAccessLayer())
            {
                var user = dal.Get<UserBase>(x => x.FbId == mainInfo.UserId).FirstOrDefault();

                if (user == null)
                {
                    user = RegisterPromouter(new PromouterRegister(), dal);
                    user.FbId = mainInfo.UserId;
                    user.Email = mainInfo.Email;
                    DateTime birthday;

                    dal.Update(user.MainChecklist, new List<AttribValue>
                    {
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.LastNameCode),
                            Value = mainInfo.LastName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.FirstNameCode),
                            Value = mainInfo.FirstName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.DateOfBirthCode),
                            Value = DateTime.TryParse(mainInfo.BirthDate, out birthday) ? birthday.ToPandaString() : null
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.EmailCode),
                            Value = mainInfo.Email
                        },
                     new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.GenderCode),
                            Value = mainInfo.Sex == "male" ? Constants.MaleCode :
                                    mainInfo.Sex == "female" ? Constants.FemaleCode : null
                        },
                    });

                    dal.DbContext.SaveChanges();
                    //TODO photo and info
                }
                Auth(user, dal);
            }
        }

        public void LoginGoogle(OAuth.Google.UserInfo userInfo)
        {
            var mainInfo = userInfo;
            //check if user exists
            using (var dal = new DataAccessLayer())
            {
                var user = dal.Get<UserBase>(x => x.GoogleId == mainInfo.UserId).FirstOrDefault();

                if (user == null)
                {
                    user = RegisterPromouter(new PromouterRegister(), dal);
                    user.GoogleId = mainInfo.UserId;
                    user.Email = mainInfo.Email;
                    var mainAlbum = user.Albums.First();
                    var avatar = dal.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = ImageCreator.SavePhoto(mainInfo.Photo)
                    });
                    user.Avatar = avatar;

                    dal.Update(user.MainChecklist, new List<AttribValue>
                    {
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.LastNameCode),
                            Value = mainInfo.LastName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.FirstNameCode),
                            Value = mainInfo.FirstName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.EmailCode),
                            Value = mainInfo.Email
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.GenderCode),
                            Value = mainInfo.Sex == "male" ? Constants.MaleCode :
                                    mainInfo.Sex == "female" ? Constants.FemaleCode : null
                        },
                    });

                    dal.DbContext.SaveChanges();
                    //TODO photo and info
                }
                Auth(user, dal);
            }
        }

        public void LoginYandex(OAuth.Yandex.UserInfo userInfo)
        {
            var mainInfo = userInfo;
            //check if user exists
            using (var dal = new DataAccessLayer())
            {
                var user = dal.Get<UserBase>(x => x.YandexId == mainInfo.UserId).FirstOrDefault();

                if (user == null)
                {
                    user = RegisterPromouter(new PromouterRegister(), dal);
                    user.YandexId = mainInfo.UserId;
                    user.Email = mainInfo.Email;

                    DateTime birthday;

                    dal.Update(user.MainChecklist, new List<AttribValue>
                    {
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.LastNameCode),
                            Value = mainInfo.LastName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.DateOfBirthCode),
                            Value = DateTime.TryParse(mainInfo.BirthDate, out birthday) ? birthday.ToPandaString() : null
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.EmailCode),
                            Value = mainInfo.Email
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.GenderCode),
                            Value = mainInfo.Sex == "male" ? Constants.MaleCode :
                                    mainInfo.Sex == "female" ? Constants.FemaleCode : null
                        },
                    });
                    dal.DbContext.SaveChanges();
                    //TODO photo and info
                }
                Auth(user, dal);
            }
        }

        public void LoginMail(OAuth.MailRu.UserInfo userInfo)
        {
            var mainInfo = userInfo;
            //check if user exists
            using (var dal = new DataAccessLayer())
            {
                var user = dal.Get<UserBase>(x => x.MailId == mainInfo.UserId).FirstOrDefault();

                if (user == null)
                {
                    user = RegisterPromouter(new PromouterRegister(), dal);
                    user.MailId = mainInfo.UserId;
                    user.Email = mainInfo.Email;
                 
                    var mainAlbum = user.Albums.First();
                    var avatar = dal.Create(new Photo()
                    {
                        Album = mainAlbum,
                        SourceUrl = ImageCreator.SavePhoto(mainInfo.Photo)
                    });
                    user.Avatar = avatar;

                    DateTime birthday;

                    dal.Update(user.MainChecklist, new List<AttribValue>
                    {
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.LastNameCode),
                            Value = mainInfo.LastName
                        },
                   new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.FirstNameCode),
                            Value = mainInfo.FirstName
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.DateOfBirthCode),
                            Value = DateTime.TryParse(mainInfo.BirthDate, out birthday) ? birthday.ToPandaString() : null
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.EmailCode),
                            Value = mainInfo.Email
                        },
                        new AttribValue
                        {
                            Attrib = dal.Get<Attrib>(Constants.GenderCode),
                            Value = mainInfo.Sex == 0 ? Constants.MaleCode :
                                    mainInfo.Sex == 1 ? Constants.FemaleCode : null
                        },
                    });
                    dal.DbContext.SaveChanges();
                    //TODO photo and info
                }
                Auth(user, dal);
            }
        }

        #endregion

        public PromouterUser RegisterPromouter(PromouterRegister model, DataAccessLayer dal)
        {            
            {
                var binder = new PromouterRegisterToPromouterUser(dal);
                var user = dal.Create(new PromouterUser());
                binder.Load(model, user);
                dal.DbContext.SaveChanges();
                return user;
            }
        }

        public void Logout()
        {
            using (var dal = new DataAccessLayer())
            {
                var pulse = dal.Create(new Pulse
                {
                    Operation = dal.Get<DictValue>(Constants.Logout),
                    UserId = User.Id,
                });
                User.Pulse = new List<Pulse> { pulse };
                dal.DeleteById<Session>(_mCachedSession.Id);
                dal.DbContext.SaveChanges();
                SessionId = Guid.Empty;
            }
        }

        public static AuthorizationCore StaticCreate()
        {
            return new AuthorizationCore();
        }
    }
}
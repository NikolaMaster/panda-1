﻿using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                            City = cityAttr.Value != null ? cityAttr.Value.ToString() : string.Empty;
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

        public bool Login(string email, string password)
        {
            using (var dal = new DataAccessLayer())
            {
                var user = dal.Get<UserBase>().FirstOrDefault(x => x.Email == email && x.Password == password);
                if (user == null)
                {
                    return false;
                }

                _mCachedUser = user;
                _mCachedSession = dal.Create(new Session { User = _mCachedUser, LastHit = DateTime.UtcNow });
                dal.DbContext.SaveChanges();

                //remember session id
                SessionId = _mCachedSession.Id;
            }
            return true;
        }

        public void Logout()
        {
            SessionId = Guid.Empty;
        }

        public static AuthorizationCore StaticCreate()
        {
            return new AuthorizationCore();
        }
    }
}
﻿using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public partial class DataAccessLayer : DataAccessLayerBase<MainDbContext>
    {
        private const string MainAlbumName = "Основной альбом";
        private const int OnlineTimeout = 2 * 60;

        public PromouterUser Create(PromouterUser user)
        {
            if (user.SeoEntry == null)
            {
                user.SeoEntry = Create(new SeoEntry { });
            }
            if (user.Checklists.Count == 0)
            {
                Create(user, new List<AttribValue>());
            }
            if (user.Albums.Count == 0)
            {
                Create(new Album()
                {
                    Name = MainAlbumName,
                    User = user,
                });
            }
            if (user.Avatar == null)
            {
                user.Avatar = Constants.DefaultAvatar;
            }
            DbContext.Users.Add(user);
            return user;
        }

        public EmployerUser Create(EmployerUser user)
        {
            if (user.SeoEntry == null)
            {
                user.SeoEntry = Create(new SeoEntry { });
            }
            if (user.Checklists.Count == 0)
            {
                Create(user, Constants.EmployerMainChecklistType, new List<AttribValue>());
            }
            if (user.Albums.Count == 0)
            {
                user.Albums.Add(Create(new Album()
                {
                    Name = MainAlbumName,
                    User = user,
                }));
            }
            if (user.Avatar == null)
            {
                user.Avatar = Constants.DefaultAvatar;
            }
            DbContext.Users.Add(user);
            return user;
        }

        public int OnlineUsers()
        {
            return DbContext.Users.Count(x => x.Sessions.Any(y => EntityFunctions.DiffSeconds(DateTime.UtcNow, y.LastHit) < OnlineTimeout));
        }

        public string GetPulseUserName(UserBase user)
        {
            var promouter = user as PromouterUser;
            var employer = user as EmployerUser;

            if (promouter != null)
            {
                var firstName = GetAttributeValue(promouter.MainChecklist.Id, Constants.FirstNameCode);
                var middleName = GetAttributeValue(promouter.MainChecklist.Id, Constants.MiddleNameCode);
                return string.Format("{0} {1}", firstName.Value, middleName.Value);
            }

            if (employer != null)
            {
                var employerName = GetAttributeValue(employer.MainChecklist.Id, Constants.EmployerNameCode);
                return employerName.Value;
            }

            throw new Exception("Incorrect user type");
        }

        public string GetUserName(UserBase user)
        {
            var promouter = user as PromouterUser;
            var employer = user as EmployerUser;

            if (promouter != null)
            {
                var lastName = GetAttributeValue(promouter.MainChecklist.Id, Constants.LastNameCode);
                var firstName = GetAttributeValue(promouter.MainChecklist.Id, Constants.FirstNameCode);
                var middleName = GetAttributeValue(promouter.MainChecklist.Id, Constants.MiddleNameCode);
                return string.Format("{0} {1} {2}", lastName.Value, firstName.Value, middleName.Value);
            }

            if (employer != null)
            {
                var employerName = GetAttributeValue(employer.MainChecklist.Id, Constants.EmployerNameCode);
                return employerName.Value;
            }

            throw new Exception("Incorrect user type");
        }

    }
}

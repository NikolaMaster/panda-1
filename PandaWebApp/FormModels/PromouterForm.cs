﻿using System.Globalization;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PandaWebApp.FormModels
{

    public class PromouterForm
    {
        public class DesiredWorkTimeUnit
        {
            public Guid Id { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string DayOfWeek { get; set; }
            public DateTime CreationDate { get; set; }

            public static IEnumerable<SelectListItem> WorkDaysValues {
                get
                {
                    var counter = 0;
                    return new[]
                    {
                        "Понедельник",
                        "Вторник",
                        "Среда",
                        "Четверг",
                        "Пятница",
                        "Суббота",
                        "Воскресенье"
                    }
                    .Select(x => new SelectListItem
                    {
                        Text = x,
                        Value = (counter++).ToString(CultureInfo.InvariantCulture)
                    });
                }
            }
        }

        public class DesiredWorkUnit
        {
            public string Title { get; set; }
            public string Code { get; set; }
            public bool Value { get; set; }
        }

        public class WorkExperienceUnit
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string WorkName { get; set; }
            public int Hours { get; set; }
            public DateTime CreationDate { get; set; }
        }

        public Guid UserId { get; set; }

        public string Icon { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Education { get; set; }
        public string Salary { get; set; }
        public string Build { get; set; }
        public string SkinType { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string HairLength { get; set; }
        public string SizeClothes { get; set; }
        public string SizeShoes { get; set; }
        public string SizeChest { get; set; }
        public string Hobbies { get; set; }
        public string About { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public bool MedicalBook { get; set; }
        public bool Car { get; set; }
        public bool RollerSkates { get; set; }
        public bool WinterSkates { get; set; }
        public bool ReadyForWork { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime BirthDate { get; set; }

        public IEnumerable<HttpPostedFileBase> NewPhotos { get; set; }

        public IList<AlbumUnit> Albums { get; set; }

        public IList<DesiredWorkTimeUnit> DesiredWorkTime { get; set; }
        public IList<WorkExperienceUnit> WorkExperience { get; set; }
        public IList<DesiredWorkUnit> DesiredWork { get; set; }

        public IList<SelectListItem> SalaryValues { get; set; }
        public IList<SelectListItem> EducationValues { get; set; }
        public IList<SelectListItem> GenderValues { get; set; }
        public IList<SelectListItem> CityValues { get; set; }

        public static PromouterForm Bind(DataAccessLayer dataAccessLayer, Guid userId)
        {
            var binder = new FormPromouterToUsers(dataAccessLayer);
            var user = dataAccessLayer.GetById<PromouterUser>(userId);
            var model = new PromouterForm();
            binder.InverseLoad(user, model);
            return model;
        }
    }
}
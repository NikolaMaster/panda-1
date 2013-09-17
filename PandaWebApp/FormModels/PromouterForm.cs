﻿using System.Globalization;
using System.Web;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PandaWebApp.ViewModels;

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

        [ValueFrom(Constants.FirstNameCode)]
        public string FirstName { get; set; }
        [ValueFrom(Constants.LastNameCode)]
        public string LastName { get; set; }
        [ValueFrom(Constants.MiddleNameCode)]
        public string MiddleName { get; set; }
        [ValueFrom(Constants.GenderCode)]
        public string Gender { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.EducationCode)]
        public string Education { get; set; }
        [ValueFrom(Constants.SalaryCode)]
        public string Salary { get; set; }
        [ValueFrom(Constants.BuildCode)]
        public string Build { get; set; }
        [ValueFrom(Constants.SkinTypeCode)]
        public string SkinType { get; set; }
        [ValueFrom(Constants.EyeColorCode)]
        public string EyeColor { get; set; }
        [ValueFrom(Constants.HairColorCode)]
        public string HairColor { get; set; }
        [ValueFrom(Constants.HairLengthCode)]
        public string HairLength { get; set; }
        [ValueFrom(Constants.SizeClothesCode)]
        public string SizeClothes { get; set; }
        [ValueFrom(Constants.SizeShoesCode)]
        public string SizeShoes { get; set; }
        [ValueFrom(Constants.SizeChestCode)]
        public string SizeChest { get; set; }
        [ValueFrom(Constants.HobbiesCode)]
        public string Hobbies { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }
        [ValueFrom(Constants.CarCode)]
        public string Car { get; set; }

        [ValueFrom(Constants.WeightCode)]
        public int Weight { get; set; }
        [ValueFrom(Constants.HeightCode)]
        public int Height { get; set; }

        [ValueFrom(Constants.MedicalBookCode)]
        public bool MedicalBook { get; set; }
        [ValueFrom(Constants.RollerSkatesCode)]
        public bool RollerSkates { get; set; }
        [ValueFrom(Constants.WinterSkatesCode)]
        public bool WinterSkates { get; set; }
        [ValueFrom(Constants.ReadyForWorkCode)]
        public bool ReadyForWork { get; set; }
        [ValueFrom(Constants.DateOfBirthCode)]
        public DateTime BirthDate { get; set; }

        public Guid UserId { get; set; }

        public string Icon { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public PhoneUnit Phone { get; set; }

        public IEnumerable<HttpPostedFileBase> NewPhotos { get; set; }

        public IList<AlbumUnit> Albums { get; set; }

        public IList<DesiredWorkTimeUnit> DesiredWorkTime { get; set; }
        public IList<WorkExperienceUnit> WorkExperience { get; set; }
        public IList<DesiredWorkUnit> DesiredWork { get; set; }

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
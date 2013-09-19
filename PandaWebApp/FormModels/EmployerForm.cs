using System.Globalization;
using System.Web.Mvc;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using PandaWebApp.Engine.Binders;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.FormModels
{
    public class EmployerForm
    {
        public class VacancyUnit
        {
            [ValueFrom(Constants.StartWorkCode)]
            public DateTime? StartTime { get; set; }
            [ValueFrom(Constants.EndWorkCode)]
            public DateTime? EndTime { get; set; }
            [ValueFrom(Constants.WorkCode)]
            public string Work { get; set; }
            [ValueFrom(Constants.SalaryCode)]
            public string Salary { get; set; }
            [ValueFrom(Constants.AboutCode)]
            public string FullDescription { get; set; }
            [ValueFrom(Constants.CityCode)]
            public string City { get; set; }
            [ValueFrom(Constants.GenderCode)]
            public string Gender { get; set; }

            public Guid Id { get; set; }
            public string DaysOnSite { get; set; }
            public DateTime CreationDate { get;set; }

            public VacancyUnit()
            {
                StartTime = null;
                EndTime = null;
            }
        }


        [ValueFrom(Constants.EmployerNameCode)]
        public string EmployerName { get; set; }
        [ValueFrom(Constants.CityCode)]
        public string City { get; set; }
        [ValueFrom(Constants.AboutCode)]
        public string About { get; set; }
        [ValueFrom(Constants.AddressCode)]
        public string Address { get; set; }

        public Guid UserId { get; set; }

        public int Number { get; set; }
        public int DaysOnSite { get; set; }
        public bool IsAdmin { get; set; }
        public bool AccountConfirmed { get; set; }

        public string Icon { get; set; }
        public string Status { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }

        public IEnumerable<PhotoUnit> NewPhotos { get; set; }
        public Guid UploadedPhotoId { get; set; }

        public PhoneUnit Phone { get; set; }
        public IList<AlbumUnit> Albums { get; set; }
        public IList<VacancyUnit> Vacancies { get; set; }

        public static EmployerForm Bind(DataAccessLayer dataAccessLayer, Guid userId)
        {
            var binder = new FormEmployerToUser(dataAccessLayer);
            var user = dataAccessLayer.GetById<EmployerUser>(userId);
            var model = new EmployerForm();
            binder.InverseLoad(user, model);
            return model;
        }
    }
}
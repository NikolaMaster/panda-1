﻿using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public class Constants
    {
        public const string PromouterChecklistTypeCode = "Promouter";
        public const string EmployerChecklistTypeCode = "Employer";
        public const string DefaultAvatarImage = "motorcycle.jpeg";
        public const string DesiredWorkCode = "DESIRED_WORK";
        public const string CityCode = "CITY";
        public const string GenderCode = "GENDER";
        public const string SalaryCode = "SALARY";
        public const string EmployerNameCode = "EMPLOYER_NAME";
        public const string VacancyCode = "VACANCY";
        public const string EducationCode = "EDUCATION";

        public DataAccessLayer DataAccessLayer { get;private set; }

        private Constants() { }

        internal Constants(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        }

        public Photo DefaultAvatar
        {
            get { return DataAccessLayer.DbContext.Set<Photo>().Single(x => x.SourceUrl == DefaultAvatarImage); }
        }

        public ChecklistType PromouterChecklistType 
        {
            get { return DataAccessLayer.Get<ChecklistType>(PromouterChecklistTypeCode); }
        }

        public ChecklistType EmployerChecklistType
        {
            get { return DataAccessLayer.Get<ChecklistType>(EmployerChecklistTypeCode); }
        }

        
        public Attrib DesiredWork 
        {
            get { return DataAccessLayer.Get<Attrib>(DesiredWorkCode); }
        }

        public Attrib City 
        {
            get { return DataAccessLayer.Get<Attrib>(CityCode); }
        }

        public Attrib Gender 
        {
            get { return DataAccessLayer.Get<Attrib>(GenderCode); }
        }

        public Attrib Salary 
        {
            get { return DataAccessLayer.Get<Attrib>(SalaryCode); }
        }

        public Attrib EmployerName 
        {
            get { return DataAccessLayer.Get<Attrib>(EmployerNameCode); }
        }

        public Attrib Vacancy
        {
            get { return DataAccessLayer.Get<Attrib>(VacancyCode); }
        }

        public Attrib Education 
        {
            get { return DataAccessLayer.Get<Attrib>(EducationCode); }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.FormModels
{
    public class PhotoForm
    {
        public string Id { get; set; }
        public string SourceUrl { get; set; }
        public string Controller { get; set; }
        public Guid UserId { get; set; }
        public int x1 { get; set; }
        public int y1 { get; set; }
        public int x2 { get; set; }
        public int y2 { get; set; }
    }
}
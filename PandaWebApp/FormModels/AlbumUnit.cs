using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaDataAccessLayer.Entities;

namespace PandaWebApp.FormModels
{
    public class AlbumUnit
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public IList<Photo> Photos { get; set; }
        public Photo Avatar { get; set; }
    }
}
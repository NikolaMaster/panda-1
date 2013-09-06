using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Editors
{
    public class BaseEditor
    {
        public DataAccessLayer DataAccessLayer { get; protected set; }

        public BaseEditor(DataAccessLayer dataAccessLayer)
        {
            DataAccessLayer = dataAccessLayer;
        } 
    }
}
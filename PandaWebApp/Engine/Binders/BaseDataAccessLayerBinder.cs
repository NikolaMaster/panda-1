using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public abstract class BaseDataAccessLayerBinder<TSource, TDest> : BaseBinder<TSource, TDest>
    {
        public DataAccessLayer DataAccessLayer { get; protected set; }

        private BaseDataAccessLayerBinder() { }

        public BaseDataAccessLayerBinder(DataAccessLayer dataAccessLayer) 
        {
            DataAccessLayer = dataAccessLayer;
        }
    }
}
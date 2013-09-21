using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWebApp.FormModels;

namespace PandaWebApp.Engine
{
    public class Paginator<T> : IPaginators
    {
        public IEnumerable<T> Collection { get; private set; }

        public PagerFormModel Pager { get; set; }

        //default values for pager is here
        public Paginator(IEnumerable<T> sourceCollection, int currentPage, int perPage)
        {
            var collection = sourceCollection as T[] ?? sourceCollection.ToArray();

            Pager = new PagerFormModel
            {
                Page = currentPage,
                PerPage = perPage,
                Total = collection.Length,
                TotalPages = collection.Length/perPage + (collection.Length%perPage > 0 ? 1 : 0),
            };

            Collection = collection.Skip((currentPage - 1)*perPage).Take(perPage);
        }
    }
}
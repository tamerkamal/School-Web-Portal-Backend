using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BLL
{
    public static class SortingService
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy, bool isSortDesc)
        {
            if (source == null)
            { throw new ArgumentNullException("source"); }

            if (string.IsNullOrEmpty(sortBy))
            { throw new ArgumentNullException("sortBy"); }

            if (isSortDesc == true)
            {
                source = source.OrderBy(sortBy).Reverse();
            }
            else
            {
                source = source.OrderBy(sortBy);
            }
            return source;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BLL
{
    public class PaginationService<T> : IPaginationService<T> where T : class
    {
        public int CountTotalRecords(List<T> recordsList)
        {
            return recordsList.Count();
        }
        public int CountTotalPages(IQueryable<T> records, int pageSize)
        {
            int totalPages;
            int totlalRecords = CountTotalRecords(records.ToList());
            int remainder = (totlalRecords % pageSize);
            if (remainder > 0)
            {
                totalPages = 1 + ((totlalRecords - remainder) / pageSize);
            }
            else { totalPages = (totlalRecords / pageSize); }

            return totalPages;
        }
        public List<T> GetPageRecords(IQueryable<T> records, int pageSize, int pageNum)
        {
            if (CountTotalPages(records, pageSize) <= pageNum)
            {
                return records.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                throw new ArgumentNullException("Page");
            }
        }
    }
}

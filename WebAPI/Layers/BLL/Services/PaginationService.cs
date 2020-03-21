using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BLL
{
    public class PaginationService<T> : IPaginationService<T> where T : class
    {
        public int CountTotalRecords(IEnumerable<T> recordsList)
        {
            return recordsList.Count();
        }
        public int CountTotalPages(IEnumerable<T> records, int pageSize)
        {
            int totalPages;
            int totlalRecords = CountTotalRecords(records);
            int remainder = (totlalRecords % pageSize);
            if (remainder > 0)
            {
                totalPages = 1 + ((totlalRecords - remainder) / pageSize);
            }
            else { totalPages = (totlalRecords / pageSize); }

            return totalPages;
        }
        public List<T> GetPageRecords(IEnumerable<T> records, int? pageSize, int pageNum)
        {
            if (pageSize == default)
            {
                pageSize = CountTotalRecords(records);
            }
            return records.Skip((pageNum - 1) * (int)pageSize).Take((int)pageSize).ToList();
        }
    }
}

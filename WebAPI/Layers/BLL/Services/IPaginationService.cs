using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolPortalAPI.BLL
{
    public interface IPaginationService<T> where T : class
    {
        List<T> GetPageRecords(IEnumerable<T> records, int? pageSize, int pageNum);
    }
}

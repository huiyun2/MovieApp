using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class PagedResultSet <TEntity> where TEntity : class
    {
        public PagedResultSet(IEnumerable<TEntity> data, int pagedIndex, int pageSize, long count)
        {
            PagedIndex = pagedIndex;
            PageSize = pageSize;
            Count = count;
            data = data;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int PagedIndex {get ;}
        public int PageSize {get ;}
        public int TotalPages {get;}
        public long Count {get ;}
        public bool HasPreviousPage => PagedIndex > 1;
        public bool HasNextPage => PagedIndex < TotalPages;
        public IEnumerable<TEntity> Data {get;}

    }
}
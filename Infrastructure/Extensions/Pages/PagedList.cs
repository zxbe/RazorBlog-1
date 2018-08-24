using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Pages
{
    public class PagedList<T>
    {
        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            TotalItems = source.Count();
            PageIndex = pageIndex;
            PageSize = pageSize;
            Items = source.Skip(pageSize * (pageIndex - 1))
                          .Take(pageSize)
                          .ToList();
        }

        public int PageIndex { get; }

        public int PageSize { get; }

        public int TotalItems { get; }

        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);

        public IEnumerable<T> Items { get; }
    }
}

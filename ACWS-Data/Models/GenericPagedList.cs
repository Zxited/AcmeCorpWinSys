using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ACWS_Data.Models
{
    public class GenericPagedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int PageTotal { get; set; }
        public bool HasPreviousPAge { get { return PageIndex > 1; }}
        public bool HasNextPage { get { return PageIndex < PageTotal; }}

        public GenericPagedList(IEnumerable<T> items, int itemCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageTotal = (int)Math.Ceiling(itemCount / (double)pageSize);

            this.AddRange(items);
        }

        public static GenericPagedList<T> CreateListAsync(IEnumerable<T> sourceList, int pageIndex, int pageSize)
        {
            var itemCount = sourceList.Count();
            var items = sourceList
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return new GenericPagedList<T>(items, itemCount, pageIndex, pageSize);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RazApp.Core.Helpers
{
    public class PagedData<T> where T : class
    {
        public IEnumerable<T> Data { get; set; }

        public int CurrentPage { get; set; }
        public int TotalRowCount { get; set; }
        public int RowsPerPage { get; set; }
        public int NumberOfPages { get; set; }

        public string SearchText { get; set; }
        public string SearchField { get; set; }


    }
}
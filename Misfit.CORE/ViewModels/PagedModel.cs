using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.ViewModels
{
    public class PagedModel<T> : PagingBase where T : class
    {
        public int TotalRows { get; set; }
        public List<T> TableData { get; set; }
    }
}

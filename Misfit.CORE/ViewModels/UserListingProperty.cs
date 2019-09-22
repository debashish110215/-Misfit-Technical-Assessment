using System;
using System.Collections.Generic;
using System.Text;

namespace Misfit.CORE.ViewModels
{
    public class UserListingProperty : PagingBase
    {
        public string UserName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SortBy { get; set; }
        public string SortingOrder { get; set; }
    }
}

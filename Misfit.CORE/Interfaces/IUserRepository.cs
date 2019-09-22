using Misfit.CORE.Domains;
using Misfit.CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.CORE.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        PagedModel<UserCalculationVM> GetAllForList(UserListingProperty listingProperty);
        CEUserCalculationVM CreateUserWithNumbers(CEUserCalculationVM model);
        User GetUserByName(string userName);
    }
}

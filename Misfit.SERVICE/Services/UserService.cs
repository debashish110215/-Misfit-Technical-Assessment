using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using Misfit.CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misfit.SERVICE.Services
{
    public class UserService : GenericService<User>
    {
        public Response<PagedModel<UserCalculationVM>> GetAllForList(UserListingProperty listingProperty)
        {
            var repository = GetInstance<IUserRepository>();
            var result = SafeExecute(() => repository.GetAllForList(listingProperty));
            return result;
        }

        public Response<CEUserCalculationVM> CreateUserWithNumbers(CEUserCalculationVM model)
        {
            var repository = GetInstance<IUserRepository>();
            var result = SafeExecute(() => repository.CreateUserWithNumbers(model));
            return result;
        }

        public Response<User> GetUserByName(string userName)
        {
            var repository = GetInstance<IUserRepository>();
            var result = SafeExecute(() => repository.GetUserByName(userName));
            return result;
        }
    }
}

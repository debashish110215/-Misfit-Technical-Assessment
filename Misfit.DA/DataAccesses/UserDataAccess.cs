using Microsoft.EntityFrameworkCore;
using Misfit.CORE.Domains;
using Misfit.CORE.Interfaces;
using Misfit.CORE.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Misfit.DA.DataAccesses
{
    public class UserDataAccess : GenericDataAccess<User>, IUserRepository
    {
        public UserDataAccess(MisfitDBContext context) : base(context)
        {
        }

        public PagedModel<UserCalculationVM> GetAllForList(UserListingProperty listingProperty)
        {
            DateTime startDate, endDate;
            DateTime.TryParse(listingProperty.StartDate, out startDate);
            endDate = DateTime.TryParse(listingProperty.EndDate, out endDate) ? endDate : DateTime.Now;

            var userList = (from users in MisfitDBSet.AsNoTracking()
                            join calculation in MisfitDBContext.Calculations
                            on users.Id equals calculation.UserId
                            where (String.IsNullOrWhiteSpace(listingProperty.UserName) ? true : users.UserName.Contains(listingProperty.UserName)) &&
                            (DateTime.TryParse(listingProperty.StartDate, out startDate) ? calculation.CreatedOn >= startDate : true) &&
                            calculation.CreatedOn <= endDate
                            //select users)
                            //.Include(i => i.Calculations).AsQueryable();
                            select new UserCalculationVM
                            {
                                UserId = users.Id,
                                UserName = users.UserName,
                                Num1 = calculation.Num1,
                                Num2 = calculation.Num2,
                                Sum = calculation.Sum,
                                CreatedOn = calculation.CreatedOn.Value
                            }).AsQueryable();

            var total = userList.Count();
            if (!String.IsNullOrEmpty(listingProperty.SortBy))
            {
                var sortContext = typeof(UserCalculationVM).GetProperty(listingProperty.SortBy);

                if (listingProperty.SortingOrder.Equals("asc"))
                    userList = userList.OrderBy(c => sortContext.GetValue(c));
                else
                    userList = userList.OrderByDescending(c => sortContext.GetValue(c));
            }
            else
            {
                var defaultSort = typeof(UserCalculationVM).GetProperty("CreatedOn");
                userList = userList.OrderByDescending(c => defaultSort.GetValue(c));
            }
            //var pageCount = (double)total / listingProperty.PageSize;

           // var skip = (listingProperty.PageNumber - 1) * listingProperty.PageSize;
           // userList = userList.Skip(skip).Take(listingProperty.PageSize);

            return CreatedPagedModel<UserCalculationVM>(userList, listingProperty.PageNumber, listingProperty.PageSize);
        }
        public CEUserCalculationVM CreateUserWithNumbers(CEUserCalculationVM model)
        {
            var user = MisfitDBSet.FindAsync(model.UserId).Result;
            if (model.UserId == 0)
                user = GetUserByName(model.UserName);
            var calculation = new Calculation()
            {
                Num1 = model.Num1,
                Num2 = model.Num2,
                Sum = Misfit.CORE.Helper.Calculation.CalculateSum(model.Num1, model.Num2),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            if (user == null)
            {
                user = new User()
                {
                    UserName = model.UserName
                };
            }

            user.Calculations.Add(calculation);

            base.Save(user);
            model.UserId = user.Id;
            model.Sum = calculation.Sum;
            return model;
        }

        public User GetUserByName(string userName)
        {
            var existingUser=(from user in MisfitDBSet.AsNoTracking()
                       where String.IsNullOrWhiteSpace(userName) ? false : user.UserName.Equals(userName)
                       select new User {
                           Id=user.Id,
                           UserName = user.UserName,
                           CreatedOn =user.CreatedOn
                       }).FirstOrDefault();
            return existingUser;
        }

    }
}

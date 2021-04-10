using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstack;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, CarDbContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarDbContext context =new CarDbContext())
            {
                var result = from ct in filter == null ? context.Customers : context.Customers.Where(filter)
                             join us in context.Users
                                 on ct.UserId equals us.UserId
                             select new CustomerDetailDto
                             {
                                 CustomerId = ct.CustomerId,
                                 UserId = us.UserId,
                                 CompanyName = ct.CompanyName,
                                 Email = us.Email,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 Status = us.Status
                             };
                return result.ToList();

            }
        }
    }
}

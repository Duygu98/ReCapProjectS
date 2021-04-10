using Core.DataAccess.EntityFramework;
using DataAccess.Abstack;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental, CarDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from rt in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join cr in context.Cars on rt.CarId equals cr.Id
                             join cst in context.Customers on rt.CustomerId equals cst.CustomerId
                             join usr in context.Users on cst.UserId equals usr.UserId
                             join brd in context.Brands on cr.BrandId equals brd.BrandId
                             join clr in context.Colors on cr.ColorId equals clr.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = rt.RentalId,
                                 CompanyName = cst.CompanyName,
                                 CarModelYear = cr.ModelYear,
                                 CarDailyPrice = cr.DailyPrice,
                                 CarDescription = cr.Description,
                                 CarId = rt.CarId,
                                 FirstName = usr.FirstName,
                                 LastName = usr.LastName,
                                 BrandName = brd.BrandName,
                                 ColorName = clr.ColorName,
                                 RentDate = rt.RentDate,
                                 ReturnDate = rt.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}

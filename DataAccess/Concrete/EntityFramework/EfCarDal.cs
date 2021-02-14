using Core.DataAccess.EntityFramework;
using DataAccess.Abstack;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDbContext context=new CarDbContext())
            {
                var result = from cr in context.Cars
                             from b in context.Brands
                             from cl in context.Colors
                             select new CarDetailDto
                             {
                                 CarName = cr.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = cr.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}

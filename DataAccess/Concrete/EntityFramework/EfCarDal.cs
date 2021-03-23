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
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarDbContext context=new CarDbContext())
            {
                var result = from cr in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on cr.BrandId equals b.BrandId
                             join cl in context.Colors on cr.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = cr.Id,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 ModelYear = cr.ModelYear,
                                 Descriptions = cr.Description
                             };
                return result.ToList();
            }
        }
   
    }
}

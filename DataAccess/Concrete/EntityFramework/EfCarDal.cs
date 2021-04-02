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
                                 CarName = cr.CarName,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = cr.DailyPrice,
                                 ModelYear = cr.ModelYear,
                                 Descriptions = cr.Description,
                                 CarImages= (from img in context.CarImages
                                             where (cr.Id == img.CarId)
                                             select new CarImage { Id = img.Id, CarId = cr.Id, ImageDate = img.ImageDate, ImagePath = img.ImagePath }).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int id)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join col in context.Colors on c.ColorId equals col.ColorId
                             where (b.BrandId == id)
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Description,
                                 CarImages = (from img in context.CarImages
                                              where (c.Id == img.CarId)
                                              select new CarImage { Id = img.Id, CarId = c.Id, ImageDate = img.ImageDate, ImagePath = img.ImagePath }).ToList()
                             };
                return result.ToList();
            }
        }
        public List<CarDetailDto> GetCarsDetailsByColorId(int id)
        {
            using (CarDbContext context = new CarDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join col in context.Colors on c.ColorId equals col.ColorId
                             where (col.ColorId == id)
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Description,
                                 CarImages = (from img in context.CarImages
                                              where (c.Id == img.CarId)
                                              select new CarImage { Id = img.Id, CarId = c.Id, ImageDate = img.ImageDate, ImagePath = img.ImagePath }).ToList()
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsByFilter(int colorId, int brandId)
        {
            using (CarDbContext context = new CarDbContext())
            {
                  var result = from c in context.Cars
                               join col in context.Colors on c.ColorId equals col.ColorId
                               join b in context.Brands on c.BrandId equals b.BrandId
                             
                             where c.ColorId ==colorId && c.BrandId==brandId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 Descriptions = c.Description,
                                 CarImages = (from img in context.CarImages
                                              where (c.Id == img.CarId)
                                              select new CarImage { Id = img.Id, CarId = c.Id, ImageDate = img.ImageDate, ImagePath = img.ImagePath }).ToList()
                             };
                return result.ToList();
            }
        }
    }
}

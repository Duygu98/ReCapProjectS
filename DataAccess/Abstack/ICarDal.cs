using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstack
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);

        List<CarDetailDto> GetCarsDetailsByBrandId(int id);
        List<CarDetailDto> GetCarsDetailsByColorId(int id);
        List<CarDetailDto> GetCarsByFilter(int colorId, int brandId);
    }
}

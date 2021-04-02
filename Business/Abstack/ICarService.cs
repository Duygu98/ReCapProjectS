using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstack
{
    public interface ICarService
    {

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();


        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId);


        IDataResult<List<CarDetailDto>> GetCarsByFilter(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarsByBrandIdList(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorIdList(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int id);


    }
}

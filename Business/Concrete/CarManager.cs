using Business.Abstack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstack;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _car;

        public CarManager(ICarDal car)
        {
            _car = car;
        }

        public IResult Delete(Car car)
        {
            _car.Delete(car);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_car.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_car.GetAll(c=>c.ColorId==id));
        }

        public IResult Update(Car car)
        {
            _car.Update(car);
            return new SuccessResult(Messages.CarUpdate);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {  
                         
            _car.Add(car);
            return new SuccessResult(Messages.CarAdded);
        
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsFilter(int brandId, int colorId)
        {

            return new SuccessDataResult<List<CarDetailDto>>(
                _car.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId),
                Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandIdList(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorIdList(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails(c => c.Id == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails(c => c.Id == carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_car.GetCarDetails(c => c.BrandId == brandId && c.ColorId == colorId), Messages.CarListed);
        }
    }
}

using Business.Abstack;
using Business.Constants;
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
        IMemory _car;

        public CarManager(IMemory car)
        {
            _car = car;
        }

        public IResult Delete(Car car)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
                         
            _car.Add(car);
            return new SuccessResult(Messages.BrandAdded);
        
        }
    }
}

using Business.Abstack;
using DataAccess.Abstack;
using Entities.Concrete;
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

        
        public void Add(Car car)
        {
            _car.Add(car);
            Console.WriteLine(car.Id+ " yeni araba eklendi.");
        }

        public List<Car> GetAll()
        {
            return _car.GetAll();   
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _car.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _car.GetAll(c=>c.ColorId==id);
        }
    }
}

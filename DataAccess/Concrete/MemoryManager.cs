<<<<<<< HEAD
﻿using DataAccess.Abstack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class MemoryManager : IMemory
    {
        List<Car> _cars;
        public MemoryManager()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=200, ModelYear="2021", Description="Güzel arabadır." },
            new Car{Id=4, BrandId=2, ColorId=4, DailyPrice=250, ModelYear="2020", Description="Güzel arabadır." },
            new Car{Id=4, BrandId=2, ColorId=5, DailyPrice=260, ModelYear="2001", Description="Güzel arabadır." },
            new Car{Id=8, BrandId=8, ColorId=6, DailyPrice=280, ModelYear="2005", Description="Güzel arabadır." },
            new Car{Id=8, BrandId=8, ColorId=2, DailyPrice=280, ModelYear="2008", Description="Güzel arabadır." },
            new Car{Id=5, BrandId=7, ColorId=1, DailyPrice=287, ModelYear="2012", Description="Güzel arabadır." },
            new Car{Id=5, BrandId=7, ColorId=1, DailyPrice=204, ModelYear="2010", Description="Güzel arabadır." }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car _carsDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(_carsDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.Id==Id).ToList();
        }

        public void Update(Car car)
        {
            Car _carsUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            _carsUpdate.BrandId = car.BrandId;
            _carsUpdate.ColorId = car.ColorId;
            _carsUpdate.DailyPrice = car.DailyPrice;
            _carsUpdate.Description = car.Description;
            _carsUpdate.ModelYear = car.ModelYear;

        }
    }
}
=======
﻿using DataAccess.Abstack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class MemoryManager : IMemory
    {
        List<Car> _cars;
        public MemoryManager()
        {
            _cars = new List<Car> {
            new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=200, MadelYear="2021", Descriptio="Güzel arabadır." },
            new Car{Id=4, BrandId=2, ColorId=4, DailyPrice=250, MadelYear="2020", Descriptio="Güzel arabadır." },
            new Car{Id=4, BrandId=2, ColorId=5, DailyPrice=260, MadelYear="2001", Descriptio="Güzel arabadır." },
            new Car{Id=8, BrandId=8, ColorId=6, DailyPrice=280, MadelYear="2005", Descriptio="Güzel arabadır." },
            new Car{Id=8, BrandId=8, ColorId=2, DailyPrice=280, MadelYear="2008", Descriptio="Güzel arabadır." },
            new Car{Id=5, BrandId=7, ColorId=1, DailyPrice=287, MadelYear="2012", Descriptio="Güzel arabadır." },
            new Car{Id=5, BrandId=7, ColorId=1, DailyPrice=204, MadelYear="2010", Descriptio="Güzel arabadır." }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car _carsDelete = _cars.SingleOrDefault(c=>c.Id==car.Id);
            _cars.Remove(_carsDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c=>c.Id==Id).ToList();
        }

        public void Update(Car car)
        {
            Car _carsUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            _carsUpdate.BrandId = car.BrandId;
            _carsUpdate.ColorId = car.ColorId;
            _carsUpdate.DailyPrice = car.DailyPrice;
            _carsUpdate.Descriptio = car.Descriptio;
            _carsUpdate.MadelYear = car.MadelYear;

        }
    }
}
>>>>>>> e80c826e7b9c9a7402243e4031dacad288c6c6d9

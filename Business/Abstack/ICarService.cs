﻿using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstack
{
    public interface ICarService
    {

        void Add(Car car);
        List<Car> GetAll();
        List<Car> GetCarsByBrandId(int id);
        List<Car> GetCarsByColorId(int id);
        List<CarDetailDto> GetCarDetails();

    }
}

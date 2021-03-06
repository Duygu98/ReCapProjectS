﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstack
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetByRentalId(int id);
        IDataResult<List<Rental>> GetByCarId(int id);
        IDataResult<List<Rental>> GetByCustomerId(int id);
        IDataResult<List<Rental>> GetByRentDate(DateTime first, DateTime last);
        IDataResult<Rental> CheckReturnDate(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalDetailsByCarId(int carId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}

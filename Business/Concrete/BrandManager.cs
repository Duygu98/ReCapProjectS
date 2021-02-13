using Business.Abstack;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;
        public BrandManager(IBrandDal brand)
        {
            _brand = brand;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }

            _brand.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
           
        }

        public IResult Delete(Brand brand)
        {
            _brand.Delete(brand);
            return new SuccessResult();

        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brand.GetAll(), Messages.BrandListed);
        }

        public IDataResult<List<Brand>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(c => c.BrandId == id));

        }


        public IResult Update(Brand brand)
        {
            _brand.Update(brand);
            return new SuccessResult();

        }
    }
}

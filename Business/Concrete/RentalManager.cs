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
    public class RentalManager : IRentalService
    {
        IRentalDal _rental;
        public RentalManager(IRentalDal rental)
        {
            _rental = rental;
        }
        public IResult Add(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IResult Delete(Rental rental)
        {
            _rental.Delete(rental);
            return new SuccessResult(Messages.RentalDelete);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if(DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rental.GetAll(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rental.Update(rental);
            return new SuccessResult(Messages.RentalUpdate);
        }
    }
}

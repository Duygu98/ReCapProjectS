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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customer;
        public CustomerManager(ICustomerDal customer)
        {
            _customer = customer;
        }
        public IResult Add(Customer customer)
        {
            _customer.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customer.Delete(customer);
            return new SuccessResult(Messages.CustomerDelete);
        }

        public IDataResult<List<Customer>> GetAll()
        {

            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Customer>>(_customer.GetAll(), Messages.ColorListed);
        }

        public IResult Update(Customer customer)
        {
            _customer.Update(customer);
            return new SuccessResult(Messages.CustomerUpdate);
        }
    }
}

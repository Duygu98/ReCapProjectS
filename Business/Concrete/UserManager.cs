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
    public class UserManager : IUserService
    {
        IUserDal _user;
        public UserManager(IUserDal user)
        {
            _user = user;         
        }

        public IResult Add(User user)
        {
            _user.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult(Messages.UserDelete);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<User>>(_user.GetAll(), Messages.UserListed);
        }
        public IResult Update(User user)
        {
            _user.Update(user);
            return new SuccessResult(Messages.UserUpdate);
        }
    }
}

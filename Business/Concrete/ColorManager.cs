using Business.Abstack;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _color;
        public ColorManager(IColorDal color)
        {
            _color = color;
        }

        [ValidationAspect(typeof(ColorValidator ))]
        public IResult Add(Color color)
        {
            _color.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _color.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
             
            // if (DateTime.Now.Hour == 21)
            //{
            //    return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Color>>(_color.GetAll(), Messages.ColorListed);
        }

        public IDataResult<List<Color>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_color.GetAll(c => c.ColorId == id));

        }

        public IResult Update(Color color)
        {
            _color.Update(color);
            return new SuccessResult();
        }
    }
}

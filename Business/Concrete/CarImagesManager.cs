using Business.Abstack;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstack;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImages;

        public CarImagesManager(ICarImagesDal carImages)
        {
            _carImages = carImages;
        }

        public IResult Add(IFormFile file,CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImages.Add(carImages);
            return new SuccessResult(Messages.ImageAdded);


        }

        public IResult Add(CarImages carImages)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImages carImages)
        {
            _carImages.Delete(carImages);
            return new SuccessResult(Messages.ImageDelete);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImages.GetAll());
        }

        public IDataResult<CarImages> GetImagesByCarId(int id)
        {
            var result = _carImages.Get(p => p.CarId == id);
            if (result == null)
            {
                return new SuccessDataResult<CarImages>(new CarImages { CarId = id, ImagePath = "Default.png", Date = DateTime.Now });
            }
            return new SuccessDataResult<CarImages>(result);
        }

        public IResult Update(CarImages carImages)
        {
            _carImages.Update(carImages);
            return new SuccessResult(Messages.ImageUpdate);
        }

        public IResult Update(IFormFile file, CarImages carImages)
        {
            carImages.ImagePath = FileHelper.Update(_carImages.Get(p => p.Id == carImages.Id).ImagePath, file);
            carImages.Date = DateTime.Now;
            _carImages.Update(carImages);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var carImageCount = _carImages.GetAll(p => p.CarId == carId).Count;

            if ( carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImagesCount);
            }
            return new SuccessResult();
        }
        private List<CarImages> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImages.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImages> { new CarImages { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImages.GetAll(p => p.CarId == id);
        }

    }
}

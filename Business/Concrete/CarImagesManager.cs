using Business.Abstack;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
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

        public IResult Add(IFormFile file,CarImage carImages)
        {
            IResult result = BusinessRules.Run(CheckImageLimitByCarId(carImages.CarId));
            if (result != null)
            {
                return result;
            }

            carImages.ImagePath = FileHelper.AddAsync(file);
            carImages.ImageDate = DateTime.Now;
            _carImages.Add(carImages);
            return new SuccessResult(Messages.ImageAdded);


        }

        public IResult Add(CarImage carImages)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(CarImage carImages)
        {
            _carImages.Delete(carImages);
            return new SuccessResult(Messages.ImageDelete);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImages.GetAll());
        }

        public IDataResult<CarImage> GetImagesByCarId(int id)
        {
            var result = _carImages.Get(p => p.CarId == id);
            if (result == null)
            {
                return new SuccessDataResult<CarImage>(new CarImage { CarId = id, ImagePath = "Default.png", ImageDate = DateTime.Now });
            }
            return new SuccessDataResult<CarImage>(result);
        }

        public IResult Update(CarImage carImages)
        {
            _carImages.Update(carImages);
            return new SuccessResult(Messages.ImageUpdate);
        }

        public IResult Update(IFormFile file, CarImage carImages)
        {
            carImages.ImagePath = FileHelper.UpdateAsync(_carImages.Get(p => p.Id == carImages.Id).ImagePath, file);
            carImages.ImageDate = DateTime.Now;
            _carImages.Update(carImages);
            return new SuccessResult();
        }

       
        private IResult CheckImageLimitByCarId(int carId)
        {
            var result = _carImages.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\Images\default.jpg";
                var result = _carImages.GetAll(c => c.CarId == carId).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImages.GetAll(p => p.CarId == carId));
        }
    }
}

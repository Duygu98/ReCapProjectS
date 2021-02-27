using Business.Abstack;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstack;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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

        public IResult Add(CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImages.CarId));
            if (result != null)
            {
                return result;
            }


            string randomPath = GuidFunction();
            carImages.CarId = carImages.CarId;
            carImages.ImagePath = randomPath;
            carImages.Date = DateTime.Now;
            _carImages.Add(carImages);

            return new SuccessResult(Messages.ImageAdded);


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

        private IResult CheckCarImageCount(int carId)
        {
            var carImageCount = _carImages.GetAll(p => p.CarId == carId).Count;

            if ( carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImagesCount);
            }
            return new SuccessResult();
        }

        private string GuidFunction()
        {
            string unique = Guid.NewGuid().ToString();
            return unique + ".jpg";
        }
    }
}

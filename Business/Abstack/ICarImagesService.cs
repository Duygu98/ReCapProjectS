using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstack
{
    public interface ICarImagesService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImages);

        IResult Add(CarImage carImages);
        IResult Delete(CarImage carImages);
        IResult Update(CarImage carImages);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetImagesByCarId(int id);
    }
}

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
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file, CarImages carImages);

        IResult Add(CarImages carImages);
        IResult Delete(CarImages carImages);
        IResult Update(CarImages carImages);
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetImagesByCarId(int id);
    }
}

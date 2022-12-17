using Core.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int carImageId);
        IDataResult<List<CarImages>> GetByCarId(int carId);
        IResult Add(List<IFormFile> formFile, CarImages carImage);
        IResult Delete(CarImages carImage);
        IResult Update(List<IFormFile> file, CarImages carImage);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager: ICarImageService
    {
        public static string ImagesPath = @"wwwroot\\Uploads\\Images\\";

        ICarImagesDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImagesDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(List<IFormFile> formFile, CarImages carImage)
        {

            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(formFile, ImagesPath);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(CarImages carImage)
        {
            var carToBeDeleted = _carImageDal.Get(c => c.Id == carImage.Id);
            if (carToBeDeleted == null)
            {
                return new ErrorResult();
            }
            _fileHelper.Delete(carToBeDeleted.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();

            /*
            string imagePath = _carImageDal.Get(c => c.Id == carImage.Id).ImagePath;
            _fileHelper.Delete(imagePath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
            */
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImages>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageAdded(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>();
            }
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImages> GetById(int Id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c => c.Id == Id));
        }

        public IResult Update(List<IFormFile> file, CarImages carImage)
        {
            var result = _carImageDal.Get(c => c.Id == carImage.Id);
            carImage.ImagePath = _fileHelper.Update(file, ImagesPath + result.ImagePath, ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        //RULES

        private IResult CheckIfCarImageAdded(int carImageId)
        {
            var result = _carImageDal.GetAll(c => c.CarId==carImageId);
            if (result.Count == 0)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {
            List<CarImages> car = new List<CarImages> { new CarImages { CarId = carId, ImagePath = "Default.png" } };
            return new SuccessDataResult<List<CarImages>>(car);
        }
        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 5)
            {
                return new ErrorResult("Limit ");
            }
            return new SuccessResult();
        }
    }
}

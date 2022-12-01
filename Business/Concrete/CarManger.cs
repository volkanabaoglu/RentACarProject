using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Core.Results;


namespace Business.Concrete
{
    public class CarManger : ICarService
    {
        ICarDal _carDal;
        public CarManger(ICarDal carDal)
        {
            carDal = _carDal; 
        }
        
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == id));
        }

        public IResult Add(Car car)
        {
           
            _carDal.Add(car);
            return new SuccessResult();
        }

    }
}

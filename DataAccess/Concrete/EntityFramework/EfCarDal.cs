using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfRepositoryBase<Car,DBContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (DBContext context = new DBContext())
            {
                var result = from car in context.Cars
                    join brand in context.Brands 
                        on car.BrandId equals  brand.BrandId
                    join color in context.Colors 
                        on car.ColorId equals color.ColorId 

                    select new CarDetailsDto()
                    {
                        BrandName = brand.BrandName,
                        ColorName = color.ColorName,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}

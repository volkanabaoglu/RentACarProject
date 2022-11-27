using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalsManager:IRentalService
    {
        IRentalsDal _rentalsDal;
        public IResult Add(Rentals rental)
        {
            if (rental.ReturnDate==null)
            {
                _rentalsDal.Add(rental);
                return new SuccessResult(Messages.SaveSuccessful);
            }

            return new ErrorResult(Messages.SaveFailed);
        }
    }
}

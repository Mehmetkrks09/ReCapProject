using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _rentalsDal;

        public RentalsManager(IRentalsDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rentals rentals)
        {

            if(rentals.ReturnDate>DateTime.Now)
            {
                Console.WriteLine("Araba Kiralanamadı Daha teslim edilmedi");
            }
            _rentalsDal.Add(rentals);
            return new  SuccesResult(Messages.CarRent);
         
        }

    public void Delete(Rentals rentals)
    {
        Console.WriteLine("Araba Silindi");
        _rentalsDal.Delete(rentals);
    }

    public IDataResult<List<Rentals>> GetAll()
    {
       return new SuccesDataResult<List<Rentals>>(
         _rentalsDal.GetAll());
    }


    public void Update(Rentals rentals)
    {
        Console.WriteLine("Araba Güncellendi");
        _rentalsDal.Update(rentals);
    }

   IDataResult< Rentals> IRentalsService.GetById(int Id)
    {
            return new SuccesDataResult<Rentals>(_rentalsDal.Get(p => p.CarId == Id));

    }
}
}


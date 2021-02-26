using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult< Rentals> GetById(int Id);
        IResult Add(Rentals rentals);
        void Delete(Rentals rentals);
        void Update(Rentals rentals);
    }
}

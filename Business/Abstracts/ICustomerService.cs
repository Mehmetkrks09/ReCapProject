using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
       IDataResult< List<Customers>> GetAll();
       IDataResult< Customers> GetById(int customerId);
        IResult Add(Customers customers);
        void Delete(Customers customers);
        void Update(Customers customers);
    }
}

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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customers customers)
        {
            _customerDal.Add(customers);
            return new SuccesResult(Messages.CustomerAdded);
           
        }

        public void Delete(Customers customers)
        {
            Console.WriteLine("Kişi Silindi");
            _customerDal.Delete(customers);
        }

        public IDataResult<List<Customers>> GetAll()
        {
            return new SuccesDataResult<List<Customers>>(_customerDal.GetAll());
        }

        public  IDataResult<Customers> GetById(int customersId)
        {
           return new SuccesDataResult<Customers>(
           _customerDal.Get(p => p.UserId == customersId));
           
        }

        public void Update(Customers customers)
        {
            Console.WriteLine("Kişi Güncellendi");
            _customerDal.Update(customers);
        }
    }
}
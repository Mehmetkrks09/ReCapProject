using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService

    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                return new SuccesResult(Messages.BrandAdded);
               
            }
            else
            {
                return new ErrorResult(Messages.BrandNameInvalıd);

            }

        }

        public void Delete(Brand brand)
        {
            Console.WriteLine("Car brand has been Deleted");
        }

        public IDataResult<List<Brand>> GetAll()
        {


         
            

            return new SuccesDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandGetAll);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccesDataResult<Brand>(_brandDal.Get(p => p.BrandId == id));

        }

        public void Update(Brand brand)
        {
            Console.WriteLine("Brand is Has been Updated");
        }
    }
}

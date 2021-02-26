using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
       IDataResult<List<Car>> GetById(int id);
        IResult Add(Car car);
        void Delete(Car car);
        void Update(Car car); 
        IDataResult<List<Car>> GetByBrandId(int id);
        IDataResult<List<Car>> GetByColorId(int id);
        IDataResult< List<CarDetailDto>> GetCarDetails();



    }
}

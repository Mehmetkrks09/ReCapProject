using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal,
IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId), CheckIfCarNameExists(car.Id), CheckIfBrandLimitExcided());
            if (result != null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccesResult(Messages.CarAdded);

        }

        public void Delete(Car car)
        {
            Console.WriteLine("Car Has been Deleted");
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            Console.WriteLine("All Cars :");
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(p => p.Id == id));
        }




        public void Update(Car car)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccesDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());

        }
        private IResult CheckIfCarCountOfBrandCorrect(int BrandId)
        {
            var result = _carDal.GetAll(p => p.BrandId == BrandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);

            }
            return new SuccesResult();
        }
        private IResult CheckIfCarNameExists(int Id)
        {
            var result = _carDal.GetAll(c => c.Id == Id).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccesResult();





        }


        private IResult CheckIfBrandLimitExcided()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CheckIfBrandLimitExcided);
            }
            return new SuccesResult();

        }
    }
}

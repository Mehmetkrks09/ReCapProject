﻿using Business.Abstracts;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (CheckIfCarCountOfBrandCorrect(car.BrandId).Succes && CheckIfCarNameExists(car.Id).Succes)
            {

                _carDal.Add(car);
                return new SuccesResult(Messages.CarAdded);
            }
            return new SuccesResult();


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
            if (result )
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccesResult();




        }
    }
}
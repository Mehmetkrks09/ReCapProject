
//using DataAccess.Abstracts;
//using Entities.Concrete;
//using Entities.DTOs;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace dataaccess.concrete
//{
//    public class inmemorydal : ICarDal
//    {
//        List<Car> _car;

//        public inmemorydal()
//        {
//            _car = new List<Car>
//            {
//                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=1500,ModelYear=1998,Description="memurdan temiz"},
//                 new Car{Id=2,BrandId=1,ColorId=2,DailyPrice=1400,ModelYear=1997,Description="emekliden temiz"},
//                  new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=1300,ModelYear=1996,Description="dosta gider "},
//                   new Car{Id=4,BrandId=2,ColorId=4,DailyPrice=1200,ModelYear=1995,Description=".........."},
//                    new Car{Id=5,BrandId=1,ColorId=5,DailyPrice=1100,ModelYear=1994,Description="................."},

//            };
//        }

//        public void add(Car entity)
//        {
//            _car.Add(entity);
//        }

//        public void Add(Car entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void delete(Car entity)
//        {
//            Car cartodelete = _car.SingleOrDefault(c => c.Id == Car.Id);
//            _car.Remove(cartodelete);
//        }

//        public void Delete(Car entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Car get(Expression<Func<Car, bool>> filter)
//        {
           
//        }

//        public Car Get(Expression<Func<Car, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public List<Car> getall(Expression<Func<Car, bool>> filter = null)
//        {
//            return _car;
//        }

//        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
//        {
//            throw new NotImplementedException();
//        }

//        public List<CarDetailDto> GetCarDetails()
//        {
//            throw new NotImplementedException();
//        }

//        public void update(Car entity)
//        {

//            Car cartoupdate = _car.SingleOrDefault(c => c.Id == Car.Id);
//            cartoupdate.ColorId = Car.ColorId;
//            cartoupdate.BrandId = Car.BrandId;
//            cartoupdate.Description = Car.Description;
//            cartoupdate.ModelYear = Car.ModelYear;
//            cartoupdate.Id = Car.id;
//            cartoupdate.DailyPrice = Car.DailyPrice;

//        }

//        public void Update(Car entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}



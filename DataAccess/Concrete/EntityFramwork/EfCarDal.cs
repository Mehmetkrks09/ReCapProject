using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramwork
{
    public class EfCarDal : EfEntityRepositoryBase<Car, context>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (context context= new context())
            {
                var result = from c in context.Car
                             join b in context.Brands
                           
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                               DailyPrice=c.DailyPrice,
                               BrandName=b.BrandName,
                        
                                 Description=c.Description,
                                 ModelYear=c.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}

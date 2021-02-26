using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstracts
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand>GetById(int id);
        IResult Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);

        

    }
}

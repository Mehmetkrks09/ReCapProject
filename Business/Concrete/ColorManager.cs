using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concrete.EntityFramwork;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {

            return new SuccesResult(Messages.CarAdded);
        }

        public void Delete(Color color)
        {
            Console.WriteLine("Renk silindi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccesDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccesDataResult<Color>( _colorDal.Get(p => p.ColorId == id));
        }

        public void Update(Color color)
        {
            Console.WriteLine("Updated");
        }
    }
}

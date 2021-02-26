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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccesResult(Messages.PersonAdded);
          
        }

        public void Delete(User user)
        {
            Console.WriteLine("Kişi Silindi");
            _userDal.Delete(user);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccesDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            Console.WriteLine("Kişiler Güncellendi");
            _userDal.Update(user);
        }
    }
}

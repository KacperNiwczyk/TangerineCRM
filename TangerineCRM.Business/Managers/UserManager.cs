using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TangerineCRM.Business.Interfaces;
using TangerineCRM.Core.Helpers.Enums;
using TangerineCRM.DataAccess.Interfaces;
using TangerineCRM.Entities.Base;

namespace TangerineCRM.Business.Managers
{
    public class UserManager : BaseManager<User>, IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal) : base(userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetList();
        }

        public User GetBy(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        protected override ValidationResult Validate(User t)
        {
            return ValidationResult.SUCCESS;
        }
    }
}

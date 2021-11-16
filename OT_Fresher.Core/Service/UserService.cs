using OT_Fresher.Core.Entities;
using OT_Fresher.Core.Exceptions;
using OT_Fresher.Core.Interfaces.Repository;
using OT_Fresher.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OT_Fresher.Core.Service
{
    public class UserService:BaseService<User>, IUserService
    {
        IUserRepository _repository;
        public UserService(IUserRepository repository):base(repository)
        {
            _repository = repository;
        }
        protected override void Validate(User user)
        {
            base.Validate(user);
            var isDuplicateCode = false;

            // Kiểm tra trùng mã 
            if (user.EntityState == Enum.EntityState.Add)
            {
                isDuplicateCode = _repository.CheckEmailExist(user.Email);
            }

            if (isDuplicateCode)
            {
                throw new ValidateException("Tài khoản đã tồn tại trong hệ thống. Vui lòng Sử dụng một tài khoản khác!", user.Email);
            }

        }
    }
}

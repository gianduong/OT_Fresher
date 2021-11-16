using OT_Fresher.Core.Entities;
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
        public UserService(IUserRepository repository):base(repository)
        {

        }
    }
}

using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UserService
{
    public interface IUserService
    {
        public bool CheckUserIsExist(string email); 
        public User FindUserByEmail(string email);
    }
}

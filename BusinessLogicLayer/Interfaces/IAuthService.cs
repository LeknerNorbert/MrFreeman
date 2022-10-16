using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthService
    {
        public bool CheckUserIsExist(string email);
        public void CreateUser(UserModel userModel);
        public bool VerifyUser(string email, string password, out string token);
    }
}

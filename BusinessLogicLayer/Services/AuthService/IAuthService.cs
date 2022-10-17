using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AuthService
{
    public interface IAuthService
    {
        public void RegisterUser(UserRegisterRequest userModel);
        public bool VerifyLoginData(string email, string password, out string token);
        public bool VerifyEmail(string token);
    }
}

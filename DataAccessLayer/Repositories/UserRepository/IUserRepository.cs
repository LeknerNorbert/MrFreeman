using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.UserRepository
{
    public interface IUserRepository
    {
        public bool CheckUserIsExist(string email);
        public UserEntity? FindUserByEmail(string email);
        public UserEntity? FindUserByToken(string token);
        public void CreateUser(UserEntity userEntity);
        public void UpdateUserVerifyAt(UserEntity userEntity);
    }
}

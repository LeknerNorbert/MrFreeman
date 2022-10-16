using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAuthRepository
    {
        public UserEntity? FindUserByEmail(string email);
        public void CreateUser(UserEntity userEntity);
    }
}

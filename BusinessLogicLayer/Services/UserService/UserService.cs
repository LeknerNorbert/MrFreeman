using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CheckUserIsExist(string email)
        {
            return _userRepository.CheckUserIsExist(email);
        }

        public User FindUserByEmail(string email)
        {
            UserEntity? userEntity = _userRepository.FindUserByEmail(email);

            User user = new()
            {
                Email = userEntity.Email,
                Firstname = userEntity.Firstname,
                Lastname = userEntity.Lastname,
                PhoneNumber = userEntity.PhoneNumber,
                VerificationToken = userEntity.VerificationToken,
                VerifiedAt = userEntity.VerifiedAt,
                PasswordResetToken = userEntity.PasswordResetToken,
                PasswordResetExpires = userEntity.PasswordResetExpires,
                RegisterDate = userEntity.RegisterDate
            };

            return user;
        }
    }
}

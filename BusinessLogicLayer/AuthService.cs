﻿using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogicLayer
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IAuthRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public bool CheckUserIsExist(string email)
        {
            return _repository.CheckUserIsExist(email);
        }

        public void RegisterUser(UserRegisterRequest userRegister)
        {
            CreatePasswordHash(userRegister.Password, out byte[] passwordHash, out byte[] passwordSalt);

            UserEntity userEntity = new()
            {
                Email = userRegister.Email,
                Firstname = userRegister.Firstname,
                Lastname = userRegister.Lastname,
                PhoneNumber = userRegister.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken(),
            };

            _repository.CreateUser(userEntity);
        }

        public bool VerifyLoginData(string email, string password, out string token)
        {
            UserEntity? userEntity = _repository.FindUserByEmail(email);
            token = String.Empty;
            bool isValid = false;

            if(VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))
            {
                token = CreateToken(userEntity);
                isValid = true;
            }

            return isValid;
        }

        public bool VerifyEmail(string token)
        {
            UserEntity? userEntity = _repository.FindUserByToken(token);

            if(userEntity == null)
            {
                return false;
            }

            _repository.UpdateUserVerifyAt(userEntity);

            return true;
        }

        private string CreateToken(UserEntity userEntity)
        {
            List<Claim> claims = new()
            {
                new Claim("Email", userEntity.Email),
                new Claim("Firstname", userEntity.Firstname),
                new Claim("Lastname", userEntity.Lastname)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Token").Value
                ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }

        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }
    }
}
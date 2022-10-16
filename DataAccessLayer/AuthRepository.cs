using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Context;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public UserEntity? FindUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public void CreateUser(UserEntity userEntity)
        {
            _db.Users.Add(userEntity);
            _db.SaveChanges();
        }
    }
}
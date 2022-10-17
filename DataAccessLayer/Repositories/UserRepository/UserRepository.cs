using DataAccessLayer.Entities;
using DataAccessLayer.Entities.Context;

namespace DataAccessLayer.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CheckUserIsExist(string email)
        {
            return _db.Users.Any(u => u.Email == email);
        }

        public UserEntity? FindUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public UserEntity? FindUserByToken(string token)
        {
            return _db.Users.FirstOrDefault(u => u.VerificationToken == token);
        }

        public void CreateUser(UserEntity userEntity)
        {
            _db.Users.Add(userEntity);
            _db.SaveChanges();
        }

        public void UpdateUserVerifyAt(UserEntity userEntity)
        {
            userEntity.VerifiedAt = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
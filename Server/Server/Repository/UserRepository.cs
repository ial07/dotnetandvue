using Microsoft.EntityFrameworkCore;
using Server.Context;
using Server.Interface;
using Server.Models;

namespace Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContexts _contexts;
        public UserRepository(DbContexts contexts)
        {
            _contexts = contexts;
        }

        public bool CreateUser(User user)
        {
            _contexts.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _contexts.Remove(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _contexts.Users.Where(p => p.Id == id).FirstOrDefault();
        }

        public User GetUserByUsernameAndPassword(string username , string password)
        {
            return _contexts.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _contexts.Users.OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _contexts.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _contexts.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _contexts.Users.Any(p => p.Id == id);
        }


    }
}

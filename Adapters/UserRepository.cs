using Domain;
using Infrastructures;

namespace Adapters
{
    public class UserRepository : IUserRepositoryAdapter
    {
        private readonly DatabaseContext _dbContext;

        public UserRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserById(int userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
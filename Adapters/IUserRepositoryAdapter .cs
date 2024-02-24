using Application.Ports;
using Domain;

namespace Adapters
{
    public interface IUserRepositoryAdapter : IUserRepository
    {
        IEnumerable<User> GetActiveUsers();
    }
}
using Application.Ports;
using Domain;

namespace Application.Adapters
{
    public interface IUserRepositoryAdapter : IUserRepository
    {
        IEnumerable<User> GetActiveUsers();
    }
}
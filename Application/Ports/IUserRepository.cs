using Domain;

namespace Application.Ports
{
    public interface IUserRepository
    {
        User GetUserById(int userId);

        void CreateUser(User user);
    }
}
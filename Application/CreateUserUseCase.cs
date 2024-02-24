using Application;
using Application.Ports;

namespace Domain
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public CreateUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreateUserResponse Execute(CreateUserRequest request)
        {
            // Lógica de negócios para criar um usuário
            var newUser = User.Create(request.Name); // Utilizando o método estático da entidade User

            _userRepository.CreateUser(newUser);

            return new CreateUserResponse { UserId = newUser.Id };
        }
    }
}
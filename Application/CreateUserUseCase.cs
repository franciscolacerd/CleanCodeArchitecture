using Application.Adapters;
using Application.Ports;
using Domain;

namespace Application
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepositoryAdapter _userRepository;

        public CreateUserUseCase(IUserRepositoryAdapter userRepository)
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
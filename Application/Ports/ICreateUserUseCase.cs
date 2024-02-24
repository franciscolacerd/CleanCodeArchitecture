namespace Application.Ports
{
    public interface ICreateUserUseCase
    {
        CreateUserResponse Execute(CreateUserRequest request);
    }
}
using Application;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase ?? throw new ArgumentNullException(nameof(createUserUseCase));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                // Simple validation of request data
                if (string.IsNullOrWhiteSpace(createUserRequest.Name))
                {
                    return BadRequest("User name is required.");
                }

                // Execute the use case to create a user
                var createUserResponse = _createUserUseCase.Execute(createUserRequest);

                // Return a successful response with the created user's ID
                return Ok(new { UserId = createUserResponse.UserId });
            }
            catch (Exception ex)
            {
                // In case of an error, return an error response
                return StatusCode(500, $"An error occurred while creating the user: {ex.Message}");
            }
        }
    }
}
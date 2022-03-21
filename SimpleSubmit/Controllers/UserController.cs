using Microsoft.AspNetCore.Mvc;
using SimpleSubmit.Models;
using SimpleSubmit.Repositories;

namespace SimpleSubmit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        [HttpPost]
        public ActionResult<InsertUserResult> RegisterUser([FromBody] UserRequest userRequest)
        {
            if (string.IsNullOrWhiteSpace(userRequest.FirstName) ||
                string.IsNullOrWhiteSpace(userRequest.LastName) ||
                string.IsNullOrWhiteSpace(userRequest.Username) ||
                userRequest.Birthdate.Equals(DateTime.MinValue))
                return BadRequest();

            var userGuid = _userRepository.InsertUser(userRequest);
            var age = DateTime.UtcNow.Year - userRequest.Birthdate.Year;
            return new InsertUserResult { Id = userGuid, Age = age, ServerTimeStamp = DateTimeOffset.UtcNow };
        }
    }
}

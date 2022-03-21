using SimpleSubmit.Models;

namespace SimpleSubmit.Repositories;

public interface IUserRepository
{
    Guid InsertUser(UserRequest userRequest);
}
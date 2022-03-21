using SimpleSubmit.Models;

namespace SimpleSubmit.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Guid InsertUser(UserRequest userRequest)
        {
            return Guid.NewGuid();
        }
    }
}

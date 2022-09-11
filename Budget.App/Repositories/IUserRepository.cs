using Budget.App.Models;

namespace Budget.App.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(CreateUserRequest user);
    }
}
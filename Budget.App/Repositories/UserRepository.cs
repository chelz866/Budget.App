using Budget.App.Models;
using Dapper;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace Budget.App.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppSettings _settings;
        public UserRepository(IOptions<AppSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<User> CreateUser(CreateUserRequest user)
        {
            using (var conn = new SqlConnection(_settings.ConnectionString))
            {
                var userResponse = await conn.QueryFirstAsync<User>("dbo.CreateUser", user, commandType: CommandType.StoredProcedure);
                return userResponse;
            }
        }
    }
}


using Budget.App.Models;
using Budget.App.Repositories;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using User = Budget.App.Models.User;

namespace Budget.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        public UserController(IOptions<AppSettings> options, IUserRepository userRepository)
        {
            _appSettings = options.Value;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(string email, string password)
        {
            var provider = new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(_appSettings.AppString));

            var authLink = await provider.SignInWithEmailAndPasswordAsync(email, password);

            string token = authLink.FirebaseToken;
            return Ok(token);
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(CreateUserRequest user)
        {
            var provider = new Firebase.Auth.FirebaseAuthProvider(new Firebase.Auth.FirebaseConfig(_appSettings.AppString));

            var authLink = await provider.CreateUserWithEmailAndPasswordAsync(user.Email, user.Password);

            await _userRepository.CreateUser(user);

            string token = authLink.FirebaseToken;
            return Ok(token);
        }
    }
}

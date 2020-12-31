using ABCTask.Core;
using ABCTask.DTO;
using ABCTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ABCTask.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Login(Login model)
        {
            return await _userRepository.Login(model);
        } 

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(Register model)
        {

            return await _userRepository.Register(model);
        }
    }
}

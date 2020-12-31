using ABCTask.Core;
using ABCTask.DTO;
using ABCTask.DTO.JWT;
using ABCTask.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<UserDTO> Login(Login model)
        {
            var loginUser = await _userManager.FindByEmailAsync(model.Email);

            JwtGenerator jwt = new JwtGenerator();

            if (loginUser == null)
            {
                throw new Exception("Ky user nuk ekziston");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(loginUser, model.Password, true);

            if (result.Succeeded)
            {
                return new UserDTO
                {
                    Email = loginUser.Email,
                    Token = jwt.CreateToken(model)
                };
            }

            throw new Exception("Ka ngodhur nje problem");
        }

        public async Task<UserDTO> Register(Register model)
        {
            JwtGenerator jwt = new JwtGenerator();
            if (model != null)
            {
                var user = new IdentityUser { UserName = model.Username, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: true);
                    Login loginmodel = new Login();
                    loginmodel.Email = model.Email;
                    loginmodel.Password = model.Password;
                    return new UserDTO
                    {
                        Email = model.Email,
                        Token = jwt.CreateToken(loginmodel)
                    };
                }
            }
            throw new Exception("A problem occured");
        }
    }
}

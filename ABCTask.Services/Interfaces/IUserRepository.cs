using ABCTask.Core;
using ABCTask.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABCTask.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<UserDTO> Login(Login model);
        Task<UserDTO> Register(Register model);
    }
}

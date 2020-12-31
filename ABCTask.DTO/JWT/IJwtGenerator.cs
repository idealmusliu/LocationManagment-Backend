using ABCTask.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCTask.DTO.JWT
{
    public interface IJwtGenerator
    {
        public string CreateToken(Login model);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_Management.Models;

namespace Blog_Management.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces
{
    public interface IUserRepo
    {
        GetUserDTO Get(string email, string password);
        Task<int> Add(AddUserDTO dto);
    }
}

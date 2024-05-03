using Application.Abstractions.Interfaces;
using Application.DTOs;
using Persistence;
using Persistence.Entities;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Implementations
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDBContext _context;

        public UserRepo(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(AddUserDTO dto)
        {
            var isExist = IsExist(dto.Email);
            if (isExist != null)
                throw new Exception("Email already exist.");
            User user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = SecurityHelper.GenerateHash(dto.Password),
                CreatedOn = DateTime.Now
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        private User IsExist(string email)
        {
            return _context.Users.Where(_ => _.Email == email).FirstOrDefault();
        }
    }
}

using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersByCompany(int companyId);
        Task<User> GetUserById(int userId);
        Task<User> CreateUser(User user);
        Task<UserLoginDto> Login(string userName);
        Task<User> UpdateUser(int userId, User user);
    }
}

using AutoCooler.Application.IRepository;
using AutoCooler.Application.IService;
using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetAllUsersByCompany(int companyId)
        {
            var users = _userRepository.GetAllUsersByCompany(companyId);

            return users;
        }
        
        public Task<User> GetUserById(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            return user;
        }

        public async Task<User> CreateUser(User user)
        {
            user.PasswordHash = HashPassword(user.PasswordHash);
            return await _userRepository.CreateUser(user);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
                
        public async Task<UserLoginDto> Login(string userName, string password)
        {
            var user = await _userRepository.Login(userName);
            
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }

            return null;
        }

        public Task<User> UpdateUser(int userId, User user)
        {
            var existingUser = _userRepository.GetUserById(userId);
            
            if (existingUser == null)
            {
                return Task.FromResult<User>(null);
            }
            
            user.PasswordHash = HashPassword(user.PasswordHash);
            
            return _userRepository.UpdateUser(userId, user);
        }

    }
}

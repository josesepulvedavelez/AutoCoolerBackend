using AutoCooler.Application.IRepository;
using AutoCooler.Domain.Dto;
using AutoCooler.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Infraestructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AutoCoolerContext _autoCoolerContext;

        public UserRepository(AutoCoolerContext autoCoolerContext)
        {
            _autoCoolerContext = autoCoolerContext;
        }

        public async Task<IEnumerable<User>> GetAllUsersByCompany(int companyId)
        {
            var users = await _autoCoolerContext.User
                              .Where(x => x.CompanyId == companyId)
                              .ToListAsync();

            return users;
        }

        public Task<User> GetUserById(int userId)
        {
            var user = _autoCoolerContext.User
                        .FirstOrDefaultAsync(x => x.UserId == userId);

            return user;
        }

        public async Task<User> CreateUser(User user)
        {
            _autoCoolerContext.User.Add(user);
            int result = await _autoCoolerContext.SaveChangesAsync();

            return result > 0 ? user : null;
        }

        public async Task<UserLoginDto> Login(string userName)
        {
            var user = await (
                       from e in 
                           _autoCoolerContext.Employee
                       join u 
                            in _autoCoolerContext.User on e.EmployeeId equals u.EmployeeId
                       where u.Username == userName
                       select new UserLoginDto
                       {
                           EmployeeId = e.EmployeeId,
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           Phone = e.Phone,
                           Email = e.Email,
                           IsTechnician = e.IsTechnician,

                           UserName = u.Username,
                           PasswordHash = u.PasswordHash,
                           UserId = u.UserId,
                           IsActive = u.IsActive
                       }).FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> UpdateUser(int userId, User user)
        {
            var existingUser = await _autoCoolerContext.User.FindAsync(userId);
            
            if (existingUser == null)
            {
                return null;
            }
            
            existingUser.Username = user.Username;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Email = user.Email;
            existingUser.IsActive = user.IsActive;
            existingUser.CreationDate = user.CreationDate;
            existingUser.CompanyId = user.CompanyId;
            existingUser.EmployeeId = user.EmployeeId;
            
            _autoCoolerContext.User.Update(existingUser);
            await _autoCoolerContext.SaveChangesAsync();
            
            return existingUser;
        }

    }
}

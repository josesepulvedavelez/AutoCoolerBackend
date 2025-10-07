using AutoCooler.Application.IRepository;
using AutoCooler.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Infraestructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AutoCoolerContext _autoCoolerContext;
        
        public EmployeeRepository(AutoCoolerContext autoCoolerContext)
        {
            _autoCoolerContext = autoCoolerContext;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var employeeEntry = _autoCoolerContext.Employee.Add(employee);
            await _autoCoolerContext.SaveChangesAsync();

            return employeeEntry.Entity;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesByCompany(int companyId)
        {
            var employees = await _autoCoolerContext.Employee
                                  .Where(e => e.CompanyId == companyId)
                                  .ToListAsync();

            return employees;
        }

        public Task<Employee> GetEmployeeById(int employeeId)
        {
            var employee = _autoCoolerContext.Employee.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            
            return employee;
        }

        public async Task<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            var existingEmployee = await _autoCoolerContext.Employee.FindAsync(employeeId);
            
            if (existingEmployee == null)
            {
                return null;
            }
            
            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Phone = employee.Phone;
            existingEmployee.IsTechnician = employee.IsTechnician;
            existingEmployee.IsActive = employee.IsActive;
            existingEmployee.CompanyId = employee.CompanyId;

            _autoCoolerContext.Employee.Update(existingEmployee);
            await _autoCoolerContext.SaveChangesAsync();

            return existingEmployee;
        }

    }
}

using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IService
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesByCompany(int companyId);
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> UpdateEmployee(int employeeId, Employee employee);
    }
}

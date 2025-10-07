using AutoCooler.Application.IRepository;
using AutoCooler.Application.IService;
using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> CreateEmployee(Employee employee)
        {
            var employeeEntry = _employeeRepository.CreateEmployee(employee);
            
            return employeeEntry;
        }

        public Task<IEnumerable<Employee>> GetAllEmployeesByCompany(int companyId)
        {
            var employees = _employeeRepository.GetAllEmployeesByCompany(companyId);

            return employees;
        }

        public Task<Employee> GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);

            return employee;
        }

        public Task<Employee> UpdateEmployee(int employeeId, Employee employee)
        {
            var updatedEmployee = _employeeRepository.UpdateEmployee(employeeId, employee);

            return updatedEmployee;
        }

    }
}

using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IService
{
    public interface ICustomerService
    { 
        Task<IEnumerable<Customer>> GetAllCustomersByCompany(int companyId);
        Task<Customer> GetCustomerById(int customerId);
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> UpdateCustomer(int customerId, Customer customer);
    }
}

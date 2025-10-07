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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> CreateCustomer(Customer customer)
        {
            var createdCustomer = _customerRepository.CreateCustomer(customer);
            
            return createdCustomer;
        }

        public Task<IEnumerable<Customer>> GetAllCustomersByCompany(int companyId)
        {
            var customers = _customerRepository.GetAllCustomersByCompany(companyId);
            
            return customers;
        }

        public Task<Customer> GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetCustomerById(customerId);
            
            return customer;
        }

        public Task<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            var updatedCustomer = _customerRepository.UpdateCustomer(customerId, customer);
            
            return updatedCustomer;
        }

    }
}

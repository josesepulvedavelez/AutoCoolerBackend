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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AutoCoolerContext _autoCoolerContext;

        public CustomerRepository(AutoCoolerContext autoCoolerContext)
        {
            _autoCoolerContext = autoCoolerContext;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            var customerEntry = await _autoCoolerContext.Customer.AddAsync(customer);
            await _autoCoolerContext.SaveChangesAsync();

            return customerEntry.Entity;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersByCompany(int companyId)
        {
            var customers = await _autoCoolerContext.Customer
                                   .Where(x => x.CompanyId == companyId)
                                   .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _autoCoolerContext.Customer
                                  .FirstOrDefaultAsync(c => c.CustomerId == customerId);

            return customer;
        }

        public Task<Customer> UpdateCustomer(int customerId, Customer customer)
        {
            var existingCustomer = _autoCoolerContext.Customer
                                    .FirstOrDefault(c => c.CustomerId == customerId);
            
            if (existingCustomer == null)
            {
                return Task.FromResult<Customer>(null);
            }
            
            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Email = customer.Email;
            existingCustomer.Observations = customer.Observations;
            
            _autoCoolerContext.Customer.Update(existingCustomer);
            _autoCoolerContext.SaveChanges();

            return Task.FromResult(existingCustomer);
        }

    }
}

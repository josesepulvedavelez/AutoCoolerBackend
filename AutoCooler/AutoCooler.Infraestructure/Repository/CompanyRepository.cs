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
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AutoCoolerContext _autoCoolerContext;

        public CompanyRepository(AutoCoolerContext autoCoolerContext) 
        {
            _autoCoolerContext = autoCoolerContext;
        }

        public async Task<Company> GetCompany(int companyId)
        {
            var company = await _autoCoolerContext.Company.FirstOrDefaultAsync(c => c.CompanyId == companyId);
            
            return company;
        }

        public async Task<Company> CreateCompany(Company company)
        {
            var companyEntry = await _autoCoolerContext.Company.AddAsync(company);
            await _autoCoolerContext.SaveChangesAsync();

            return companyEntry.Entity;
        }

        public async Task<Company> UpdateCompany(int companyId, Company company)
        {
            var existingCompany = await _autoCoolerContext.Company.FindAsync(companyId);
            
            if (existingCompany == null)
            {
                return null;
            }

            existingCompany.Name = company.Name;
            existingCompany.Address = company.Address;
            existingCompany.Phone = company.Phone;
            existingCompany.Email = company.Email;
            existingCompany.IsActive = company.IsActive;
            
            _autoCoolerContext.Company.Update(existingCompany);            
            await _autoCoolerContext.SaveChangesAsync();

            return existingCompany;
        }
    }
}

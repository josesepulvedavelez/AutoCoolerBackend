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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;
        }

        public Task<Company> GetCompany(int companyId)
        {
            var company = _companyRepository.GetCompany(companyId);

            return company;
        }

        public Task<Company> CreateCompany(Company company)
        {
            var createdCompany = _companyRepository.CreateCompany(company);
            
            return createdCompany;
        }

        public async Task<Company> UpdateCompany(int companyId, Company company)
        {
            var updatedCompany = await _companyRepository.UpdateCompany(companyId, company);

            return updatedCompany;
        }

    }
}

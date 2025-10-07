using AutoCooler.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCooler.Application.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);
        Task<Company> CreateCompany(Company company);
        Task<Company> UpdateCompany(int companyId, Company company);
    }
}

using MDERP.Business.IRepository;
using MDERP.Business.IService;
using MDERP.Business.Service.BASE;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Repository;
using SqlSugar;
using System.Linq.Expressions;

namespace MDERP.Business.Service
{
    public class CompanyService : BaseService<Sys_Company>,ICompanyService
    {
        private ICompanyRep companyRep;
        public CompanyService(ICompanyRep _companyRep) 
        {
            companyRep = _companyRep;
            this.baseRep = _companyRep;
        }

    }
}

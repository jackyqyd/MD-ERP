using MDERP.Business.IRepository;
using MDERP.Business.IService;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Repository;
using SqlSugar;
using System.Linq.Expressions;

namespace MDERP.Business.Service
{
    public class CompanyService : ICompanyService
    {
        ICompanyRep companyRep;

        public CompanyService(ISqlSugarClient _sqlSugarclient)
        {
            companyRep = new CompanyRep(_sqlSugarclient);
        }

        public async Task<int> AddCompany(Sys_Company sys_Company)
        {
            return await companyRep.Add(sys_Company);
        }

        public async Task<int> AddRangeCompany(List<Sys_Company> listEntity)
        {
            return await companyRep.Add(listEntity);
        }

        public async Task<bool> DeleteCompany(Sys_Company sys_Company)
        {
            return await companyRep.Delete(sys_Company);
        }

        public async Task<Sys_Company> GetModelById(object id)
        {
            return await companyRep.QueryById(id);
        }

        public async Task<PageModel<Sys_Company>> GetPageModel(Expression<Func<Sys_Company, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await companyRep.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<bool> UpdateCompany(Sys_Company sys_Company)
        {
            return await companyRep.Update(sys_Company);
        }

        public async Task<Sys_Company> GetModelByExpression(Expression<Func<Sys_Company, bool>> whereExpression)
        {
            var companyList = await companyRep.Query(whereExpression);
            return companyList.FirstOrDefault();
        }
    }
}

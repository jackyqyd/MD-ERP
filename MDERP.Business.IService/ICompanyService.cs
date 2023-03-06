using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.IService
{
    public interface ICompanyService
    {
        Task<Sys_Company> GetModelById(int id);
        
        Task<PageModel<Sys_Company>> GetPageModel(Expression<Func<Sys_Company, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<int> AddCompany(Sys_Company sys_Company);

        Task<int> AddRangeCompany(List<Sys_Company> listEntity);

        Task<bool> UpdateCompany(Sys_Company sys_Company);

        Task<bool> DeleteCompany(Sys_Company sys_Company);
    }
}

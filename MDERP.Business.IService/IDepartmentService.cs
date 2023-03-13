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
    public interface IDepartmentService
    {
        Task<Sys_Department> GetModelById(int deptID);

        Task<Sys_Department> GetModelByExpress(Expression<Func<Sys_Department, bool>> whereExpression);

        Task<PageModel<Sys_Department>> GetPageModel(Expression<Func<Sys_Department, bool>> whereExpression, int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);

        Task<int> AddDepartment(Sys_Department sys_Department);

        Task<int> AddRangeDepartment(List<Sys_Department> listEntity);

        Task<bool> UpdateDepartment(Sys_Department sys_Department);

        Task<bool> DeleteDepartment(Sys_Department sys_Department);
    }
}

using MDERP.Business.Models.Entities;
using MDERP.Business.Models;
using System.Linq.Expressions;
using MDERP.Business.Models.ViewModels;
using SqlSugar;
using MDERP.Business.IService.BASE;

namespace MDERP.Business.IService
{
    public interface IEmployeeInfoService : IBaseService<Sys_EmployeeInfo>
    {
        Task<PageModel<Sys_EmployeeInfoVM>> GetPageModelMuch(
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, JoinQueryInfos>> joinExpression,
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, Sys_EmployeeInfoVM>> selectExpression,
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, bool>> whereExpression,
            int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null);
    }
}

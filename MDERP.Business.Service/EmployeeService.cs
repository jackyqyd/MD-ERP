using MDERP.Business.IRepository;
using MDERP.Business.IService;
using MDERP.Business.Service.BASE;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using MDERP.Business.Models.ViewModels;
using MDERP.Business.Repository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Service
{
    public class EmployeeService : BaseService<Sys_EmployeeInfo>, IEmployeeInfoService
    {
        IEmployeeRep employeeRep;
        public EmployeeService(IEmployeeRep _employeeRep)
        {
            employeeRep = _employeeRep;
            this.baseRep = _employeeRep;
        }

        public async Task<PageModel<Sys_EmployeeInfoVM>> GetPageModelMuch(
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, JoinQueryInfos>> joinExpression,
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, Sys_EmployeeInfoVM>> selectExpression,
            Expression<Func<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, bool>> whereExpression,
            int intPageIndex = 1, int intPageSize = 20, string strOrderByFileds = null)
        {
            return await employeeRep.QueryMuch<Sys_EmployeeInfo, Sys_EmployeeDepartmentRel, Sys_Department, Sys_EmployeeInfoVM>(joinExpression, selectExpression, whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }
    }
}

using MDERP.Business.IService;
using MDERP.Business.IRepository;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using System.Linq.Expressions;
using MDERP.Business.Repository;
using SqlSugar;
using MDERP.Business.Models.ViewModels;


namespace MDERP.Business.Service
{
    public class DepartmentService : IDepartmentService
    {
        IDeparmentRep departmentRep;

        public DepartmentService(ISqlSugarClient _sqlSugarclient)
        {
            departmentRep = new DepartmentRep(_sqlSugarclient);
        }

        public async Task<int> AddDepartment(Sys_Department sys_Department)
        {
            return await departmentRep.Add(sys_Department);
        }

        public async Task<int> AddRangeDepartment(List<Sys_Department> listEntity)
        {
            return await departmentRep.Add(listEntity);
        }

        public async Task<bool> DeleteDepartment(Sys_Department sys_Department)
        {
            return await departmentRep.Delete(sys_Department);
        }

        public async Task<Sys_Department> GetModelByExpress(Expression<Func<Sys_Department, bool>> whereExpression)
        {
            var departmentList = await departmentRep.Query(whereExpression);
            return departmentList.FirstOrDefault();
        }

        public async Task<Sys_Department> GetModelById(object deptID)
        {
            return await departmentRep.QueryById(deptID);
        }

        public async Task<PageModel<Sys_Department>> GetPageModel(Expression<Func<Sys_Department, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            return await departmentRep.QueryPage(whereExpression, intPageIndex, intPageSize, strOrderByFileds);
        }

        public async Task<bool> UpdateDepartment(Sys_Department sys_Department)
        {
            return await departmentRep.Update(sys_Department);
        }
    }
}

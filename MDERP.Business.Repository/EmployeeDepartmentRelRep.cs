using MDERP.Business.IRepository;
using MDERP.Business.IRepository.UnitOfWork;
using MDERP.Business.Models.Entities;
using MDERP.Business.Repository.BASE;
using SqlSugar;

namespace MDERP.Business.Repository
{
    public class EmployeeDepartmentRelRep:BaseRepository<Sys_EmployeeDepartmentRel>,IEmployeeDepartmentRelRep
    {
        public EmployeeDepartmentRelRep(IUnitOfWork uinitOfWork,ISqlSugarClient _sqlSugarClient) : base(uinitOfWork, _sqlSugarClient) { }
    }
}

using MDERP.Business.IRepository;
using MDERP.Business.IRepository.UnitOfWork;
using MDERP.Business.Models.Entities;
using MDERP.Business.Repository.BASE;
using SqlSugar;

namespace MDERP.Business.Repository
{
    public class EmployeeRep:BaseRepository<Sys_EmployeeInfo>,IEmployeeRep
    {
        public EmployeeRep(IUnitOfWork uinitOfWork,ISqlSugarClient _sqlSugarClient) : base(uinitOfWork, _sqlSugarClient) { }
    }
}

using MDERP.Business.Repository.BASE;
using MDERP.Business.Models.Entities;
using MDERP.Business.IRepository;
using MDERP.Business.IRepository.UnitOfWork;
using SqlSugar;

namespace MDERP.Business.Repository
{
    public class CompanyRep : BaseRepository<Sys_Company>, ICompanyRep
    {
        public CompanyRep(IUnitOfWork uinitOfWork,ISqlSugarClient _sqlSugarClient) : base(uinitOfWork, _sqlSugarClient)
        { }
    }
}

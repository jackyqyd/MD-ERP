using MDERP.Business.IRepository;
using MDERP.Business.Models.Entities;
using MDERP.Business.Repository.BASE;
using SqlSugar;

namespace MDERP.Business.Repository
{
    public class DepartmentRep:BaseRepository<Sys_Department>,IDeparmentRep
    {
        public DepartmentRep(ISqlSugarClient _mydb) : base(_mydb) { }
    }
}

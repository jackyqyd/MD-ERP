using MDERP.Business.Repository.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDERP.Business.Models.Entities;
using MDERP.Business.IRepository;
using SqlSugar;

namespace MDERP.Business.Repository
{
    public class CompanyRep : BaseRepository<Sys_Company>, ICompanyRep
    {
        public CompanyRep(ISqlSugarClient _mydb) : base(_mydb) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MDERP.Business.IRepository.BASE;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;

namespace MDERP.Business.IRepository
{
    public interface ICompanyRep : IBaseRepository<Sys_Company>
    {
    }
}

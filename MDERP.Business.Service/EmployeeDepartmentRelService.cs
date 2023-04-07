using MDERP.Business.IRepository;
using MDERP.Business.IRepository.UnitOfWork;
using MDERP.Business.IService;
using MDERP.Business.Models.Entities;
using MDERP.Business.Service.BASE;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Service
{
    public class EmployeeDepartmentRelService:BaseService<Sys_EmployeeDepartmentRel>,IEmployeeDepartmentRelService
    {
        private IEmployeeDepartmentRelRep employeeDepartmentRelRep;

        public EmployeeDepartmentRelService(IEmployeeDepartmentRelRep _employeeDepartmentRelRep)
        {
            employeeDepartmentRelRep = _employeeDepartmentRelRep;
            this.baseRep = _employeeDepartmentRelRep;
        }
    }
}

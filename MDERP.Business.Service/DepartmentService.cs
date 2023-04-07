using MDERP.Business.IService;
using MDERP.Business.Service.BASE;
using MDERP.Business.IRepository;
using MDERP.Business.Models;
using MDERP.Business.Models.Entities;
using System.Linq.Expressions;
using MDERP.Business.Repository;
using SqlSugar;
using MDERP.Business.Models.ViewModels;


namespace MDERP.Business.Service
{
    public class DepartmentService : BaseService<Sys_Department>,IDepartmentService
    {
        private IDeparmentRep departmentRep;

        public DepartmentService(IDeparmentRep _departmentRep)
        {
            departmentRep = _departmentRep;
            this.baseRep = _departmentRep;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Models.ViewModels
{
    public class Sys_DepartmentVM
    {
        public string D_DeptId { get; set; }

        public string D_DeptNo { get; set; }

        public string D_DeptName { get; set; }

        public string D_Remark { get; set; }

        public string D_CompanyId { get; set; }

        public DateTime D_CreateDate { get; set; }

        public int D_IsEnabled { get; set; }

        public int D_IsDel { get; set; }
    }
}

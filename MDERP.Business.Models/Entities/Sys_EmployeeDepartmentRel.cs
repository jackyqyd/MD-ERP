using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Models.Entities
{
    [SugarTable("Sys_EmployeeDepartmentRel")]
    public partial class Sys_EmployeeDepartmentRel
    {
        public Sys_EmployeeDepartmentRel()
        {


        }
        /// <summary>
        /// Desc:
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true)]
        public string R_Id { get; set; } = string.Empty;

        public string E_Id { get; set; } = string.Empty;

        public string D_DeptId { get; set; } = string.Empty;


    }
}

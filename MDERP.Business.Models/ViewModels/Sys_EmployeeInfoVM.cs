using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Models.ViewModels
{
    public class Sys_EmployeeInfoVM
    {
        public string E_Id { get; set; } = string.Empty;

        public string E_Name { get; set; } = string.Empty;

        public string E_Gender { get; set; }

        public DateTime E_Birthday { get; set; }

        public string E_IDCard { get; set; } = string.Empty;

        public string E_Continent { get; set; } = string.Empty;

        public string E_Country { get; set; } = string.Empty;

        public string E_StateProvince { get; set; } = string.Empty;

        public string E_City { get; set; } = string.Empty;

        public string E_DetailAddress { get; set; } = string.Empty;

        public int E_IsMarried { get; set; }

        public string E_Education { get; set; } = string.Empty;

        public string E_Cellphone { get; set; } = string.Empty;

        public string E_LandLine { get; set; } = string.Empty;

        public string E_Fax { get; set; } = string.Empty;

        public string E_Email { get; set; } = string.Empty;

        public string D_Department { get; set; } = string.Empty;

        public DateTime E_CreateDate { get; set; }

        public int E_IsDel { get; set; }

        public int E_IsLock { get; set; }

    }
}

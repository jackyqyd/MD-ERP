using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MDERP.Business.Models.ViewModels
{
    public  class Sys_CompanyVM
    {
        public string C_Id { get; set; }

        public string C_Name { get; set; }

        public string C_Description { get; set; }

        public string C_ParentId { get; set; }

        public int C_IsSubCompany { get; set; }

        public string C_CompanyIcon { get; set; }

        public DateTime C_CreateTime { get; set; }

        public int C_IsDel { get; set; }
    }
}

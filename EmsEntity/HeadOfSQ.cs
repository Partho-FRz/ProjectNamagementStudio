using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class HeadOfSQ : Entity
    {
   //     public int Id { get; set; }
        /*
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }*/
        public string UserId { get; set; }
        public string EmployeeDesignation { get; set; }
    }
}

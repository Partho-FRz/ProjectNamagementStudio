using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Admin : Entity
    {
    //    public int Id { get; set; }

        /*    public int EmployeeId { get; set; }
            [ForeignKey("EmployeeId"),Index(IsUnique = true)]
            public Employee Employee { get; set; } */
        public string UserId { get; set; }
    }
}

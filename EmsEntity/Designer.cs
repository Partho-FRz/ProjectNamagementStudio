using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Designer : Entity
    {

   //     public int Id { get; set; }
        //      [Required]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public String LastName { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }


        public string ProjectId { get; set; }


        /*
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }*/

        //      public List<Project> Projects { get; set; }
    }
}

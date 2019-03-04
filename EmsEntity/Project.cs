using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Project : Entity
    {
     //   public int Id { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Budget { get; set; }
        [Required]
        public string ProjectStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [NotMapped]
        public List<Link> Links { get; set; }





        /*
                public int ClientId { get; set; }
                [ForeignKey("ClientId")]
                public Client Client { get; set; }
                public int EmployeeId { get; set; }
                [ForeignKey("EmployeeId")]
                public Employee Employee { get; set; } */

        //      public string EmployeeDesignation { get; set; }



    }
}

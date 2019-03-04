using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Employee : Entity
    {


     //   public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public String LastName { get; set; }

        public DateTime WorkingSince { get; set; }
        [Required]
        public String Email { get; set; }

        public double Salary { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public DateTime DOB { get; set; }


        public string ProjectId { get; set; }




        public string UserId { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string NID { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Password { get; set; }

        public byte[] Picture { get; set; }
        //public HttpPostedFileBase ImageFile { get; set; }

        /*
        public List<Admin> Admins { get; set; }
        public List<ProjectManager> ProjectManagers { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Designer> Designers { get; set; }
        public List<HeadOfSQ> HeadOfSQs { get; set; }

        public List<Project> Projects { get; set; }*/

        [NotMapped]
        public List<Link> Links { get; set; }

    }
}

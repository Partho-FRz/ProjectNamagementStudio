using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Client : Entity
    {

     //   public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public String LastName { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public double Budget { get; set; }
        [Required]
        public String Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string LoginId { get; set; }
        [Required]
        public string NID { get; set; }
        [Required, MaxLength(50), MinLength(2)]
        public string Password { get; set; }

        public byte[] Picture { get; set; }
        /*    public List<Project> Projects { get; set; }*/
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsEntity
{
    public class Feed : Entity
    {
        [MaxLength(100)]
        public string Homepost { get; set; }
        [MaxLength(100)]
        public string Newspost { get; set; }
        public string UserId { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string time { get; set;}

        
    }
}

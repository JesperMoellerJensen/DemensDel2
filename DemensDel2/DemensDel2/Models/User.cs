using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemensDel2.Models
{
    public class User
    {
        public long Id { get; set; }

        //Reference to User Identity data
        public string UserIdentityID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public int TelephoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        public Log Log { get; set; }
    }
}

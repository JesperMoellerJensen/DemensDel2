using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemensDel2.Models
{
    public class User
    {
        // Primary Key
        public int Id { get; set; }

        //Reference to User Identity data
        public string UserIdentityID { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public int TelephoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        // Navigation properties
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}

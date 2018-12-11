using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class TrainingSession
    {
        // Primary Key
        public int Id { get; set; }

        public double Percent = 1;
        public DateTime Date { get; set; }

        // Navigation properties
        public virtual Log Log { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}

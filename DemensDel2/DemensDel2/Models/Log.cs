using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class Log
    {
        // Primary Key
        public int Id { get; set; }

        // Foreign Key
        public int UserId { get; set; }


        // Navigation properties
        public virtual User User { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}

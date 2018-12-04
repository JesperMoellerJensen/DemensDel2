using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class Log
    {
        public long Id { get; set; }

        public long UserForeignKey { get; set; }
        public User User { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}

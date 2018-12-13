using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class UserTrainingSessionRelation
    {
        public virtual User Users { get; set; }
        public virtual TrainingSession TrainingSessions { get; set; }
        public virtual double Percent { get; set; }
        

    }
}

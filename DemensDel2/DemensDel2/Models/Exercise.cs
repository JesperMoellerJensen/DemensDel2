using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class Exercise
    {
        public long Id { get; set; }

        public double ExecutionRate { get; set; }
        public int PaintLevel { get; set; }
        public int Effort { get; set; }

        public TrainingSession TrainingSession { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}

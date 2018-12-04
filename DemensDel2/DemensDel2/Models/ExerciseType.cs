using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class ExerciseType
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public float Duration { get; set; }
        public string Description { get; set; }
        public string MuscleGroup { get; set; }
        public int Difficulty { get; set; }
    }
}

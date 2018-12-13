using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class ExerciseDTO
    {
        public Dictionary<int, string> ExerciseNames { get; set; }

        public Exercise SlectedExercise { get; set; }
        //public double ExecutionRate { get; set; }
        //public int PaintLevel { get; set; }
        //public int Effort { get; set; }
        //public string Name { get; set; }
        //public float Duration { get; set; }
        //public string Description { get; set; }
        //public string MuscleGroup { get; set; }
        //public int Difficulty { get; set; }
    }
}

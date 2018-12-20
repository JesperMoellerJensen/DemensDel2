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

        public ExerciseResult ExerciseResult { get; set; }
    }
}

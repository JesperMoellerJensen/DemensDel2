using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models.DTO
{
    public class NewExercise
    {
        public double ExecutionRate { get; set; }
        public int PaintLevel { get; set; }
        public int Effort { get; set; }

        public ExerciseType ExerciseType { get; set; }

        public IList<SelectListItem> ExerciseTypes { get; set; }

        public int ExerciseNr { get; set; } = 1;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models.DTO
{
    public class NewTrainingSession
    {
       public DateTime Date { get; set; }

       public List<NewExercise> NewExercises { get; set; }

        public NewExercise NewExercise { get; set; }
    }
}

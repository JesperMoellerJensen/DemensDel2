using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class TrainingSession
    {
        public long Id { get; set; }

        public double Percent => Exercises.Sum(e => e.ExecutionRate) / Exercises.Count;
        public DateTime Date { get; set; }

        public Log Log { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}

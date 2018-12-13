using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemensDel2.Models
{
    public class Exercise
    {
        // Primary Key
        public int Id { get; set; }

        public double ExecutionRate { get; set; }
        public int PaintLevel { get; set; }
        public int Effort { get; set; }
        [Timestamp]
        public  byte[] RowVersion { get; set; }

        // Navigation properties
        public virtual TrainingSession TrainingSession { get; set; }
        public virtual ExerciseType ExerciseType { get; set; }
    }
}

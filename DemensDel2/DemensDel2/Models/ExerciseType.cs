using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class ExerciseType
    {
        // Primary Key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string MuscleGroup { get; set; }
        [Required]
        public int Difficulty { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

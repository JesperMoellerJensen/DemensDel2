using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class ExerciseResult
    {
        //Primary Key
        public int Id { get; set; }
        [Required]
        public double ExecutionRate { get; set; }
        [Required]
        public int PaintLevel { get; set; }
        [Required]
        public int Effort { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public virtual Exercise Exercise { get; set; }
        public virtual User User { get; set; }
    }
}

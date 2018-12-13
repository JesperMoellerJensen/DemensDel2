using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class TrainingSession
    {
        // Primary Key
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}

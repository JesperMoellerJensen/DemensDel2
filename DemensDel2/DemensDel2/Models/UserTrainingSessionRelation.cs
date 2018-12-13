using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models
{
    public class UserTrainingSessionRelation
    {
        public int UserId { get; set; }
        public int TrainingSessionId { get; set; }
        public virtual double Percent { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }


    }
}

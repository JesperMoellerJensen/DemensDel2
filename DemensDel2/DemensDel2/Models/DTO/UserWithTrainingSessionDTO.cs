using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemensDel2.Models.DTO
{
    public class UserWithTrainingSessionDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int TelephoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public List<TrainingSession> TrainingSessions { get; set; }
    }
}

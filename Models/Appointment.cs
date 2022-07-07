using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FranChallenge.Models
{
    public class Appointment
    {
        [KeyAttribute]
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public Patient patient { get; set; }
        public int patientId { get; set; }
        public Office office { get; set; }
        public int officeId { get; set; }


    }
}
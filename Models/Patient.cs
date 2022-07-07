using System.Collections.Generic;

namespace FranChallenge.Models
{
    public class Patient : Person
    {
        public List<Appointment> Appointments { get; set; }

    }
}
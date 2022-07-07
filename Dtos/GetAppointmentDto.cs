using System;
using FranChallenge.Models;

namespace FranChallenge.Dtos
{
    public class GetAppointmentDto
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int patientId { get; set; }
        public int officeId { get; set; }
    }
}
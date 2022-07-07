namespace FranChallenge.Models
{
    public class AppointmentPatient
    {
        public Appointment Appointment {get;set;}

        public int AppointmentId {get;set;}
        public Patient Patient {get;set;}

        public int PatientId {get;set;}

    }
}
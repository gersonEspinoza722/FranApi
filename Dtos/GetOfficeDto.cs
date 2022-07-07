using System.Collections.Generic;
using FranChallenge.Models;

namespace FranChallenge.Dtos
{
    public class GetOfficeDto
    {
        public int id {get;set;}
        public int officeNumber {get;set;}
        public List<Appointment> Appointments{ get; set; }    
    }
}
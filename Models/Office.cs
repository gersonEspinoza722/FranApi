using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FranChallenge.Models
{
    public class Office
    {
        [KeyAttribute]
        public int id {get;set;}
        public int officeNumber {get;set;}
    }
}
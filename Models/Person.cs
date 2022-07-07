using System.ComponentModel.DataAnnotations;

namespace FranChallenge.Models
{
    public abstract class Person
    {
        [KeyAttribute]
        public int id {get;set;}
        public string name {get;set;}
        
    }
}
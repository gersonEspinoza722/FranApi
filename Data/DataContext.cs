using FranChallenge.Models;
using Microsoft.EntityFrameworkCore;


namespace FranChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
            
        }
        public DbSet<Patient> Patients {get;set;}
        public DbSet<Office> Offices {get;set;}
        public DbSet<Doctor> Doctors {get;set;}
        public DbSet<Appointment> Appointments {get;set;}



        
    }
}
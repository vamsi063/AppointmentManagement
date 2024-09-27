using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace AppointmentManagementSystem
{
    public class DataSeeder
    {
        public static void SeedCountries(AppDbContext context)
        {
            if (!context.Doctors.Any())
            {
                var doctors = new List<Doctor>
                {
                    new Doctor { Name= "Praveen", Address="Hyderabad", IsAvailable=true, Phone="123456789" , PhysicianId ="1", Appointments= new List<Appointment>(), SpecializationId = 1}
                };
                context.AddRange(doctors);
                context.SaveChanges();
            }
        }
    }
}

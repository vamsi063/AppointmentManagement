using Domain;
using Infrastructure.IRespositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {

        private readonly AppDbContext _appDbContext;

        public AppointmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(Appointment appointment)
        {
            _appDbContext.Appointments.Add(appointment);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appDbContext.Appointments
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }

        public IEnumerable<Appointment> GetAppointmentWithPatient(int id)
        {
            return _appDbContext.Appointments
                .Where(p => p.PatientId == id)
                .Include(p => p.Patient)
                .Include(d => d.Doctor)
                .ToList();
        }

        public int CountAppointments(int id)
        {
            return _appDbContext.Appointments.Count(a => a.PatientId == id);
        }

        public bool ValidateAppointment(DateTime appntDate, int id)
        {
            return _appDbContext.Appointments.Any(a => a.StartDateTime == appntDate && a.DoctorId == id);
        }
    }
}

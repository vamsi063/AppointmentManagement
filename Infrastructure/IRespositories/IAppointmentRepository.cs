using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRespositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        IEnumerable<Appointment> GetAppointmentWithPatient(int id);
        int CountAppointments(int id);
        void Add(Appointment appointment);
        bool ValidateAppointment(DateTime appntDate, int id);
    }
}

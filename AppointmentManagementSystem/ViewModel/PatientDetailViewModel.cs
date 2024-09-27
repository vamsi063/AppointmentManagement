using Domain;

namespace AppointmentManagementSystem.ViewModel
{
    public class PatientDetailViewModel
    {
        public Patient Patient { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

        public int CountAppointments { get; set; }
    }
}

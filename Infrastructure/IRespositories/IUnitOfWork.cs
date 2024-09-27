using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRespositories
{
    public interface IUnitOfWork
    {
        IAppointmentRepository Appointments { get; }

        IPatientRepository Patients { get; }

        IDoctorRepository  Doctors { get; }

        ICityRepository Cities { get; }

        void Complete();


    }
}

using Infrastructure.IRespositories;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IAppointmentRepository Appointments { get; private set; }

        public IPatientRepository Patients { get; private set; }

        public IDoctorRepository Doctors { get; private set; }

        public ICityRepository Cities { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Appointments = new AppointmentRepository(context);
            Doctors = new DoctorRepository(context);
            Patients = new PatientRepository(context);
            Cities = new CityRepository(context);
            //Users = new ApplicationUserRepository(context);

        }
        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}

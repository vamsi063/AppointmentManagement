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
    public class DoctorRepository : IDoctorRepository
    {

        private readonly AppDbContext _appContext;
        public DoctorRepository(AppDbContext appContext) { 
          _appContext = appContext;
        }
        public void Add(Doctor doctor)
        {
            _appContext.Doctors.Add(doctor);
        }

        public IEnumerable<Doctor> GetAvailableDoctors()
        {
            return _appContext.Doctors
                .Where(a => a.IsAvailable == true)
                .ToList();
        }

        public Doctor GetDoctor(int id)
        {
            return _appContext.Doctors
                .SingleOrDefault(d => d.Id == id);
        }
    }
}

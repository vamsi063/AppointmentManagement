using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRespositories
{
    public interface IDoctorRepository
    {
        Doctor GetDoctor(int id);
        IEnumerable<Doctor> GetAvailableDoctors();
        void Add(Doctor doctor);
    }
}

using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRespositories
{
    public interface IPatientRepository
    {
        Patient GetPatient(int id);
        IEnumerable<Patient> GetPatients();
        void Add(Patient patient);
    }
}

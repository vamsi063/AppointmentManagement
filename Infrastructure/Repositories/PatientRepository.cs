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
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context) {  _context = context; }
        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _context.Patients.Include(c => c.Cities);
        }

        public Patient GetPatient(int id)
        {
            return _context.Patients
                .Include(c => c.Cities)
                .SingleOrDefault(p => p.Id == id);
            //return _context.Patients.Find(id);
        }
    }
}

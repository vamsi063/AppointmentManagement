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
    
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;
        public CityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<City> GetCities()
        {
            var data = _appDbContext.Appointments.ToList();
            return _appDbContext.City.ToList();
        }
    }
}

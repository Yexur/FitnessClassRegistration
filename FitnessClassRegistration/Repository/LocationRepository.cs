using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using FitnessClassRegistration.Data;
using FitnessClassRegistration.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FitnessClassRegistration.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private FitnessAppDbContext _context;
        public LocationRepository(FitnessAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Location>> All()
        {
            return await _context.Location.ToListAsync();
        }

        public void Delete(int id)
        {
            var location = FindById(id);
            _context.Remove(location);
            _context.SaveChanges();
        }

        public Location FindById(int id)
        {
            return _context.Location.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(Location location)
        {
            if (location.Id > 0)
            {
                location.Updated = DateTime.Now;
                _context.Update(location);
            } else
            {
                location.Created = DateTime.Now;
                location.Updated = DateTime.Now;
                _context.Add(location);
            }
            await _context.SaveChangesAsync();
        }

        public bool LocationExists(int id)
        {
            return _context.Location.Any(e => e.Id == id);
        }
    }
}

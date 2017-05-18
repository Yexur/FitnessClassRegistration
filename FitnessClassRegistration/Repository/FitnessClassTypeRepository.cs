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
    public class FitnessClassTypeRepository : IFitnessClassTypeRepository
    {
        private FitnessAppDbContext _context;
        public FitnessClassTypeRepository(FitnessAppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<FitnessClassType>> All()
        {
            return await _context.FitnessClassType.ToListAsync();
        }

        public FitnessClassType FindById(int id)
        {
            return _context.FitnessClassType.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(FitnessClassType fitnessClassType)
        {
            if (fitnessClassType.Id > 0)
            {
                fitnessClassType.Updated = DateTime.Now;
                _context.Update(fitnessClassType);
            }
            else
            {
                fitnessClassType.Created = DateTime.Now;
                fitnessClassType.Updated = DateTime.Now;
                _context.Add(fitnessClassType);
            }
            await _context.SaveChangesAsync();
        }

        public bool FitnessClassTypeExists(int id)
        {
            return _context.FitnessClassType.Any(e => e.Id == id);
        }
    }
}

using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Repository
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

        public void Delete(int id)
        {
            var fitnessClassType = FindById(id);
            _context.Remove(fitnessClassType);
            _context.SaveChanges();
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

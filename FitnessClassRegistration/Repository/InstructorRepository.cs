using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private FitnessAppDbContext _context;
        public InstructorRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Instructor>> All()
        {
            return await _context.Instructor.ToListAsync();
        }

        public void Delete(int id)
        {
            var instructor = FindById(id);
            _context.Remove(instructor);
            _context.SaveChanges();
        }

        public Instructor FindById(int id)
        {
            return _context.Instructor.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(Instructor instructor)
        {
            if (instructor.Id > 0)
            {
                instructor.Updated = DateTime.Now;
                _context.Update(instructor);
            } else
            {
                instructor.Updated = DateTime.Now;
                instructor.Created = DateTime.Now;
                _context.Add(instructor);
            }
            await _context.SaveChangesAsync();
        }

        public bool InstructorExists(int id)
        {
            return _context.Instructor.Any(e => e.Id == id);
        }
    }
}

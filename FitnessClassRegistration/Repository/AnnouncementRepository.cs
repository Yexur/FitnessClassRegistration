using FitnessApp.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using FitnessApp.Data;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Repository
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private FitnessAppDbContext _context;

        public AnnouncementRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> All()
        {
            return await _context.Announcement.ToListAsync();
        }

        public bool AnnouncementExists(int id)
        {
            return _context.Announcement.Any(e => e.Id == id);
        }

        public void Delete(int id)
        {
            var announcement = FindById(id);
            _context.Remove(announcement);
            _context.SaveChanges();
        }

        public Announcement FindById(int id)
        {
            return _context.Announcement.SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(Announcement announcement)
        {
            if (announcement.Id > 0)
            {
                announcement.Updated = DateTime.Now;
                _context.Update(announcement);
            } else
            {
                announcement.Created = DateTime.Now;
                announcement.Updated = DateTime.Now;
                _context.Add(announcement);
            }
            await _context.SaveChangesAsync();
        }
    }
}

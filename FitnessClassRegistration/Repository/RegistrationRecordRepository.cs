﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using FitnessClassRegistration.Data;
using FitnessClassRegistration.IRepository;
using Microsoft.EntityFrameworkCore;

namespace FitnessClassRegistration.Repository
{
    public class RegistrationRecordRepository : IRegistrationRecordRepository
    {
        private FitnessAppDbContext _context;
        public RegistrationRecordRepository(FitnessAppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RegistrationRecord>> All()
        {
            return await _context.RegistrationRecord
                .Include(f => f.FitnessClass)
                .OrderBy(f => f.Email)
                .ToListAsync();
        }

        public async Task<List<RegistrationRecord>> FindByUserName(string userName)
        {
            return await _context.RegistrationRecord.Where(r => r.UserName == userName)
                .Include(r => r.FitnessClass).ToListAsync();
        }

        public async Task<List<RegistrationRecord>> FindByFitnessClassId(int fitnessClassId)
        {
            return await _context.RegistrationRecord
                .Where(r => r.FitnessClass_Id == fitnessClassId)
                .Include(f => f.FitnessClass)
                .Include(t => t.FitnessClass.FitnessClassType)
                .ToListAsync();
        }

        public void Delete(int id)
        {
            var registration = FindById(id);
            if (registration != null)
            {
                _context.Remove(registration);
                _context.SaveChanges();
            }
        }

        public void DeleteRange(List<RegistrationRecord> recordsToDelete)
        {
            if (recordsToDelete != null && recordsToDelete.Any())
            {
                _context.RemoveRange(recordsToDelete);
                _context.SaveChanges();
            }
        }

        public List<RegistrationRecord> FindByIdRange(List<int> ids)
        {
            return _context.RegistrationRecord
                .Include(f => f.FitnessClass)
                .Where(r => ids.Contains(r.Id)).ToList();
        }

        public RegistrationRecord FindById(int id)
        {
            return _context.RegistrationRecord
                .Include(f => f.FitnessClass)
                .SingleOrDefault(m => m.Id == id);
        }

        public async Task Insert(RegistrationRecord registrationRecord)
        {
            if (registrationRecord.Id > 0)
            {
                registrationRecord.Updated = DateTime.Now;
                _context.Update(registrationRecord);
            } else
            {
                registrationRecord.Updated = DateTime.Now;
                registrationRecord.Created = DateTime.Now;
                registrationRecord.Attended = false;
                _context.Add(registrationRecord);
            }
            await _context.SaveChangesAsync();
        }

        public async Task InsertRange(List<RegistrationRecord> registrationRecords)
        {
            var updateRegistrations = registrationRecords.FindAll(r => r.Id > 0);
            var addNewRegistrations = registrationRecords.FindAll(r => r.Id == 0);

            if (addNewRegistrations != null && addNewRegistrations.Count() != 0)
            {
                _context.AddRange(addNewRegistrations);
            }

            if (updateRegistrations != null && updateRegistrations.Count() != 0)
            {
                _context.UpdateRange(updateRegistrations);
            }
            await _context.SaveChangesAsync();
        }
    }
}

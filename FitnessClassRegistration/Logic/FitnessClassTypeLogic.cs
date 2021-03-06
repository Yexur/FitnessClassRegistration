﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using AutoMapper;
using FitnessClassRegistration.IRepository;
using FitnessClassRegistration.Models.ApplicationViewModels;

namespace FitnessClassRegistration.Logic
{
    public class FitnessClassTypeLogic : IFitnessClassTypeLogic
    {
        private readonly IFitnessClassTypeRepository _fitnessClassTypeRepository;

        public FitnessClassTypeLogic(IFitnessClassTypeRepository fitnessClassTypeRepository)
        {
            _fitnessClassTypeRepository = fitnessClassTypeRepository;
        }

        public FitnessClassTypeView FindById(int id)
        {
            var fitnessClassType = _fitnessClassTypeRepository.FindById(id);
            return Mapper.Map<FitnessClassTypeView>(fitnessClassType);
        }

        public async Task<List<FitnessClassTypeView>> GetList()
        {
            var fitnessClassesTypes = await _fitnessClassTypeRepository.All();

            if (fitnessClassesTypes == null || !fitnessClassesTypes.Any())
            {
                return Enumerable.Empty<FitnessClassTypeView>().ToList();
            }
            return Mapper.Map<List<FitnessClassTypeView>>(fitnessClassesTypes); ;
        }

        public async Task Save(FitnessClassTypeView fitnessClassTypeView)
        {
            var fitnessClassType = Mapper.Map<FitnessClassType>(fitnessClassTypeView);
            await _fitnessClassTypeRepository.Insert(fitnessClassType);
        }

        public void Delete(int id)
        {
            _fitnessClassTypeRepository.Delete(id);
        }

        public bool FitnessClassTypeExists(int id)
        {
            return _fitnessClassTypeRepository.FitnessClassTypeExists(id);
        }
    }
}

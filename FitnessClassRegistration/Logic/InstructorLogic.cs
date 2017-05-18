using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using AutoMapper;
using FitnessClassRegistration.IRepository;
using FitnessClassRegistration.Models.ApplicationViewModels;

namespace FitnessClassRegistration.Logic
{
    public class InstructorLogic : IInstructorLogic
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorLogic(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public InstructorView FindById(int id)
        {
            var instructor = _instructorRepository.FindById(id);
            return Mapper.Map<InstructorView>(instructor);
        }

        public async Task<List<InstructorView>> GetList()
        {
            var instructors = await _instructorRepository.All();

            if (instructors == null || !instructors.Any())
            {
                return Enumerable.Empty<InstructorView>().ToList();
            }

            return Mapper.Map<List<InstructorView>>(instructors); ;
        }

        public async Task Save(InstructorView instructorView)
        {
            var instructor = Mapper.Map<Instructor>(instructorView);
            await _instructorRepository.Insert(instructor);
        }

        public bool InstructorExists(int id)
        {
            return _instructorRepository.InstructorExists(id);
        }
    }
}

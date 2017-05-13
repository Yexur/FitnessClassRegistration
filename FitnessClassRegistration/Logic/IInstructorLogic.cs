using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClassRegistration.Models.ApplicationViewModels;

namespace FitnessClassRegistration.Logic
{
    public interface IInstructorLogic
    {
        InstructorView FindById(int id);
        Task<List<InstructorView>> GetList();
        Task Save(InstructorView instructor);
        void Delete(int id);
        bool InstructorExists(int id);
    }
}

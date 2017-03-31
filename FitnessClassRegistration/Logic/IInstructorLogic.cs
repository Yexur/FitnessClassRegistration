using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
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

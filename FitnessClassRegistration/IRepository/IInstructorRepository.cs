using System.Collections.Generic;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;

namespace FitnessApp.IRepository
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> All();
        Task Insert(Instructor instructor);
        void Delete(int id);
        Instructor FindById(int id);
        bool InstructorExists(int id);
    }
}

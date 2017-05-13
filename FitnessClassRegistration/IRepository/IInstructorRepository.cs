using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;

namespace FitnessClassRegistration.IRepository
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

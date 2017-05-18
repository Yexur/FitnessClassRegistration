using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;

namespace FitnessClassRegistration.IRepository
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> All();
        Task Insert(Instructor instructor);
        Instructor FindById(int id);
        bool InstructorExists(int id);
    }
}

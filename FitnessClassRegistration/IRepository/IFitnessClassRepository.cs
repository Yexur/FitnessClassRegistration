using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;

namespace FitnessApp.IRepository
{
    public interface IFitnessClassRepository
    {
        Task<List<FitnessClass>> All();
        Task<List<FitnessClass>> AllAvailable(string userName);
        Task<List<FitnessClass>> AllFitnessClassWithRegistrations();
        Task<List<FitnessClass>> RegistrationsByUserName(string userName);
        Task Insert(FitnessClass fitnessClass);
        void Delete(int id);
        FitnessClass FindById(int id);
        bool FitnessClassExists(int id);
        bool UpdateCapacity(int id, bool increaseRemainingCapacity);
    }
}

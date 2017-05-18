using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;

namespace FitnessClassRegistration.IRepository
{
    public interface IFitnessClassTypeRepository
    {
        Task<List<FitnessClassType>> All();
        Task Insert(FitnessClassType fitnessClassType);
        FitnessClassType FindById(int id);
        bool FitnessClassTypeExists(int id);
    }
}

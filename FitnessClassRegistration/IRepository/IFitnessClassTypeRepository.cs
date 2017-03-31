using System.Collections.Generic;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;

namespace FitnessApp.IRepository
{
    public interface IFitnessClassTypeRepository
    {
        Task<List<FitnessClassType>> All();
        Task Insert(FitnessClassType fitnessClassType);
        void Delete(int id);
        FitnessClassType FindById(int id);
        bool FitnessClassTypeExists(int id);
    }
}

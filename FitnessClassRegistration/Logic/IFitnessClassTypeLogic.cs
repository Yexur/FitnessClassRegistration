using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassTypeView FindById(int id);
        Task<List<FitnessClassTypeView>> GetList();
        Task Save(FitnessClassTypeView fitnessClassType);
        bool FitnessClassTypeExists(int id);
        void Delete(int id);
    }
}

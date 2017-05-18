using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClassRegistration.Models.ApplicationViewModels;

namespace FitnessClassRegistration.Logic
{
    public interface IFitnessClassTypeLogic
    {
        FitnessClassTypeView FindById(int id);
        Task<List<FitnessClassTypeView>> GetList();
        Task Save(FitnessClassTypeView fitnessClassType);
        bool FitnessClassTypeExists(int id);
    }
}

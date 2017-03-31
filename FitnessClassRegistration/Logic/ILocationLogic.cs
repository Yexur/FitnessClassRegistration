using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
    public interface ILocationLogic
    {
        LocationView FindById(int id);
        Task<List<LocationView>> GetList();
        Task Save(LocationView location);
        void Delete(int id);
        bool LocationExists(int id);
    }
}

using ApplicationModels.FitnessApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.IRepository
{
    public interface ILocationRepository
    {
        Task<List<Location>> All();
        Task Insert(Location location);
        void Delete(int id);
        Location FindById(int id);
        bool LocationExists(int id);
    }
}

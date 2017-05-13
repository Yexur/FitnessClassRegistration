using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;

namespace FitnessClassRegistration.IRepository
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> All();
        Task Insert(Announcement location);
        void Delete(int id);
        Announcement FindById(int id);
        bool AnnouncementExists(int id);
    }
}

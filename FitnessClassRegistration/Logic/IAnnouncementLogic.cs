using FitnessClassRegistration.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessClassRegistration.Logic
{
    public interface IAnnouncementLogic
    {
        AnnouncementView FindById(int id);
        Task<List<AnnouncementView>> GetList();
        Task Save(AnnouncementView location);
        void Delete(int id);
        bool AnnouncementExists(int id);
    }
}

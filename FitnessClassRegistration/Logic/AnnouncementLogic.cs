using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Models.ApplicationViewModels;
using FitnessApp.IRepository;
using AutoMapper;
using ApplicationModels.FitnessApp.Models;

namespace FitnessApp.Logic
{
    public class AnnouncementLogic : IAnnouncementLogic
    {
        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementLogic(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public bool AnnouncementExists(int id)
        {
            return _announcementRepository.AnnouncementExists(id);
        }

        public void Delete(int id)
        {
            _announcementRepository.Delete(id);
        }

        public AnnouncementView FindById(int id)
        {
            var announcement = _announcementRepository.FindById(id);
            return Mapper.Map<AnnouncementView>(announcement);
        }

        public async Task<List<AnnouncementView>> GetList()
        {
            var annoucements = await _announcementRepository.All();
            if (annoucements == null || !annoucements.Any())
            {
                return Enumerable.Empty<AnnouncementView>().ToList();
            }
            return Mapper.Map<List<AnnouncementView>>(annoucements);
        }

        public async Task Save(AnnouncementView annoucementsView)
        {
            var annoucement = Mapper.Map<Announcement>(annoucementsView);
            await _announcementRepository.Insert(annoucement);
        }
    }
}

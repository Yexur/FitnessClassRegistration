using System.Linq;
using FitnessApp.IRepository;
using ApplicationModels.FitnessApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using FitnessApp.Models.ApplicationViewModels;

namespace FitnessApp.Logic
{
    public class LocationLogic : ILocationLogic
    {
        private readonly ILocationRepository _locationRepository;

        public LocationLogic(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public LocationView FindById(int id)
        {
            var location = _locationRepository.FindById(id);
            return Mapper.Map<LocationView>(location);
        }

        public async Task<List<LocationView>> GetList()
        {
            var locations = await _locationRepository.All();

            if (locations == null || !locations.Any())
            {
                return Enumerable.Empty<LocationView>().ToList();
            }
            return Mapper.Map<List<LocationView>>(locations); ;
        }

        public async Task Save(LocationView locationView)
        {
            var location = Mapper.Map<Location>(locationView);
            await _locationRepository.Insert(location);
        }

        public void Delete(int id)
        {
            _locationRepository.Delete(id);
        }

        public bool LocationExists(int id)
        {
            return _locationRepository.LocationExists(id);
        }
    }
}

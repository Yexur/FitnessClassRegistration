using ApplicationModels.FitnessApp.Models;
using FitnessApp.IRepository;
using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using AutoMapper;

namespace FitnessApp.Logic
{
    public class FitnessClassLogic : IFitnessClassLogic
    {
        private readonly IFitnessClassRepository _fitnessClassRepository;
        private readonly IInstructorLogic _instructorLogic;
        private readonly IFitnessClassTypeLogic _fitnessClassTypeLogic;
        private readonly ILocationLogic _locationLogic;

        public FitnessClassLogic(
            IFitnessClassRepository fitnessClassRepository,
            IInstructorLogic instructorLogic,
            IFitnessClassTypeLogic fitnessClassTypeLogic,
            ILocationLogic locationLogic
        )
        {
            _fitnessClassRepository = fitnessClassRepository;
            _instructorLogic = instructorLogic;
            _fitnessClassTypeLogic = fitnessClassTypeLogic;
            _locationLogic = locationLogic;
        }

        public async Task<FitnessClassEditView> Create()
        {
            return new FitnessClassEditView
            {
                FitnessClassTypes = await GetFitnessClassTypes(),
                Locations = await GetLocations(),
                Instructors = await GetInstructors()
            };
        }

        public async Task<FitnessClassEditView> FindById(int id)
        {
            var fitnessClass = _fitnessClassRepository.FindById(id);
            var fitnessClassView = Mapper.Map<FitnessClassEditView>(fitnessClass);
            fitnessClassView.FitnessClassTypes = await GetFitnessClassTypes();
            fitnessClassView.Instructors = await GetInstructors();
            fitnessClassView.Locations = await GetLocations();
            return fitnessClassView;
        }

        public FitnessClassListView FindByIdForDelete(int id) {
            var fitnessClass = _fitnessClassRepository.FindById(id);
            var fitnessClassView = Mapper.Map<FitnessClassListView>(fitnessClass);
            return fitnessClassView;
        }

        public async Task<List<FitnessClassListView>> GetList()
        {
            var fitnessClasses = await _fitnessClassRepository.All();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassListView>().ToList();
            }
            return Mapper.Map<List<FitnessClassListView>>(fitnessClasses);
        }

        public async Task<List<FitnessClassListView>> GetFitnessClassWithRegistrations()
        {
            var fitnessClasses = await _fitnessClassRepository.AllFitnessClassWithRegistrations();

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassListView>().ToList();
            }
            return Mapper.Map<List<FitnessClassListView>>(fitnessClasses);
        }

        public async Task<List<FitnessClassSignUpView>> GetAvailableClasses(string userName)
        {
            var fitnessClasses = await _fitnessClassRepository.AllAvailable(userName);

            if (fitnessClasses == null || !fitnessClasses.Any())
            {
                return Enumerable.Empty<FitnessClassSignUpView>().ToList();
            }
            return Mapper.Map<List<FitnessClassSignUpView>>(fitnessClasses);
        }

        public async Task Save(FitnessClassEditView fitnessClassView)
        {
            var fitnessClass = Mapper.Map<FitnessClass>(fitnessClassView);
            await _fitnessClassRepository.Insert(fitnessClass);
        }

        public void Delete(int id)
        {
            _fitnessClassRepository.Delete(id);
        }

        public bool FitnessClassExists(int id)
        {
            return _fitnessClassRepository.FitnessClassExists(id);
        }

//MS THESE NEED TO CHANGE TO GET ONLY THE ACTIVE ONES
        public async Task<ICollection<SelectListItem>> GetLocations()
        {
            var locations = await _locationLogic.GetList();
            var locationSelectList = locations.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(locationSelectList);
        }

        //MS THESE NEED TO CHANGE TO GET ONLY THE ACTIVE ONES
        public async Task<ICollection<SelectListItem>> GetInstructors()
        {
            var instructors = await _instructorLogic.GetList();
            var instructorSelectList = instructors.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(instructorSelectList);
        }


        //MS THESE NEED TO CHANGE TO GET ONLY THE ACTIVE ONES
        public async Task<ICollection<SelectListItem>> GetFitnessClassTypes()
        {
            var fitnessClassTypes = await _fitnessClassTypeLogic.GetList();
            var fitnessClassTypesSelectList =  fitnessClassTypes.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            return BuildSelectListItems(fitnessClassTypesSelectList);
        }

        private SelectListItem AddDefaultSelectItem()
        {
            return new SelectListItem
            {
                Value = "",
                Text = "Please Select an Item"
            };
        }

        private ICollection<SelectListItem> BuildSelectListItems(IEnumerable<SelectListItem> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            selectList.Add(AddDefaultSelectItem());
            selectList.AddRange(list);
            return selectList;
        }
    }
}

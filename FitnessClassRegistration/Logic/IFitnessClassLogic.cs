using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClassRegistration.Models.ApplicationViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessClassRegistration.Logic
{
    public interface IFitnessClassLogic
    {
        Task<FitnessClassEditView> FindById(int id);
        FitnessClassListView FindByIdForDelete(int id);
        bool FitnessClassExists(int id);
        Task<List<FitnessClassListView>> GetList();
        Task<List<FitnessClassListView>> GetFitnessClassWithRegistrations();
        Task<List<FitnessClassSignUpView>> GetAvailableClasses(string userName);
        Task Save(FitnessClassEditView fitnessClass);
        void Delete(int id);
        Task<FitnessClassEditView> Create();
        Task<ICollection<SelectListItem>> GetLocations();
        Task<ICollection<SelectListItem>> GetInstructors();
        Task<ICollection<SelectListItem>> GetFitnessClassTypes();
    }
}

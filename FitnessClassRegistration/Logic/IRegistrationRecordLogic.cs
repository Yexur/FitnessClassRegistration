using FitnessApp.Models.ApplicationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.Logic
{
//need to a ref to the find by fitness class id
    public interface IRegistrationRecordLogic
    {
        RegistrationRecordView Get(int id);
        Task<List<FitnessClassRegistrationView>> GetList();
        Task<List<FitnessClassRegistrationView>> FindByUserName(string userName);
        Task<List<RegistrationRecordView>> FindByFitnessClassId(int fitnessClassId);
        Task Save(RegistrationRecordView registrationRecord);
        Task SaveRange(int[] fitnessClassIds, string userName);
        void Delete(int id);
        void DeleteRange(int[] registrationRecordIds, string userName);
    }
}

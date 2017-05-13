using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessClassRegistration.Models.ApplicationViewModels;

namespace FitnessClassRegistration.Logic
{
    public interface IRegistrationRecordLogic
    {
        RegistrationRecordView Get(int id);
        Task<List<FitnessClassRegistrationView>> GetList();
        Task<List<FitnessClassRegistrationView>> FindByUserName(string userName);
        Task<RegistrationsByFitnessClassModel> FindByFitnessClassId(int fitnessClassId);
        Task Save(RegistrationRecordView registrationRecord);
        Task SaveRange(int[] fitnessClassIds, string userName);
        void Delete(int id);
        void DeleteRange(int[] registrationRecordIds);
        Task SaveAttended(RegistrationsByFitnessClassModel registrations);
    }
}

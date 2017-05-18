using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationModels.FitnessApp.Models;

namespace FitnessClassRegistration.IRepository
{
    public interface IRegistrationRecordRepository
    {
        Task<List<RegistrationRecord>> All();
        Task Insert(RegistrationRecord registrationRecord);
        Task InsertRange(List<RegistrationRecord> registrationRecords);
        void Delete(int id);
        void DeleteRange(List<RegistrationRecord> recordsToDelete);
        RegistrationRecord FindById(int id);
        Task<List<RegistrationRecord>> FindByUserName(string userName);
        Task<List<RegistrationRecord>> FindByFitnessClassId(int fitnessClassId);
        List<RegistrationRecord> FindByIdRange(List<int> ids);
    }
}

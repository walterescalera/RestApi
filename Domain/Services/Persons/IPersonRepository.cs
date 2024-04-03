using Domain.Entities;

namespace Domain.Services.Persons
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<List<Person>> GetAllAsync();
        Task AddAsync(Person entity);
        Task UpdateAsync(Person entity);
        Task DeleteAsync(Person entity);
        Task<Person> GetByCuilAndGenderAsync(long cuil, Gender gender);
        Task<bool> CheckDataBaseConnection();
    }
}

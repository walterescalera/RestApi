using Domain.Entities;
using System.Linq.Expressions;


namespace Domain.Services.Persons
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _personRepository.GetByIdAsync(id);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task AddAsync(Person entity)
        {
            await _personRepository.AddAsync(entity);
        }

        public async Task UpdateAsync(Person entity)
        {
            await _personRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Person entity)
        {
            await _personRepository.DeleteAsync(entity);
        }

        public async Task<Person> GetByCuilAndGenderAsync(string cuilt, string genderText)
        {
            if (cuilt.Length > 11)
            {
                throw new ArgumentException("Error, El rango del cuilt debe ser de 11 digitos");
            }

            if (!long.TryParse(cuilt, out long cuiltResult))
            {
                throw new ArgumentException("Error, El cuilt ingresado no es un entero");
            }

            Gender gender = GenderHelper.Parse(genderText);

            var data = await _personRepository.GetByCuilAndGenderAsync(cuiltResult, gender);
            
            return data;
        }

        public async Task<bool> CheckDataBaseConnection()
        {
            return await _personRepository.CheckDataBaseConnection();
        }
    }
}

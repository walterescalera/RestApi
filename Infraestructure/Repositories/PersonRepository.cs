using Domain.Entities;
using Domain.Services.Persons;
using Infraestructure.Contents;
using Microsoft.EntityFrameworkCore;


namespace Infraestructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IApplicationDbContext _dbContext;

        public PersonRepository(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Person>().FindAsync(id);
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.Set<Person>().ToListAsync();
        }

        public async Task AddAsync(Person entity)
        {
            await _dbContext.Set<Person>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Person entity)
        {
            _dbContext.Set<Person>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person entity)
        {
            _dbContext.Set<Person>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Person> GetByCuilAndGenderAsync(long cuil, Gender gender)
        {
            return await _dbContext.Set<Person>()
                .FirstOrDefaultAsync(p => p.Cuil == cuil && p.Gender == gender);
        }

        public async Task<bool> CheckDataBaseConnection()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

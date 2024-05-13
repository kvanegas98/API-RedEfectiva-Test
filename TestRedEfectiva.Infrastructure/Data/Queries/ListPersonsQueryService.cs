
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestRedAfectiva.UseCases.Person;


namespace TestRedAfectiva.Infrastructure.Data.Queries
{
    public class ListPersonsQueryService : IListPersonQueryService
    {
        private readonly AppDbContext _db;

        public ListPersonsQueryService(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<PersonDTO>> ListAsync()
        {
            try
            {
                var result = await _db.Person
                    .Select(c => new PersonDTO(
                        c.PersonId,
                        c.FirstName,
                        c.LastName,
                        c.Gender,
                        c.DateOfBirth,
                        c.Email,
                        c.Phone,
                        c.Status,
                        c.CreatedDate,
                        c.MaritalStatus
                    ))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<PersonDTO>> GetByIdAsync(string personId)
        {
            try
            {
                var result = await _db.Person
                    .Where(p => p.PersonId == personId)
                    .Select(c => new PersonDTO(
                        c.PersonId,
                        c.FirstName,
                        c.LastName,
                        c.Gender,
                        c.DateOfBirth,
                        c.Email,
                        c.Phone,
                        c.Status,
                        c.CreatedDate,
                        c.MaritalStatus
                    ))
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public Task<IEnumerable<PersonDTO>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

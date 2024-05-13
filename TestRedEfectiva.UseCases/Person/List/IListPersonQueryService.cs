using Ardalis.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRedAfectiva.UseCases.Person
{
    public interface IListPersonQueryService
    {
        Task<IEnumerable<PersonDTO>> ListAsync();
        Task<IEnumerable<PersonDTO>> GetByIdAsync(string id);
    }

}

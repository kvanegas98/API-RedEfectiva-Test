using TestRedAfectiva.Persons;
using TestRedAfectiva.Web.Persons;

namespace TestRedAfectiva.Web.Persons.List
{
    public class PersonListResponse
    {
        public List<PersonRecord> Persons { get; set; } = new();
    }
}

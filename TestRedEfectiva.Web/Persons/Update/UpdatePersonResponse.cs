using TestRedAfectiva.Persons;

namespace TestRedAfectiva.Persons;

public class UpdatePersonResponse
{
    public UpdatePersonResponse(PersonRecord person)
    {
        Person = person;
    }
    public PersonRecord Person { get; set; }
}

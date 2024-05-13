
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.UseCases.Person;

public record PersonDTO(
    string PersonId,
    string FirstName,
    string LastName,
    string Gender,
    DateTime DateOfBirth,
    string Email,
    string Phone,
    bool Status,
    DateTime CreatedDate,
    string MaritalStatus
);



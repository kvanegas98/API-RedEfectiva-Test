using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.Persons;

public record PersonRecord(string PersonId, string FirstName, string LastName, string? Gender, DateTime DateOfBirth, string? Email, string? Phone, string MaritalStatus,bool status, DateTime? CreatedDate);

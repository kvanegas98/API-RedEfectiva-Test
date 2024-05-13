using Ardalis.Result;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.UseCases.Person.Create;

/// <summary>
/// Create a new person.
/// </summary>
/// <param name="Name"></param>
public record CreatePersonCommand(string FirstName, string LastName, string Gender, DateTime DateOfBirth, string Email, string Phone, string MaritalStatus) : Ardalis.SharedKernel.ICommand<Result<string>>;

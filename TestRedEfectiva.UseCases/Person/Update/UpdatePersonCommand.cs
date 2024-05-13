using Ardalis.Result;
using Ardalis.SharedKernel;
using System;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.UseCases.Person.Update;

public record UpdatePersonCommand(string PersonId, string FirstName, string LastName, string Gender, DateTime DateOfBirth, string Email, string Phone, string MaritalStatus) : ICommand<Result<PersonDTO>>;

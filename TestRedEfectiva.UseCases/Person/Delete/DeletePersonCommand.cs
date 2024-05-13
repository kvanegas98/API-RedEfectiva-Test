using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TestRedAfectiva.UseCases.Person.Delete;

public record DeletePersonCommand(string PersonId) : ICommand<Result>;

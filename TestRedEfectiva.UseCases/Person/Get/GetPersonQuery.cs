using Ardalis.Result;
using Ardalis.SharedKernel;
using TestRedAfectiva.UseCases.Person;

namespace TestRedAfectiva.UseCases.Contributors.Get;

public record GetPersonQuery(string PersonId) : IQuery<Result<PersonDTO>>;

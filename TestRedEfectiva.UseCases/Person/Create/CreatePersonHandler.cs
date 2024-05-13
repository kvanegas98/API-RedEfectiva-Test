using Ardalis.Result;
using Ardalis.SharedKernel;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.UseCases.Person.Create;

public class CreatePersonHandler : ICommandHandler<CreatePersonCommand, Result<string>>
{
    private readonly IRepository<Core.PersonAggregate.Person> _repository;

    public CreatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
    {
        _repository = repository;
    }

    public async Task<Result<string>> Handle(CreatePersonCommand request,
      CancellationToken cancellationToken)
    {
        var newPerson = new Core.PersonAggregate.Person(request.FirstName, request.LastName, request.Gender, request.DateOfBirth,request.Email,request.Phone,request.MaritalStatus);
        var createdItem = await _repository.AddAsync(newPerson, cancellationToken);

        return createdItem.PersonId;
    }
}

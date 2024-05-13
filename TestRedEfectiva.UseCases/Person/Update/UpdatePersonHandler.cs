using Ardalis.Result;
using Ardalis.SharedKernel;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.UseCases.Person.Update;

public class UpdatePersonHandler : ICommandHandler<UpdatePersonCommand, Result<PersonDTO>>
{
    private readonly IRepository<Core.PersonAggregate.Person> _repository;

    public UpdatePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
    {
        _repository = repository;
    }

    public async Task<Result<PersonDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
        if (existingPerson == null)
        {
            return Result.NotFound();
        }

        existingPerson.UpdateDetails(request.FirstName, request.LastName, request.Gender, request.DateOfBirth, request.Email, request.Phone, request.MaritalStatus);
        await _repository.UpdateAsync(existingPerson, cancellationToken);
        return Result.Success(new PersonDTO(existingPerson.PersonId, existingPerson.FirstName, existingPerson.LastName, existingPerson.Gender, existingPerson.DateOfBirth, existingPerson.Email, existingPerson.Phone, existingPerson.Status, existingPerson.CreatedDate, existingPerson.MaritalStatus));
    }
}

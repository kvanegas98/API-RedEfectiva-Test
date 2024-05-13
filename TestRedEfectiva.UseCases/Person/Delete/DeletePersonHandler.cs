using Ardalis.Result;
using Ardalis.SharedKernel;
using TestRedAfectiva.UseCases.Person.Delete;

namespace TestRedAfectiva.UseCases.Person.Delete;

public class DeletePersonHandler : ICommandHandler<DeletePersonCommand, Result>
{
    private readonly IRepository<Core.PersonAggregate.Person> _repository;

    public DeletePersonHandler(IRepository<Core.PersonAggregate.Person> repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
        if (existingPerson == null)
        {
            return Result.NotFound();
        }
        await _repository.DeleteAsync(existingPerson, cancellationToken);
        return Result.Success();
    }
}

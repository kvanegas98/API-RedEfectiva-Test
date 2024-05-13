using Ardalis.Result;
using Ardalis.SharedKernel;
using FastEndpoints;
using MediatR;
using TestRedAfectiva.Persons;
using TestRedAfectiva.Core.PersonAggregate;
using TestRedAfectiva.UseCases.Person.Update;
using TestRedAfectiva.Persons;
using TestRedAfectiva.Persons.Creates;

namespace TestRedAfectiva.Web.Persons;

/// <summary>
/// Update an existing Persons.
/// </summary>
/// <remarks>
/// Update an existing person
/// </remarks>
public class Update : Endpoint<UpdatePersonRequest, UpdatePersonResponse>
{
    private readonly IRepository<Person> _repository;
    private readonly IMediator _mediator;

    public Update(IRepository<Person> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public override void Configure()
    {
        Put(UpdatePersonRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(
      UpdatePersonRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdatePersonCommand(request.PersonId, request.FirstName, request.LastName,request.Gender,request.DateOfBirth, request.Email, request.Phone, request.MaritalStatus));

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        var existingPerson = await _repository.GetByIdAsync(request.PersonId, cancellationToken);
        if (existingPerson == null)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            var dto = result.Value;
            Response = new UpdatePersonResponse(new PersonRecord(dto.PersonId, dto.FirstName, dto.LastName, dto.Gender, dto.DateOfBirth, dto.Email, dto.Phone,dto.MaritalStatus,dto.Status, dto.CreatedDate));
            return;
        }
    }
}

using Ardalis.Result;
using FastEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using TestRedAfectiva.Persons.Delete;
using TestRedAfectiva.UseCases.Person.Delete;

namespace TestRedAfectiva.Persons.Delete;


/// <summary>
/// Delete a person.
/// </summary>
/// <remarks>
/// Delete a person by providing a valid integer id.
/// </remarks>
public class Delete : Endpoint<DeletePersonRequest>
{
    private readonly IMediator _mediator;

    public Delete(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Delete(DeletePersonRequest.Route);
        AllowAnonymous();
    }

    public override async Task HandleAsync(
      DeletePersonRequest request,
      CancellationToken cancellationToken)
    {
        var command = new DeletePersonCommand(request.PersonId);

        var result = await _mediator.Send(command);

        if (result.Status == ResultStatus.NotFound)
        {
            await SendNotFoundAsync(cancellationToken);
            return;
        }

        if (result.IsSuccess)
        {
            await SendOkAsync(cancellationToken);
        };
    }
}


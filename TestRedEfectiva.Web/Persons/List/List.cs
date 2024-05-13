using FastEndpoints;
using MediatR;
using TestRedAfectiva.Persons;
using TestRedAfectiva.Web.Persons.List;
using TestRedAfectiva.UseCases.Person.List;

namespace TestRedAfectiva.Web.Persons.List;

/// <summary>
/// List all Persons
/// </summary>
/// <remarks>
/// List all persons - returns a PersonListResponse containing the persons.
/// </remarks>
public class List : EndpointWithoutRequest<PersonListResponse>
{
    private readonly IMediator _mediator;

    public List(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Get("/persons");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new ListPersonQuery(null, null));

        if (result.IsSuccess)
        {
            Response = new PersonListResponse
            {
                Persons = result.Value.Select(c => new PersonRecord(c.PersonId, c.FirstName, c.LastName, c.Gender,c.DateOfBirth, c.Email, c.Phone
                , c.MaritalStatus,c.Status, c.CreatedDate)).ToList()
            };
        }
    }
}

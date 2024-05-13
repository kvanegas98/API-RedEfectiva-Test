using FastEndpoints;
using TestRedAfectiva.UseCases.Person.Create;
using MediatR;
using TestRedAfectiva.Persons.Creates;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.Web.Persons;

/// <summary>
/// Create a new Person
/// </summary>
/// <remarks>
/// Creates a new Person
/// </remarks>
public class Create : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
    private readonly IMediator _mediator;

    public Create(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override void Configure()
    {
        Post(CreatePersonRequest.Route);
        AllowAnonymous();
        Summary(s =>
        {
            s.ExampleRequest = new CreatePersonRequest
            {
                FirstName = "Kevin",
                LastName = "Vanegas",
                Gender = "Male",
                DateOfBirth = DateTime.Parse("1998-11-10"),
                Email = "kvanegas98@gmail.com",
                Phone = "87663755",
                MaritalStatus = "Single"
            };
        });
    }

    public override async Task HandleAsync(
      CreatePersonRequest request,
      CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreatePersonCommand(request.FirstName, request.LastName, request.Gender, request.DateOfBirth, request.Email, request.Phone, request.MaritalStatus));

        if (result.IsSuccess)
        {
            Response = new CreatePersonResponse(result.Value, request.FirstName!, request.LastName!, request.Gender,request.DateOfBirth, request.Email, request.Phone, request.MaritalStatus);
            return;
        }
    }
}

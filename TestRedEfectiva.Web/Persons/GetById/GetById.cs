using Ardalis.Result;
using FastEndpoints;
using MediatR;
using TestRedAfectiva.Persons;
using TestRedAfectiva.Persons.GetById;
using TestRedAfectiva.UseCases.Contributors.Get;

namespace TestRedAfectiva.Web.Persons.GetById
{
    public class GetById : Endpoint<GetPersonByIdRequest, PersonRecord>
    {
        private readonly IMediator _mediator;

        public GetById(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override void Configure()
        {
            Get(GetPersonByIdRequest.Route);
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetPersonByIdRequest request,
          CancellationToken cancellationToken)
        {
            var command = new GetPersonQuery(request.PersonId);

            var result = await _mediator.Send(command);

            if (result.Status == ResultStatus.NotFound)
            {
                await SendNotFoundAsync(cancellationToken);
                return;
            }

            if (result.IsSuccess)
            {
                Response = new PersonRecord(result.Value.PersonId, result.Value.FirstName, result.Value.LastName, result.Value.Gender, result.Value.DateOfBirth, result.Value.Email, result.Value.Phone
                , result.Value.MaritalStatus,result.Value.Status, result.Value.CreatedDate);
            }
        }
    }
}

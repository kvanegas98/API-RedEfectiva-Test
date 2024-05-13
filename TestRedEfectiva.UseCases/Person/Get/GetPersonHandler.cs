using Ardalis.Result;
using Ardalis.SharedKernel;
using TestRedAfectiva.Core.PersonAggregate;
using TestRedAfectiva.UseCases.Contributors.Get;
using TestRedAfectiva.UseCases.Person;
using TestRedAfectiva.UseCases.Person.List;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
//using NimblePros.SampleToDo.Core.ContributorAggregate.Specifications;

namespace TestRedAfectiva.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
    private readonly IListPersonQueryService _query;

    public GetPersonHandler(IListPersonQueryService query)
    {
        _query = query;
    }

    public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var result = await _query.GetByIdAsync(request.PersonId);

        var resultReturn = result.FirstOrDefault();

        return new PersonDTO(resultReturn.PersonId, resultReturn.FirstName, resultReturn.LastName, resultReturn.Gender,resultReturn.DateOfBirth, resultReturn.Email, resultReturn.Phone,resultReturn.Status,resultReturn.CreatedDate, resultReturn.MaritalStatus);
    }
}

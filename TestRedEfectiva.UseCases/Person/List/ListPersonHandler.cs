using Ardalis.Result;
using Ardalis.SharedKernel;

namespace TestRedAfectiva.UseCases.Person.List;

public class ListPersonHandler : IQueryHandler<ListPersonQuery, Result<IEnumerable<PersonDTO>>>
{
    private readonly IListPersonQueryService _query;

    public ListPersonHandler(IListPersonQueryService query)
    {
        _query = query;
    }

    public async Task<Result<IEnumerable<PersonDTO>>> Handle(ListPersonQuery request, CancellationToken cancellationToken)
    {
        var result = await _query.ListAsync();

        return Result.Success(result);
    }
}

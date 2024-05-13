namespace TestRedAfectiva.Persons.GetById
{
    public class GetPersonByIdRequest
    {
        public const string Route = "/persons/{PersonId}";
        public static string BuildRoute(string personId) => Route.Replace("{PersonId}", personId);

        public string PersonId { get; set; }
    }
}

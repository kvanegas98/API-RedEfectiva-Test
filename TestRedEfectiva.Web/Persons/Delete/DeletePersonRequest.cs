namespace TestRedAfectiva.Persons.Delete
{
    public class DeletePersonRequest
    {
        public const string Route = "/persons/{PersonId}";
        public static string BuildRoute(int personId) => Route.Replace("{PersonId}", personId.ToString());

        public string PersonId { get; set; }
    }
}

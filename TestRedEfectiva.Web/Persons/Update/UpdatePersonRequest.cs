using System.ComponentModel.DataAnnotations;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.Persons;

public class UpdatePersonRequest
{
    public const string Route = "/persons";

    [Required]
    public string PersonId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string MaritalStatus { get; set; }
    public DateTime DateOfBirth { get; internal set; }
}

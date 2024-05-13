using System.ComponentModel.DataAnnotations;
using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.Persons.Creates
{
    public class CreatePersonRequest
    {
        public const string Route = "/persons";

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
       
    }
}

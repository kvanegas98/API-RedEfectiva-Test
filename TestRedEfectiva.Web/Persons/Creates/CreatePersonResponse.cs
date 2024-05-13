using TestRedAfectiva.Core.PersonAggregate;

namespace TestRedAfectiva.Persons.Creates
{
    public class CreatePersonResponse
    {
        public CreatePersonResponse(string id, string name, string lastname, string gender, DateTime dateOfBirth, string email, string phone, string maritalStatus)
        {
            PersonId = id;
            FirstName = name;
            LastName = lastname;
            Gender= gender;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            MaritalStatus = maritalStatus;

        }
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
    }
}

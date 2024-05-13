using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using System;

namespace TestRedAfectiva.Core.PersonAggregate
{
    public class Person : IAggregateRoot
    {
        public string PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Gender { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public bool Status { get; private set; } = true;
        public string MaritalStatus { get; private set; }
        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        private enum GenderEnum
        {
            Male,
            Female
        }
        public enum MaritalStatusEnum
        {
            Single,
            Married,
            Divorced
        }

        public Person(string firstName, string lastName, string gender, DateTime dateOfBirth, string email, string phone, string maritalStatus)
        {
            PersonId = Guid.NewGuid().ToString();
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            if (ValidateGender(gender))
            {
                Gender = gender;
            }
            else
            {
                throw new ArgumentException("El género proporcionado no es válido.", nameof(gender));
            }
            DateOfBirth = dateOfBirth;
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            MaritalStatus = Guard.Against.NullOrEmpty(maritalStatus, nameof(maritalStatus));
            CreatedDate = DateTime.Now;
        }

        public void UpdateDetails(string firstName, string lastName, string gender, DateTime dateOfBirth, string email, string phone, string maritalStatus)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
            Gender = ValidateGender(gender) ? gender : throw new ArgumentException("El género proporcionado no es válido, pueden ser Male o Female", nameof(gender));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            MaritalStatus = ValidateMaritalStatus(maritalStatus) ? maritalStatus : throw new ArgumentException("El estado marital proporcionado no es válido, puden ser Single, Married o Divorced.", nameof(maritalStatus));

        }

        private bool ValidateGender(string _gender)
        {
            return Enum.IsDefined(typeof(GenderEnum), _gender);
        }
        private bool ValidateMaritalStatus(string _maritalStatus)
        {
            return Enum.IsDefined(typeof(MaritalStatusEnum), _maritalStatus);
        }
    }
}

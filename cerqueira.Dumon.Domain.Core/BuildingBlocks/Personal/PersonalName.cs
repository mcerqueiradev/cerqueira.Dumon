using cerqueira.Dumon.Domain.Core.Common;
using cerqueira.Dumon.Domain.Core.Exceptions;

namespace cerqueira.Dumon.Domain.Core.BuildingBlocks.Personal;

public class PersonalName : ValueObject
{
    public string FirstName { get; }
    public string LastName { get; }
    public string FullName => $"{FirstName} {LastName}";
    public string Initials => $"{FirstName[0]}{LastName[0]}".ToUpper(); 

    private PersonalName() { }

    private PersonalName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        Validate();
    }

    public PersonalName(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static PersonalName Create(string firstName, string lastName)
    {
        return new PersonalName(firstName, lastName);
    }

    public static PersonalName FromFullName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ValidationException("Full name cannot be empty", nameof(fullName));

        var names = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (names.Length < 2)
            throw new ValidationException("Full name must contain at least first and last name", nameof(fullName));

        var firstName = names[0];
        var lastName = string.Join(" ", names.Skip(1));

        return new PersonalName(firstName, lastName);
    }

    public PersonalName WithFirstName(string newFirstName)
    {
        return new PersonalName(newFirstName, LastName);
    }

    public PersonalName WithLastName(string newLastName)
    {
        return new PersonalName(FirstName, newLastName);
    }

    private void Validate()
    {
        var validator = new Validators.PersonalNameValidator();
        var result = validator.Validate(this);

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e =>
                new ValidationError(e.ErrorMessage, e.PropertyName));

            throw new ValidationException(errors);
        }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }

    public override string ToString() => FullName;
}
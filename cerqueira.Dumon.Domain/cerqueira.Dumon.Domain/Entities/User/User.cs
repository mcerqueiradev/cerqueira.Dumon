using cerqueira.Dumon.Domain.Core.Abstractions;
using cerqueira.Dumon.Domain.Entities.Billing;
using cerqueira.Dumon.Domain.Entities.Shopping;
using cerqueira.Dumon.Domain.Enums;
using cerqueira.Dumon.Domain.Interface;
using cerqueira.Dumon.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.Entities.User;

public class User : IAggregateRoot, IAuditableEntity
{
    [Key]
    public Guid Id { get; private set; }

    [Required]
    public PersonalName Name { get; private set; }

    [Required]
    public Email Email { get; private set; }

    [Phone]
    [MaxLength(20)]
    public string? PhoneNumber { get; private set; }

    public DateTime? DateOfBirth { get; private set; }

    [Required]
    public UserRole Role { get; private set; }

    [Required]
    public PasswordHash Password { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime? LastLoginDate { get; private set; }

    [Url]
    [MaxLength(500)]
    public string? ProfilePictureUrl { get; private set; }

    public virtual ICollection<Household> Households { get; private set; } = new List<Household>();
    public virtual ICollection<ShoppingList> ShoppingLists { get; private set; } = new List<ShoppingList>();
    public virtual ICollection<Bill> Bills { get; private set; } = new List<Bill>();

    protected User() { }

    public User(
        PersonalName name,
        Email email,
        PasswordHash password,
        UserRole role = UserRole.Member,
        string? phoneNumber = null,
        DateTime? dateOfBirth = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Password = password;
        Role = role;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        IsActive = true;
        LastLoginDate = DateTime.UtcNow;
    }

    public void UpdatePersonalInfo(PersonalName newName, string? phoneNumber, DateTime? dateOfBirth)
    {
        Name = newName;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public void ChangePassword(PasswordHash newPassword)
    {
        Password = newPassword;
    }

    public void UpdateProfilePicture(string url)
    {
        ProfilePictureUrl = url;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void UpdateLastLogin()
    {
        LastLoginDate = DateTime.UtcNow;
    }

    public void ChangeRole(UserRole newRole)
    {
        Role = newRole;
    }
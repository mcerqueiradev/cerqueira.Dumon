using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.ValueObjects;

public record PersonalName(
    [Required][MaxLength(50)] string FirstName,
    [Required][MaxLength(100)] string LastName
);

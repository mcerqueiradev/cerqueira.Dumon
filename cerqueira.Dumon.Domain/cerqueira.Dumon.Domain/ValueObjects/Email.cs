using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.ValueObjects;

public record Email(
    [Required][EmailAddress][MaxLength(255)] string Value
);

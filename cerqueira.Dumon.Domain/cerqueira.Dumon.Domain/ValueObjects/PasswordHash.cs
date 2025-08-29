using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.ValueObjects;

public record PasswordHash(
    [Required] byte[] Hash,
    [Required] byte[] Salt
);
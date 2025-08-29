using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.ValueObjects;

public record Address(
    [MaxLength(100)] string Street,
    [MaxLength(50)] string City,
    [MaxLength(20)] string PostalCode,
    [MaxLength(50)] string? State = null,
    [MaxLength(50)] string? Country = "Portugal"
);

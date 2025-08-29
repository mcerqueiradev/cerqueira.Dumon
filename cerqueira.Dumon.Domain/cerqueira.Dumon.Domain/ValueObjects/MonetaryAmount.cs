using System.ComponentModel.DataAnnotations;

namespace cerqueira.Dumon.Domain.ValueObjects;

public record MonetaryAmount(
    [Range(0, 1000000)] decimal Value,
    [Length(3)] string CurrencyCode
);

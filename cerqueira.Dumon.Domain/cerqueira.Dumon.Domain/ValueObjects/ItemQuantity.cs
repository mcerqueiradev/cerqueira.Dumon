namespace cerqueira.Dumon.Domain.ValueObjects;

public record ItemQuantity
{
    public int Value { get; }

    public ItemQuantity(int value)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(nameof(value), "Quantity must be positive");

        Value = value;
    }

    public override string ToString() => Value.ToString();
}

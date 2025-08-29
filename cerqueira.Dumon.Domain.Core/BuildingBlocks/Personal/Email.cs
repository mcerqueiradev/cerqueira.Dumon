using cerqueira.Dumon.Domain.Core.Common;

namespace cerqueira.Dumon.Domain.Core.BuildingBlocks.Personal;

public class Email : ValueObject
{
    public string Value { get; }

    public Email(string value) { Value = value; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

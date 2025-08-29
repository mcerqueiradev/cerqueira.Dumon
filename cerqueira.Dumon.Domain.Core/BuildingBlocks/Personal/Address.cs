using cerqueira.Dumon.Domain.Core.Common;

namespace cerqueira.Dumon.Domain.Core.BuildingBlocks.Personal;

public class Address : ValueObject
{
    public string Street { get; }
    public string City { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
    }
}

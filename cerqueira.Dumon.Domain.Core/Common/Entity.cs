namespace cerqueira.Dumon.Domain.Core.Common;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        if (Id == Guid.Empty || other.Id == Guid.Empty) return false;
    }

    public bool Equals(Entity other)
    {
        return Equals((object)other);
    }

    public override int GetHashCode()
    {
        return(GetType().ToString() + Id).GetHashCode();
    }

    public static bool operator ==(Entity left, Entity right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;

        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;

        return left.Equals(right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }
    protected virtual IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }

    public Entity ShallowCopy()
    {
        return (Entity)MemberwiseClone();
    }
}

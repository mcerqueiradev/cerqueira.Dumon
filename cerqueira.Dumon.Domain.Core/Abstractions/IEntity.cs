namespace cerqueira.Dumon.Domain.Abstractions;

public interface IEntity<T>
{
    T Id { get; }

    bool Equals(object obj);
    int GetHashCode();
}

namespace cerqueira.Dumon.Domain.Abstractions;

public interface IEntity<T>
{
    public T Id { get; set; }
}

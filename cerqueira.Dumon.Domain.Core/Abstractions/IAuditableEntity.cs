namespace cerqueira.Dumon.Domain.Core.Abstractions;

public interface IAuditableEntity
{
    DateTime CreatedAt { get; }
    string CreatedBy { get; }
    DateTime UpdatedAt { get; }
    string UpdatedBy { get; }

    void TrackCreation(string createdBy);
    void TrackUpdate(string updatedBy);
}

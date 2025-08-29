using cerqueira.Dumon.Domain.Core.Abstractions;
using cerqueira.Dumon.Domain.Core.Common;

namespace cerqueira.Dumon.Domain.Common;

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTime CreatedAt { get; protected set; }
    public string CreatedBy { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public string UpdatedBy { get; protected set; }

    protected AuditableEntity() : base()
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    protected AuditableEntity(Guid id) : base(id)
    {
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    // Métodos para atualizar informações de auditoria
    public void SetCreated(string createdBy, DateTime? createdAt = null)
    {
        CreatedBy = createdBy ?? throw new ArgumentNullException(nameof(createdBy));
        CreatedAt = createdAt ?? DateTime.UtcNow;
        UpdatedAt = CreatedAt;
        UpdatedBy = CreatedBy;
    }

    public void SetUpdated(string updatedBy, DateTime? updatedAt = null)
    {
        UpdatedBy = updatedBy ?? throw new ArgumentNullException(nameof(updatedBy));
        UpdatedAt = updatedAt ?? DateTime.UtcNow;
    }

    // Método para rastrear criação
    public void TrackCreation(string createdBy)
    {
        if (CreatedAt == default)
        {
            SetCreated(createdBy);
        }
    }

    // Método para rastrear atualização
    public void TrackUpdate(string updatedBy)
    {
        SetUpdated(updatedBy);
    }
}
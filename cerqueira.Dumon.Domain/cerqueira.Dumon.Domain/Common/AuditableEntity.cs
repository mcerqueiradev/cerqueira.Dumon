using cerqueira.Dumon.Domain.Interface;

namespace cerqueira.Dumon.Domain.Common;

public class AuditableEntity : IAuditableEntity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdateAt { get; set; }
    public string UpdatedBy { get; set; }
}

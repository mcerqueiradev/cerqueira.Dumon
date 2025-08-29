using cerqueira.Dumon.Domain.Common;
using cerqueira.Dumon.Domain.Enums;
using cerqueira.Dumon.Domain.ValueObjects;

namespace cerqueira.Dumon.Domain.Entities.Billing;

public class Bill : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public MonetaryAmount Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public BillStatus Status { get; private set; }
    public Household Household { get; private set; }

    public Bill(string description, decimal amount, DateTime dueDate, Household household)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = new MonetaryAmount(amount, "EUR");
        DueDate = dueDate;
        Status = BillStatus.Pending;
        Household = household;
    }

    public void MarkAsPaid()
    {
        Status = BillStatus.Paid;
    }
}
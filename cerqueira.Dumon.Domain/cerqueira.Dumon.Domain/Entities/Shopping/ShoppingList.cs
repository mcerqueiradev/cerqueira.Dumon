using cerqueira.Dumon.Domain.Common;

namespace cerqueira.Dumon.Domain.Entities.Shopping;

public class ShoppingList : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }
    public Household Household { get; private set; }

    public ICollection<ShoppingItem> Items { get; private set; } = new List<ShoppingItem>();

    public ShoppingList(string title, Household household)
    {
        Id = Guid.NewGuid();
        Title = title;
        Household = household;
    }

    public void AddItem(string name, int quantity = 1)
    {
        Items.Add(new ShoppingItem(name, quantity));
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
}
using cerqueira.Dumon.Domain.Common;
using cerqueira.Dumon.Domain.ValueObjects;

namespace cerqueira.Dumon.Domain.Entities.Shopping;
public class ShoppingItem : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ItemQuantity Quantity { get; private set; }
    public bool IsPurchased { get; private set; }
    public ShoppingList ShoppingList { get; private set; }

    protected ShoppingItem() { }

    public ShoppingItem(string name, int quantity, ShoppingList shoppingList)
    {
        Id = Guid.NewGuid();
        Name = name.Trim();
        Quantity = new ItemQuantity(quantity);
        ShoppingList = shoppingList;
        IsPurchased = false;
    }

    public void MarkAsPurchased()
    {
        if (!IsPurchased)
        {
            IsPurchased = true;
        }
    }

    public void UpdateQuantity(int newQuantity)
    {
        Quantity = new ItemQuantity(newQuantity);
    }

    public void Rename(string newName)
    {
        Name = newName.Trim();
    }
}
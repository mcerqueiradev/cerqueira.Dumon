using cerqueira.Dumon.Domain.Common;
using cerqueira.Dumon.Domain.Entities.Shopping;
using cerqueira.Dumon.Domain.ValueObjects;

namespace cerqueira.Dumon.Domain.Entities.Household;

public class Household : AuditableEntity
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public Address? Address { get; private set; }

    public ICollection<User> Members { get; private set; } = new List<User>();

    public ICollection<ShoppingList> ShoppingLists { get; private set; } = new List<ShoppingList>();

    public Household(string name, User creator)
    {
        Id = Guid.NewGuid();
        Name = name;
        Members.Add(creator);
    }

    public void UpdateDetails(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
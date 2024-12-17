using Sereno.Core.Common;
using Sereno.Core.Domains.ExternalProviders.ValueObjects;

namespace Sereno.Core.Domains.ExternalProviders.Entities;

public class Provider : BaseEntity
{
    public Provider(string name, string contactInfo, List<MenuItem> menu)
    {
        Name = name;
        ContactInfo = contactInfo;
        Menu = menu ?? new List<MenuItem>();
    }

    public string Name { get; private set; }
    public string ContactInfo { get; private set; }
    private List<MenuItem> Menu { get; }

    public void AddMenuItem(MenuItem menuItem)
    {
        Menu.Add(menuItem);
    }
}
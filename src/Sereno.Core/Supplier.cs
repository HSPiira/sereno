using Sereno.Core.Common;

namespace Sereno.Core;

public class Supplier : BaseEntity
{
    public Supplier(){}

    public Supplier(Guid id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }
    public string Name {get;set;}
    public string Address {get;set;}
}
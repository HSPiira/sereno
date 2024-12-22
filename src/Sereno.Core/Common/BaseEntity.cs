using System.ComponentModel.DataAnnotations;

namespace Sereno.Core.Common;

public class BaseEntity : IEntity
{
    [Required]
    public Guid Id {get; protected init;}

    object IEntity.Id
    {
        get => Id;
        set { }
    }
    public DateTime CreatedAt {get;set;}
    public DateTime? UpdatedAt {get;set;}
    public bool IsDeleted {get;set;}
}

public interface IEntity
{
    object Id {get;set;}
    public DateTime CreatedAt {get;set;}
    public DateTime? UpdatedAt {get;set;}
    public bool IsDeleted {get;set;}
}
namespace Sereno.Core.Common;

public class BaseEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string? CreatedBy { get; private set; }
    public DateTime CreatedDate { get; private set; } = DateTime.UtcNow;
    public string? LastModifiedBy { get; private set; }
    public DateTime? LastModifiedDate { get; private set; }

    public void SetCreatedBy(string createdBy)
    {
        CreatedBy = createdBy;
    }

    public void SetLastModified(string modifiedBy)
    {
        LastModifiedBy = modifiedBy;
        LastModifiedDate = DateTime.UtcNow;
    }
}
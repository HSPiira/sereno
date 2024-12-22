namespace Sereno.Core.Common;

public class AppSetting : BaseEntity
{
    /// <summary>
    /// Gets or sets the ReferenceKey
    /// </summary>
    public string ReferenceKey { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Value
    /// </summary>
    public string Value { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Description
    /// </summary>
    public string Description { get; set; } = String.Empty;
    /// <summary>
    /// Gets or sets the Type
    /// </summary>
    public string Type { get; set; } = String.Empty;
}
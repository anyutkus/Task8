namespace Task8._0;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]

public class TrackingPropertyAttribute : Attribute
{
    public string? PropertyName { get; set; }
}


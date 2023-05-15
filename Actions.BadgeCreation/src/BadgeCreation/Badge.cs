namespace BadgeCreation;

public class Badge
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }

    public static Badge Create(string name, StatusEnum status)
    {
        var badge = new Badge()
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Description = "This is a badge",
            Status = status
        };
        
        return badge;
    } 
}

public enum StatusEnum
{
    Success,
    Failure,
    Pending
}

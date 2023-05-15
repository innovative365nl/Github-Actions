namespace BadgeCreation;

public class Badge
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }

    public Badge(string name, StatusEnum status)
    {
        Id = Guid.NewGuid().ToString(),
        Name = name,
        Description = "This is a badge",
        Status = status
    } 
}

public enum StatusEnum
{
    Success,
    Failure,
    Pending
}

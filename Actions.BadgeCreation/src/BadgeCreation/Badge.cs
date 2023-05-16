namespace BadgeCreation;

public class Badge
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public StatusEnum Status { get; set; }
    public string Color { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Badge(string name, StatusEnum status, string color)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Description = "This is a badge";
        Status = status;
        Color = color;
    } 
}

public enum StatusEnum
{
    Success,
    Failure,
    Pending
}

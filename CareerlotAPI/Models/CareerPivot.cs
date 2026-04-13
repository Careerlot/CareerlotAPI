namespace CareerlotAPI.Models;

public class CareerPivot
{
    public int Id { get; set; }
    public string OriginalRole { get; set; } = string.Empty;
    public string SuggestedRole { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
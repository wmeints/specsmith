namespace SpecSmith.Models;

public class Project
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<Feature> Features { get; set; } = new();
}
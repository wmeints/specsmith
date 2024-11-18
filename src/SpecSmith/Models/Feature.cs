namespace SpecSmith.Models;

public class Feature
{
    public int Id { get; set; }
    public required Project Project { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}
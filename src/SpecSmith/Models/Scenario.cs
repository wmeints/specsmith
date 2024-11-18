namespace SpecSmith.Models;

public class Scenario
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required Feature Feature { get; set; }
    public List<Step> Steps { get; set; } = new();
}
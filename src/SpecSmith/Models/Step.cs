namespace SpecSmith.Models;

public class Step
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required Scenario Scenario { get; set; }
}